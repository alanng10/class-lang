@echo off

echo Clean Module
set AvalonModuleOutFold=.\Out\net6.0
del /F /Q %AvalonModuleOutFold%\Avalon.*
del /F /Q %AvalonModuleOutFold%\MakeProject.*
rmdir /S /Q %AvalonModuleOutFold%\Lib