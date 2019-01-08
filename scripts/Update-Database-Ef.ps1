param([string] $MigrationName)

Write-Host -ForegroundColor green Updating database...
Push-Location
Set-Location ..\src\CookBook.Infrastructure
dotnet ef database update $MigrationName --startup-project ..\CookBook.Api
Pop-Location 