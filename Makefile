build:
	dotnet build

buildRelease:
	dotnet build --configuration Release

publish:
	dotnet publish -r win-x64 -c Release --self-contained
