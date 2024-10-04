@echo off

pushd Out\net8.0
dotnet ClassTestExe.dll
echo Status: %errorlevel%
popd