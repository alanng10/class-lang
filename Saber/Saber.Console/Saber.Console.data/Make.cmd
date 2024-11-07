@echo off

call Var

set ClassPath=%~1
set Module=%~2

call DeleteOutFold %Module%
call MakeModuleProject %Module%
call MakeModule %Module%
call MoveBinary %Module%
call DeleteOutFold %Module%