@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Gen\%ModuleRef%-Out
set DeployFold=..

move %ProjectOutFold%\release\Module.dll %DeployFold%\%ModuleRef%.dll >NUL