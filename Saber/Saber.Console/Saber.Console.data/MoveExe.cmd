@echo off

set ModuleRef=%~1

set SourceFold=.\Gen\Exe-%ModuleRef%

move %SourceFold%\%ModuleRef%.exe "..\%ClassPath%\Module\%ModuleRef%.exe" >NUL