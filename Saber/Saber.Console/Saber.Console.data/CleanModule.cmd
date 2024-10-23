@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Saber.Console.data\Gen\%ModuleRef%-Out

rmdir /S /Q %ProjectOutFold% 2>NUL