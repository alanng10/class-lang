@echo off

echo Clean Module
set AvalonModuleOutFold=.\Out\net6.0
del /F /Q %AvalonModuleOutFold%\Avalon.* 2>NUL
del /F /Q %AvalonModuleOutFold%\MakeProject.* 2>NUL
rmdir /S /Q %AvalonModuleOutFold%\Avalon.Intern.data 2>NUL