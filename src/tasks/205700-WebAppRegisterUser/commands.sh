
cd ../../..

cd src/tasks/205700-WebAppRegisterUser

pwd

################################################################################################

dotnet build ./../../apps/205700-WebAppRegisterUser/WebAppRegisterUser.sln

dotnet run --project ./../../apps/205700-WebAppRegisterUser/WebAppRegisterUser.csproj

################################################################################################

cd ../../..

cd src/apps/205700-WebAppRegisterUser/

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./WebAppRegisterUser.sln

dotnet run --project ./WebAppRegisterUser.csproj

# Open a new terminal.

cd src/tasks/205700-WebAppRegisterUser

dotnet run --project ./../../apps/205700-WebAppRegisterUser/WebAppRegisterUser.csproj

################################################################################################

# https://learn.microsoft.com/en-us/ef/core/cli/dotnet#update-the-tools

# Ensure a database is created before executing the following migration commands.
# You can use the following command. CREATE DATABASE AspNetCoreId. If you want to drop and recreate, then 
# DROP DATABASE AspNetCoreId

cd src/apps/205700-WebAppRegisterUser/

dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialMigration

dotnet ef database update InitialMigration

dotnet run --project ./WebAppRegisterUser.csproj
