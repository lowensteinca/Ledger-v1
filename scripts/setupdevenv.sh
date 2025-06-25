# Create scripts directory and setup script
mkdir -p scripts

cat > scripts/setupdevenv.sh << 'EOF'
#!/bin/bash

echo "Setting up LifeLedger development environment..."

# Function to check if command exists
command_exists() {
    command -v "$1" >/dev/null 2>&1
}

# Check prerequisites
echo "Checking prerequisites..."

if ! command_exists dotnet; then
    echo "❌ .NET 8 SDK is not installed. Please install from https://dotnet.microsoft.com/download"
    exit 1
fi

if ! command_exists docker; then
    echo "❌ Docker is not installed. Please install from https://docs.docker.com/get-docker/"
    exit 1
fi

if ! command_exists docker-compose; then
    echo "❌ Docker Compose is not installed."
    exit 1
fi

echo "✅ All prerequisites are installed"

# Install dotnet tools
echo "Installing .NET global tools..."
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-outdated-tool
dotnet tool install --global dotnet-reportgenerator-globaltool

# Restore packages
echo "Restoring NuGet packages..."
dotnet restore

# Start infrastructure services
echo "Starting infrastructure services with Docker Compose..."
docker-compose up -d postgres redis rabbitmq elasticsearch

# Wait for services to be ready
echo "Waiting for services to be ready..."
sleep 30

# Create database and run migrations
echo "Creating database and running migrations..."
dotnet ef database update --project src/LifeLedger.Infrastructure --startup-project src/LifeLedger.Web

echo "✅ Development environment setup complete!"
echo "📝 Next steps:"
echo "   1. Run 'dotnet run --project src/LifeLedger.Web' to start the API"
echo "   2. Open https://localhost:7000/swagger for API documentation"
echo "   3. Open https://localhost:15672 for RabbitMQ management (admin/password)"
echo "   4. Connect to PostgreSQL at localhost:5432 (postgres/yourpassword)"
EOF
