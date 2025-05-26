@echo off

set ModuleRef=%~1

set SourceFold=.\Gen\%ModuleRef%

move %SourceFold%\%ModuleRef%.exe "..\%ClassPath%\%ModuleRef%.exe" >NUL