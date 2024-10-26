@echo off

call Var

set Module=%~1

call CleanOutFold %Module%
call MakeModuleProject %Module%
call MakeModule %Module%
call MoveBinary %Module%
call CleanOutFold %Module%