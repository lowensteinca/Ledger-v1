#!/bin/bash

echo "Resetting Ledger database..."

# Drop and recreate database
docker-compose exec postgres psql -U postgres -c "DROP DATABASE IF EXISTS \"Ledger\";"
docker-compose exec postgres psql -U postgres -c "CREATE DATABASE \"Ledger\";"

# Run migrations
dotnet ef database update --project src/Ledger.Infrastructure --startup-project src/Ledger.Web

echo "✅ Database reset complete!"
