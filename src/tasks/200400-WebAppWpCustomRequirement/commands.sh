
cd ../../..

cd src/tasks/200400-WebAppWpCustomRequirement

pwd

################################################################################################

dotnet build ./../../apps/200400-WebAppWpCustomRequirement/WebAppWpCustomRequirement.csproj

dotnet run --project ./../../apps/200400-WebAppWpCustomRequirement/WebAppWpCustomRequirement.csproj

# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

################################################################################################

cd ../../..

cd src/apps/200400-WebAppWpCustomRequirement

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

dotnet build ./WebAppWpCustomRequirement.csproj

dotnet run --project ./WebAppWpCustomRequirement.csproj

