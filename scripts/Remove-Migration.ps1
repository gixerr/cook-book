Write-Host -ForegroundColor green "Removing migration..."
Push-Location
Set-Location ..\src\CookBook.Infrastructure
dotnet ef migrations remove --startup-project ..\CookBook.Api
Pop-Location