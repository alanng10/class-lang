@echo off

call Var

set Module=%~1
set Import=%~2

call DeleteBinary %Module%
call DeleteOutFold %Module%
call MakeLib %Module% "%Import%"
rem call MakeModuleProject %Module%
rem call MakeModule %Module%
call MoveBinary %Module%
call DeleteOutFold %Module%