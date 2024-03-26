@echo off

pushd Out\net6.0
dotnet Demo.dll < ..\..\Avalon\Input.txt
echo Status: %errorlevel%
popd