@echo off

call Var

set Module=%~1

call CleanModule %Module%
call MakeModuleProject %Module%
call MakeModule %Module%
call CopyBinary %Module%
call CleanModule %Module%