@echo off

call Var

set ModuleRef=%~1

call CleanModule %ModuleRef%
call MakeModuleProject %ModuleRef%
call MakeModule %ModuleRef%