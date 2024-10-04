@echo off

echo Clean Module
set AvalonModuleOutFold=.\Out\net8.0
del /F /Q %AvalonModuleOutFold%\Mirai.* 2>NUL