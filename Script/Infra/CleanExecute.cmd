@echo off

call Script\Infra\Var

set InfraExecutePackageOutFold=.\Out\InfraExecute-Windows-Release
rmdir /S /Q %InfraExecutePackageOutFold% 2>NUL