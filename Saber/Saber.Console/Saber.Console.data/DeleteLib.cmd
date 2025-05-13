@echo off

set ModuleRef=%~1

del /F /Q "..\%ClassPath%\%ModuleRef%.dll" 2>NUL