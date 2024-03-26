@echo off

set ModuleName=Z.Make.Avalon
pushd Tool\%ModuleName%
dotnet build
popd