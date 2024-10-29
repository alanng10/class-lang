@echo off

pushd Out\net8.0
dotnet ViewDemo.dll
echo Status: %errorlevel%
popd