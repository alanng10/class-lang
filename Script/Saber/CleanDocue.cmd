@echo off

echo Clean Docue
set DotNetModuleOutFold=.\Out\net8.0
del /F /Q %DotNetModuleOutFold%\Saber.Docue.* 2>NUL
del /F /Q %DotNetModuleOutFold%\SaberDocueExe* 2>NUL
rmdir /S /Q %DotNetModuleOutFold%\Saber.Docue.data 2>NUL