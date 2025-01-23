@echo off

set ModuleRef=%~1

set /p ClassPath=<ClassPath.txt

set SourceFold=.\Gen\%ModuleRef%

move %SourceFold%\%ModuleRef%.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL