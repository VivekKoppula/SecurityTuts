
cd ../../..

cd src/tasks/205500-AspNetCoreSessionIntro

pwd

################################################################################################

cd ../../..

cd src/apps/205500-AspNetCoreSessionIntro

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

dotnet build ./AspNetCoreSessionIntro.csproj

dotnet run --project ./AspNetCoreSessionIntro.csproj

################################################################################################

dotnet build ./../../apps/205500-AspNetCoreSessionIntro/AspNetCoreSessionIntro.csproj

dotnet run --project ./../../apps/205500-AspNetCoreSessionIntro/AspNetCoreSessionIntro.csproj

# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

################################################################################################
