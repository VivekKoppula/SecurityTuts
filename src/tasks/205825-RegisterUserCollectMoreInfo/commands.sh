
cd ../../..

cd src/tasks/205825-RegisterUserCollectMoreInfo

pwd

# Ensure docker is up and running, fire up docker desktop
docker-compose up -d mailhog

# If you want to tear that donw, use the following
docker-compose down

# Now browse to localhost:8025
start http://localhost:8025

################################################################################################

dotnet build ./../../apps/205825-RegisterUserCollectMoreInfo/RegisterUserCollectMoreInfo.sln

dotnet run --project ./../../apps/205825-RegisterUserCollectMoreInfo/RegisterUserCollectMoreInfo.csproj

################################################################################################

cd ../../..

cd src/apps/205825-RegisterUserCollectMoreInfo/

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

pwd

dotnet build ./RegisterUserCollectMoreInfo.sln

dotnet run --project ./RegisterUserCollectMoreInfo.csproj

################################################################################################

# https://learn.microsoft.com/en-us/ef/core/cli/dotnet#update-the-tools

# Ensure a database is created before executing the following migration commands.
# You can use the following command. CREATE DATABASE AspNetCoreId. If you want to drop and recreate, then 
# DROP DATABASE AspNetCoreId

cd ../../..

cd src/apps/205825-RegisterUserCollectMoreInfo/

dotnet tool update --global dotnet-ef

dotnet ef migrations add AddMoreInfo

dotnet ef migrations list

dotnet ef database update AddMoreInfo

dotnet run --project ./RegisterUserCollectMoreInfo.csproj

