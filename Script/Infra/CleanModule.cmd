@echo off

call Script\Infra\Var

set InfraOutFold=.\Out\Infra-Windows-Release
rmdir /S /Q %InfraOutFold% 2>NUL