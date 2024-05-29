@echo off

echo Clean Binary
set DotNetModuleOutFold=.\Out\net8.0
del /F /Q %DotNetModuleOutFold%\*.ref 2>NUL