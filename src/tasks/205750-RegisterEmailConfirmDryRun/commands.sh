
cd ../../..

cd src/tasks/205750-RegisterEmailConfirmDryRun

pwd

################################################################################################

dotnet build ./../../apps/205750-RegisterEmailConfirmDryRun/RegisterEmailConfirmDryRun.sln

dotnet run --project ./../../apps/205750-RegisterEmailConfirmDryRun/RegisterEmailConfirmDryRun.csproj

################################################################################################

cd ../../..

cd src/apps/205750-RegisterEmailConfirmDryRun/

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./RegisterEmailConfirmDryRun.sln

dotnet run --project ./RegisterEmailConfirmDryRun.csproj

################################################################################################

# https://learn.microsoft.com/en-us/ef/core/cli/dotnet#update-the-tools

# Ensure a database is created before executing the following migration commands.
# You can use the following command. CREATE DATABASE AspNetCoreId. If you want to drop and recreate, then 
# DROP DATABASE AspNetCoreId

cd src/apps/205750-RegisterEmailConfirmDryRun/

dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialMigration

dotnet ef database update InitialMigration

dotnet run --project ./RegisterEmailConfirmDryRun.csproj

