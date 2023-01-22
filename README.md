# Play.Common
Common libraries used by platform services.

## Create and publish package
```powershell
$version="0.0.1"
$local_packages_path="D:\Dev\NugetPackages"
$baget_key="KEY HERE"

dotnet pack src\PlatformCommon --configuration Release -p:PackageVersion=$version -o $local_packages_path

dotnet nuget push $local_packages_path\PlatformCommon.$version.nupkg --api-key $baget_key --source baget
```