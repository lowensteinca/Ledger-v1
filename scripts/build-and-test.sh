#!/bin/bash

echo "Building and testing LifeLedger..."

# Clean solution
echo "🧹 Cleaning solution..."
dotnet clean

# Restore packages
echo "📦 Restoring packages..."
dotnet restore

# Build solution
echo "🔨 Building solution..."
dotnet build --configuration Release --no-restore

if [ $? -ne 0 ]; then
    echo "❌ Build failed!"
    exit 1
fi

# Run tests
echo "🧪 Running tests..."
dotnet test --configuration Release --no-build --logger trx --collect:"XPlat Code Coverage"

if [ $? -ne 0 ]; then
    echo "❌ Tests failed!"
    exit 1
fi

# Generate test coverage report (if reportgenerator is installed)
if command -v reportgenerator >/dev/null 2>&1; then
    echo "📊 Generating test coverage report..."
    reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"TestResults/CoverageReport" -reporttypes:"Html;Badges"
    echo "📊 Coverage report generated at TestResults/CoverageReport/index.html"
fi

echo "✅ Build and test completed successfully!"
