@echo off

echo Make Module
echo:
set DotNetModuleOutFold=.\Out\net6.0
pushd Class\ClassExe
dotnet build -v quiet
popd
pushd %DotNetModuleOutFold%
del /F /Q Class.exe 2>NUL
rename ClassExe.exe Class.exe
popd