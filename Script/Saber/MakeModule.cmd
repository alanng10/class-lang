@echo off

echo Make Module
set DotNetModuleOutFold=.\Out\net8.0
pushd Class\ClassExe
dotnet build -v quiet
popd
pushd %DotNetModuleOutFold%
del /F /Q class.exe 2>NUL
rename Class.Console-ExeCon.exe class.exe
popd