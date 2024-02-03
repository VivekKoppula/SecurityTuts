
cd ../../..

cd src/tasks/205350-WebAppCallSecureApi

pwd

################################################################################################

dotnet build ./../../apps/205350-WebAppCallSecureApi/WebAppCallSecureApi.sln

dotnet run --project ./../../apps/205350-WebAppCallSecureApi/SecureApi/SecureApi.csproj

# Open a new terminal.

cd src/tasks/205350-WebAppCallSecureApi

dotnet run --project ./../../apps/205350-WebAppCallSecureApi/WebApp/WebApp.csproj

################################################################################################

cd ../../..

cd src/apps/205350-WebAppCallSecureApi/

Set-Location WebApp

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./../WebAppCallSecureApi.sln

dotnet run --project ./../SecureApi/SecureApi.csproj

# Open a new terminal.

cd src/tasks/205350-WebAppCallSecureApi

dotnet run --project ./../../apps/205350-WebAppCallSecureApi/WebApp/WebApp.csproj

################################################################################################


