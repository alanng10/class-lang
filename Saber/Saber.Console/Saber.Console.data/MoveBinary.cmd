@echo off

set ModuleRef=%~1

set /p ClassPath=<ClassPath.txt

set ProjectOutFold=.\Gen\%ModuleRef%-Out

move %ProjectOutFold%\release\Module.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL