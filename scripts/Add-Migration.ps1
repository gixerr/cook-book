param([string] $MigrationName)

Write-Host -ForegroundColor green "Adding migration:" $MigrationName
Push-Location
Set-Location ..\src\CookBook.Infrastructure
dotnet ef migrations add $MigrationName --startup-project ..\CookBook.Api
Pop-Location