@echo off

set ClassPath=%~1
set ModuleRef=%~2

set ProjectOutFold=.\Gen\%ModuleRef%-Out

move %ProjectOutFold%\release\Module.dll "..\%ClassPath%\%ModuleRef%.dll" >NUL