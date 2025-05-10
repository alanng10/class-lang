@echo off

call Var

set Module=%~1

set /p ClassPath=<ClassPath.txt

call DeleteLib %Module%
rem call DeleteOutFold %Module%
call MakeLib %Module%
call MoveLib %Module%
rem call MakeModuleProject %Module%
rem call MakeModule %Module%
rem call MoveBinary %Module%
rem call DeleteOutFold %Module%