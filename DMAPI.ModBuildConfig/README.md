# DMAPI.ModBuildConfig

- Auto detect game path
- Auto reference dll required during mod developing
- Auto deploy mod locally after building

## Thanks

Inspired by [Pathoschild's SMAPI ModBuildConfig](https://github.com/Pathoschild/SMAPI)

## How to use

simply reference the NeGet package

command line: `dotnet add package TWT233.DMAPI.ModBuildConfig`

or add it to your csproj file:

```msbuild
<Project Sdk="Microsoft.NET.Sdk">
    <!-- ... other stuff ... -->
    
    <ItemGroup>
        <PackageReference Include="TWT233.DMAPI.ModBuildConfig"/>
    </ItemGroup>

    <!-- ... other stuff ... -->
</Project>
```