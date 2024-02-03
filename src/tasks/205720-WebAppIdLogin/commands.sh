
cd ../../..

cd src/tasks/205720-WebAppIdLogin

pwd

################################################################################################

dotnet build ./../../apps/205720-WebAppIdLogin/WebAppIdLogin.sln

dotnet run --project ./../../apps/205720-WebAppIdLogin/WebAppIdLogin.csproj

################################################################################################

cd ../../..

cd src/apps/205720-WebAppIdLogin/

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./WebAppIdLogin.sln

dotnet run --project ./WebAppIdLogin.csproj

# Open a new terminal.

cd src/tasks/205720-WebAppIdLogin

dotnet run --project ./../../apps/205720-WebAppIdLogin/WebAppIdLogin.csproj

################################################################################################

# https://learn.microsoft.com/en-us/ef/core/cli/dotnet#update-the-tools

# Ensure a database is created before executing the following migration commands.
# You can use the following command. CREATE DATABASE AspNetCoreId. If you want to drop and recreate, then 
# DROP DATABASE AspNetCoreId

cd src/apps/205720-WebAppIdLogin/

dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialMigration

dotnet ef database update InitialMigration

dotnet run --project ./WebAppIdLogin.csproj


