@echo off

call Var

set Module=%~1

set /p ClassPath=<ClassPath.txt

call DeleteLib %Module%
call MakeLib %Module%
call MoveLib %Module%