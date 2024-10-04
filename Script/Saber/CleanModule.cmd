@echo off

echo Clean Module
set DotNetModuleOutFold=.\Out\net8.0
del /F /Q %DotNetModuleOutFold%\Saber.* 2>NUL
del /F /Q %DotNetModuleOutFold%\SaberExe* 2>NUL
rmdir /S /Q %DotNetModuleOutFold%\Saber.Console.data 2>NUL
rmdir /S /Q %DotNetModuleOutFold%\Saber.Doc.data 2>NUL