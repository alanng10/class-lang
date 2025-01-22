@echo off

set ModuleRef=%~1

set /p ClassPath=<ClassPath.txt

set ProjectOutFold=.\Gen\%ModuleRef%-Out

del /F /Q "..\%ClassPath%\%ModuleRef%.dll" 2>NUL

move %ProjectOutFold%\release\%ModuleRef%.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL