@echo off

echo Clean Demo
set AvalonModuleOutFold=.\Out\net6.0
del /F /Q %AvalonModuleOutFold%\Demo.* 2>NUL
rmdir /S /Q %AvalonModuleOutFold%\DemoData 2>NUL