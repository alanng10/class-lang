@echo off

call Script\Infra\Var

set InfraExecuteProjectOutFold=.\Out\InfraExecute-Windows-Release
rmdir /S /Q %InfraExecuteProjectOutFold% 2>NUL