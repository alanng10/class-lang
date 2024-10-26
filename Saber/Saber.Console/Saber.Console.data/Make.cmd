@echo off

call Var

set Module=%~1

call DeleteOutFold %Module%
call MakeModuleProject %Module%
call MakeModule %Module%
call MoveBinary %Module%
call DeleteOutFold %Module%