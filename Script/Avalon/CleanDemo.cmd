@echo off

echo Clean Demo
set AvalonModuleOutFold=.\Out\net8.0
del /F /Q %AvalonModuleOutFold%\Demo.* 2>NUL
del /F /Q %AvalonModuleOutFold%\DemoNetwork.* 2>NUL
rmdir /S /Q %AvalonModuleOutFold%\DemoData 2>NUL