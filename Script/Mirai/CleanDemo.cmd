@echo off

echo Clean Demo
set AvalonModuleOutFold=.\Out\net8.0
del /F /Q %AvalonModuleOutFold%\MiraiDemo.* 2>NUL
rmdir /S /Q %AvalonModuleOutFold%\MiraiDemoData 2>NUL