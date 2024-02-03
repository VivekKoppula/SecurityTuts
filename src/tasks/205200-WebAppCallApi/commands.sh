
cd ../../..

cd src/tasks/205200-WebAppCallApi

pwd

################################################################################################

dotnet build ./../../apps/205200-WebAppCallApi/WebAppCallApi.sln

dotnet run --project ./../../apps/205200-WebAppCallApi/WebApi/WebApi.csproj

# Open a new terminal.

cd src/tasks/205200-WebAppCallApi

dotnet run --project ./../../apps/205200-WebAppCallApi/WebApp/WebApp.csproj


# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

################################################################################################

cd ../../..

cd src/apps/205200-WebAppCallApi

Set-Location WebApp

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

dotnet build ./../../apps/205200-WebAppCallApi/WebAppCallApi.sln

dotnet run --project ./../../apps/205200-WebAppCallApi/WebApi/WebApi.csproj

# Open a new terminal.

cd src/tasks/205200-WebAppCallApi

dotnet run --project ./../../apps/205200-WebAppCallApi/WebApp/WebApp.csproj

################################################################################################

