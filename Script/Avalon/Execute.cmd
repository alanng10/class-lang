@echo off

pushd Out\net8.0
dotnet Demo.dll < ..\..\Avalon\Input.txt
echo Status: %errorlevel%
popd