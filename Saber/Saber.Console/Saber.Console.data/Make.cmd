@echo off

call Script\Infra\Var

set ModuleRef=%~1

call Saber.Console.data\CleanModule %ModuleRef%
call Saber.Console.data\MakeModuleProject %ModuleRef%
call Saber.Console.data\MakeModule %ModuleRef%