#!/bin/bash

echo "Resetting LifeLedger database..."

# Drop and recreate database
docker-compose exec postgres psql -U postgres -c "DROP DATABASE IF EXISTS \"LifeLedger\";"
docker-compose exec postgres psql -U postgres -c "CREATE DATABASE \"LifeLedger\";"

# Run migrations
dotnet ef database update --project src/LifeLedger.Infrastructure --startup-project src/LifeLedger.Web

echo "✅ Database reset complete!"
