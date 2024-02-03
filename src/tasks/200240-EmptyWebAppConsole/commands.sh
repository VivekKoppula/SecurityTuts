
cd ../../..

cd src/tasks/200240-EmptyWebAppConsole

pwd

start ./../../apps/200240-EmptyWebAppConsole/EmptyWebAppConsole.sln

dotnet build ./../../apps/200240-EmptyWebAppConsole/EmptyWebAppConsole.sln

dotnet build ./../../apps/200240-EmptyWebAppConsole/EmptyWebAppConsole.csproj

dotnet run --project ./../../apps/200240-EmptyWebAppConsole/EmptyWebAppConsole.csproj

cd ./../../apps/200240-EmptyWebAppConsole/

dotnet run --project ./EmptyWebAppConsole.csproj

