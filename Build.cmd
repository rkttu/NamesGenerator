@echo off
pushd "%~dp0"

if exist RedistPackages rd /s /q RedistPackages
if not exist RedistPackages mkdir RedistPackages

set projectname=NamesGenerator
.nuget\NuGet.exe pack %projectname%\%projectname%.csproj -IncludeReferencedProjects -Build -Symbols -OutputDirectory RedistPackages -Verbosity detailed -Properties Configuration=Release
.nuget\NuGet.exe push RedistPackages\%projectname%.*.nupkg -Source "https://www.nuget.org/api/v2/package"

pause
popd
@echo on