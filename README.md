# N-Tier-Demo-with-Improved-Repository-Pattern
This is N-tier project demo with improved repository pattern implemented with DB setup project in .NET 7.

# How to use Setup project with other projects.
Setup is lib project that will act as a console project, and it'll apply any pending migrations to the database. But to make sure that it'll work properly within your other projects, replace "ApiDbContext", and "ConnectionString" in program.cs with you DbContext and ConnectionString.