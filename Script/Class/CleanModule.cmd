@echo off

echo Clean Module
set DotNetModuleOutFold=.\Out\net6.0
del /F /Q %DotNetModuleOutFold%\Class.* 2>NUL
del /F /Q %DotNetModuleOutFold%\ClassExe* 2>NUL