@echo off

echo Make Module
pushd Avalon\MakePackage
dotnet build -v quiet
popd
