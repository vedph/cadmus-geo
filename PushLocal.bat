@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Geo.Parts\bin\Release\Cadmus.Geo.Parts.6.0.3.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Geo.Parts\bin\Release\Cadmus.Seed.Geo.Parts.6.0.4.nupkg -source C:\Projects\_NuGet
pause
