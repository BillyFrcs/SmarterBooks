# Visual Studio:
# Run Database Migration
add-migration MigrationName

# Update Database Migration
update-database

# Visual Studio Code:
# Run Database Migration
dotnet ef migrations add MigrationName --project ProjectName

# Update Database Migration
dotnet ef database update --project ProjectName
