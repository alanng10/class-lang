@echo off

echo Make Module
echo:
pushd Class\ClassTestExe
dotnet build -v quiet
popd