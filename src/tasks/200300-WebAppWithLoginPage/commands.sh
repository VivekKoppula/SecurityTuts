
cd ../../..

cd src/tasks/200300-WebAppWithLoginPage

pwd

################################################################################################

# If you want to create the project from scratch. We will not be using this approach. We will be using web pack approach.

# First cd into the correct folder. Ensure first the folder is present.
cd ./../../apps/200300-WebAppWithLoginPage/

dotnet new sln --name WebAppWithLoginPage 

dotnet new webapp --name WebAppWithLoginPage --framework net6.0

Copy-Item ./WebAppWithLoginPage/* . -Recurse

# Now that we have copied all of the items inside of the folder, we can delete all of the items inside of it and the folder itself.
Remove-Item ./WebAppWithLoginPage -Recurse

dotnet sln add WebAppWithLoginPage.csproj

dotnet build ./WebAppWithLoginPage.csproj

dotnet run --project ./WebAppWithLoginPage.csproj

# If you want to remove, un comment the following and execute to clean up the folder
# Remove-Item ./* -Recurse

# Now come back to the exercise folder.
cd ./../../tasks/200300-WebAppWithLoginPage/

################################################################################################

# The web pack approach.

cd ../../..

cd src/apps/200300-WebAppWithLoginPage

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

dotnet build ./WebAppWithLoginPage.csproj

dotnet run --project ./WebAppWithLoginPage.csproj

################################################################################################

dotnet build ./../../apps/200300-WebAppWithLoginPage/WebAppWithLoginPage.csproj

dotnet run --project ./../../apps/200300-WebAppWithLoginPage/WebAppWithLoginPage.csproj

# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

