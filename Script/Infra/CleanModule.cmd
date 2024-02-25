@echo off

call Script\Infra\Var

set InfraProjectOutFold=.\Out\Infra-Windows-Release
rmdir /S /Q %InfraProjectOutFold%