@echo off

set ModuleRef=%~1

del /F /Q "..\%ClassPath%\%ModuleRef%.exe" 2>NUL