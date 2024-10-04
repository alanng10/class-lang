@echo off

echo Clean Test
set DotNetModuleOutFold=.\Out\net8.0
del /F /Q %DotNetModuleOutFold%\SaberTest* 2>NUL