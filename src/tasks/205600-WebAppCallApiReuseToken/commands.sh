
cd ../../..

cd src/tasks/205600-WebAppCallApiReuseToken

pwd

################################################################################################

dotnet build ./../../apps/205600-WebAppCallApiReuseToken/WebAppCallApiReuseToken.sln

dotnet run --project ./../../apps/205600-WebAppCallApiReuseToken/SecureApi/SecureApi.csproj

# Open a new terminal.

cd src/tasks/205600-WebAppCallApiReuseToken

dotnet run --project ./../../apps/205600-WebAppCallApiReuseToken/WebApp/WebApp.csproj

################################################################################################

cd ../../..

cd src/apps/205600-WebAppCallApiReuseToken/

Set-Location WebApp

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./../WebAppCallApiReuseToken.sln

dotnet run --project ./../SecureApi/SecureApi.csproj

# Open a new terminal.

cd src/tasks/205600-WebAppCallApiReuseToken

dotnet run --project ./../../apps/205600-WebAppCallApiReuseToken/WebApp/WebApp.csproj

################################################################################################

