@echo off

echo Make Demo
pushd Avalon\Demo
dotnet build -v quiet
popd