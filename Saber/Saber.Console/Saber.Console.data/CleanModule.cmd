@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Gen\%ModuleRef%-Out

rmdir /S /Q %ProjectOutFold% 2>NUL