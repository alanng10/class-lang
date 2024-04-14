@echo off

echo Clean Test
set DotNetModuleOutFold=.\Out\net8.0
del /F /Q %DotNetModuleOutFold%\ClassTest* 2>NUL