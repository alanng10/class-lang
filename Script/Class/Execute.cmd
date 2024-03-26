@echo off

pushd Out\net6.0
dotnet ClassTestExe.dll
echo Status: %errorlevel%
popd