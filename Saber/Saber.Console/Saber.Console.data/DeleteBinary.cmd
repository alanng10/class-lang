@echo off

set ModuleRef=%~1

set /p ClassPath=<ClassPath.txt

del /F /Q "..\%ClassPath%\%ModuleRef%.dll" 2>NUL