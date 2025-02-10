@echo off

set ModuleRef=%~1

set SourceFold=.\Gen\%ModuleRef%

move %SourceFold%\%ModuleRef%.dll "..\%ClassPath%\Module\%ModuleRef%.dll" >NUL