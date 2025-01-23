@echo off

call Var

set Module=%~1

call DeleteBinary %Module%
rem call DeleteOutFold %Module%
call MakeLib %Module%
call MoveLib %Module%
rem call MakeModuleProject %Module%
rem call MakeModule %Module%
rem call MoveBinary %Module%
rem call DeleteOutFold %Module%