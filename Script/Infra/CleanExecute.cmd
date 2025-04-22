@echo off

call Script\Infra\Var

set InfraExecuteOutFold=.\Out\InfraExecute-Windows-Release
rmdir /S /Q %InfraExecuteOutFold% 2>NUL