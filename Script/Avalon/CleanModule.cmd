@echo off

echo Clean Module
set AvalonModuleOutFold=.\Out\net8.0
del /F /Q %AvalonModuleOutFold%\Avalon.* 2>NUL
del /F /Q %AvalonModuleOutFold%\MakePackage.* 2>NUL