@echo off

set ModuleRef=%~1

del /F /Q "..\%ClassPath%\Module\%ModuleRef%.dll" 2>NUL