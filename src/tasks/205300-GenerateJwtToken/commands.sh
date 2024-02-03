
cd ../../..

cd src/tasks/205300-GenerateJwtToken

pwd

################################################################################################

# If you want to create the project from scratch.

# First cd into the correct folder. Ensure first the folder is present.
cd ./../../apps/205300-GenerateJwtToken/

dotnet new sln --name GenerateJwtToken

dotnet new webapi --name GenerateJwtToken --framework net6.0

Copy-Item ./GenerateJwtToken/* . -Recurse

# Now that we have copied all of the items inside of the folder, we can delete all of the items inside of it and the folder itself.
Remove-Item ./GenerateJwtToken -Recurse

dotnet sln add GenerateJwtToken.csproj

dotnet build ./GenerateJwtToken.csproj

dotnet run --project ./GenerateJwtToken.csproj

# If you want to remove, un comment the following and execute to clean up the folder
# Remove-Item ./* -Recurse

# Now come back to the exercise folder.
cd ./../../tasks/205300-GenerateJwtToken/

dir

dotnet add package System.IdentityModel.Tokens.Jwt 

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

################################################################################################

dotnet build ./../../apps/205300-GenerateJwtToken/GenerateJwtToken.csproj

dotnet run --project ./../../apps/205300-GenerateJwtToken/GenerateJwtToken.csproj

# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

