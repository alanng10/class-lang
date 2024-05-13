@echo off

pushd Out\net8.0
dotnet ClassExe.dll doc "Doc" "Out/Doc"
echo Status: %errorlevel%
popd