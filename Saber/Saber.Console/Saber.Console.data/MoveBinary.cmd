@echo off

set ModuleRef=%~1

set /p ClassPath=<ClassPath.txt

set ProjectOutFold=.\Gen\%ModuleRef%-Out

move %ProjectOutFold%\release\%ModuleRef%.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL