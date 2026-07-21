@echo off
echo BUILD Cadmus Geo Packages
del .\Cadmus.Geo.Parts\bin\Release\*.snupkg
del .\Cadmus.Geo.Parts\bin\Release\*.nupkg

del .\Cadmus.Seed.Geo.Parts\bin\Release\*.snupkg
del .\Cadmus.Seed.Geo.Parts\bin\Release\*.nupkg

cd .\Cadmus.Geo.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Geo.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
