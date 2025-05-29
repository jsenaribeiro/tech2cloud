@echo off

if "%1"=="" ( echo nada ) else ( 

   dotnet ef migrations add %1 ^
      --startup-project Ambev.DeveloperEvaluation.WebApi
)