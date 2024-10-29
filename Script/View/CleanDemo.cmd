@echo off

echo Clean Demo
set AvalonModuleOutFold=.\Out\net8.0
del /F /Q %AvalonModuleOutFold%\ViewDemo.* 2>NUL
rmdir /S /Q %AvalonModuleOutFold%\ViewDemoData 2>NUL