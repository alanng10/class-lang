@echo off

echo Make Test
echo:
pushd Class\ClassTestExe
dotnet build -v quiet
popd