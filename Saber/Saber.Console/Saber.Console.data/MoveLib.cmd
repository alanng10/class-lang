@echo off

set ModuleRef=%~1

set SourceFold=.\Gen\%ModuleRef%

move %SourceFold%\%ModuleRef%.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL