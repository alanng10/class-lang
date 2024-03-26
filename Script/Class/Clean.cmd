@echo off

echo Clean
set DotNetModuleOutFold=.\Out\net6.0
del /F /Q %DotNetModuleOutFold%\Class.* 2>NUL