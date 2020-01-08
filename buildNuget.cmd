SET PACKAGE_VERSION="0.1.0"

dotnet build src -c release
mkdir .\src\nuget
dotnet pack src/SqlAsFile/SqlAsFile.csproj -c release --no-build --output ../nuget /p:PackageVersion=%PACKAGE_VERSION%