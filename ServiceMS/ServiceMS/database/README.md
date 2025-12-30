psql "host=localhost port=5432 dbname=techservice user=postgres password=postgres" -f database/001_schema.sql

dotnet ef dbcontext scaffold \
"Host=localhost;Port=5432;Database=techservice;Username=postgres;Password=postgres" \
Npgsql.EntityFrameworkCore.PostgreSQL \
--output-dir Models/Db \
--context AppDbContext \
--context-dir Data \
--use-database-names \
--no-onconfiguring \
--force \
--no-build