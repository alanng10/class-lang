@echo off

pushd Out\net6.0
dotnet Class.Test.Exe.dll
echo Status: %errorlevel%
popd