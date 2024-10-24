@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Gen\%ModuleRef%-Out
set DeployFold=..

copy /Y %ProjectOutFold%\release\%ModuleRef%.dll %DeployFold%