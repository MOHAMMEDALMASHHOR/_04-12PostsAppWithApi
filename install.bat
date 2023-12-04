dotnet new sln -n BlogApp

dotnet new webapi -o BlogApi
dotnet new classlib -o BlogRepository
dotnet new classlib -o BlogEntity

dotnet sln BlogApp.sln add BlogApi
dotnet sln BlogApp.sln add BlogRepository
dotnet sln BlogApp.sln add BlogEntity

dotnet add BlogRepository reference BlogEntity
dotnet add BlogApi reference BlogRepository
dotnet add BlogApi reference BlogEntity

code .