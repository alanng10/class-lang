@echo off

echo Clean Module
set DotNetModuleOutFold=.\Out\net6.0
del /F /Q %DotNetModuleOutFold%\Class.*.dll 2>NUL
del /F /Q %DotNetModuleOutFold%\ClassTest* 2>NUL