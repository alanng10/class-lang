@echo off

echo Make Module
set DotNetModuleOutFold=.\Out\net8.0
pushd Class\SaberExe
dotnet build -v quiet
popd
pushd %DotNetModuleOutFold%
del /F /Q saber.exe 2>NUL
rename Saber.Console-ExeCon.exe saber.exe
popd