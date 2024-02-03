
cd ../../..

cd src/tasks/200420-WebAppWpCookieExpiry

pwd

################################################################################################

dotnet build ./../../apps/200420-WebAppWpCookieExpiry/WebAppWpCookieExpiry.csproj

dotnet run --project ./../../apps/200420-WebAppWpCookieExpiry/WebAppWpCookieExpiry.csproj

# Once the app is up and running, browse it, then go to the login page. Enter creds.
# See them in the Terminal.

################################################################################################

cd ../../..

cd src/apps/200420-WebAppWpCookieExpiry

Set-Location ClientApp

npm install

npm run wpbuild

Set-Location ..

dotnet build ./WebAppWpCookieExpiry.csproj

dotnet run --project ./WebAppWpCookieExpiry.csproj

################################################################################################

