@echo off

pushd Out\net8.0
dotnet MiraiDemo.dll
echo Status: %errorlevel%
popd