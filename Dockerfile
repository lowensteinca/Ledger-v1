FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ["src/Ledger.Web/Ledger.Web.csproj", "src/Ledger.Web/"]
COPY ["src/Ledger.Application/Ledger.Application.csproj", "src/Ledger.Application/"]
COPY ["src/Ledger.Domain/Ledger.Domain.csproj", "src/Ledger.Domain/"]
COPY ["src/Ledger.Infrastructure/Ledger.Infrastructure.csproj", "src/Ledger.Infrastructure/"]
COPY ["Directory.Build.props", "./"]

RUN dotnet restore "src/Ledger.Web/Ledger.Web.csproj"

# Copy source code and build
COPY . .
WORKDIR "/app/src/Ledger.Web"
RUN dotnet build "Ledger.Web.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Ledger.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Create non-root user for security
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Copy published application
COPY --from=publish /app/publish .

# Health check
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
  CMD curl -f http://localhost:8080/health || exit 1

# Set environment variables
ENV ASPNETCORE_HTTP_PORTS=8080
ENV DOTNET_EnableDiagnostics=0

ENTRYPOINT ["dotnet", "Ledger.Web.dll"]
