@echo off

echo Make Demo
echo:
pushd Avalon\Demo
dotnet build -v quiet
popd