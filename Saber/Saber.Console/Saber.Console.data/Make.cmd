@echo off

call Var

set Module=%~1
set Import=%~2

call DeleteBinary %Module%
rem call DeleteOutFold %Module%
call MakeLib %Module% "%Import%"
call MoveLib %Module%
rem call MakeModuleProject %Module%
rem call MakeModule %Module%
rem call MoveBinary %Module%
rem call DeleteOutFold %Module%