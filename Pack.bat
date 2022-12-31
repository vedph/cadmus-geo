@echo off
echo BUILD Cadmus Geo Packages
del .\Cadmus.Geo.Parts\bin\Debug\*.snupkg
del .\Cadmus.Geo.Parts\bin\Debug\*.nupkg

del .\Cadmus.Seed.Geo.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.Geo.Parts\bin\Debug\*.nupkg

cd .\Cadmus.Geo.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Geo.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
