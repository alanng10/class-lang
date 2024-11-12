@echo off

echo Deploy Execute

set ClassOutFold=.\Out\Class
set InfraExecuteOutFold=.\Out\InfraExecute-Windows-Release\release

copy /Y %InfraExecuteOutFold%\class.exe %ClassOutFold% 1>NUL 2>NUL