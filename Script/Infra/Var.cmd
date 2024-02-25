@echo off

set VarIsSet=0
set WorkingFold=%cd%

if "%QtRoot%" == "" (
    set QtRoot=C:\Users\aaabb\Qt
    set VarIsSet=1
)

if "%VarIsSet%" == "1" (
    call "%QtRoot%\6.6.1\mingw_64\bin\qtenv2.bat"
    cd "%WorkingFold%"
)