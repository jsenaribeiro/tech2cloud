@echo off

if "%1"=="drop" (goto :remove)
if "%1"=="add" (goto :migrate)
if "%1"=="up" (goto :update)

echo.
echo --------------- ef-sync script -------------------
echo --------------------------------------------------
echo ef-sync drop : remove last migration
echo ef-sync add [description] : add a migration
echo ef-sync up: update database with the migrations
echo --------------------------------------------------
goto :eof

:remove

dotnet ef migrations remove --startup-project ..\Ambev.DeveloperEvaluation.WebApi
goto :eof

:migrate

if "%2"=="" (
   echo fail! pass the migration historicalMigrationTitle
   goto :eof
)

dotnet ef migrations add %2 --startup-project ..\Ambev.DeveloperEvaluation.WebApi
echo migrated...
goto :eof

:update

dotnet ef database update --startup-project ..\Ambev.DeveloperEvaluation.WebApi
echo updated...
goto :eof

:ignore
echo ignored...

:eof