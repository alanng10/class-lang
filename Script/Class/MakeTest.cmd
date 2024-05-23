@echo off

echo Make Test
pushd Class\ClassTestExe
dotnet build -v quiet
popd