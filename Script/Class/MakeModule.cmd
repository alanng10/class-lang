@echo off

echo Make Module
echo:
set DotNetModuleOutFold=.\Out\net6.0
pushd Class\ClassExe
dotnet build -v quiet
popd
pushd %DotNetModuleOutFold%
del /F /Q class.exe 2>NUL
rename ClassExe.exe class.exe
popd