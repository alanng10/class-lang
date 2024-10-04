@echo off

pushd Out\net8.0
dotnet SaberTestExe.dll
echo Status: %errorlevel%
popd