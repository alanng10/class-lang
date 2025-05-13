@echo off

call Var

set Module=%~1

set /p ClassPath=<ClassPath.txt

call DeleteLibExe %Module%
call MakeLibExe %Module%
call MoveLibExe %Module%