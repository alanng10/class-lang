@echo off

set ModuleRef=%~1

del /F /Q "..\%ClassPath%\Module\%ModuleRef%.exe" 2>NUL