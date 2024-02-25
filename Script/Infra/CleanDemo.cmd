@echo off

call Script\Infra\Var

set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release
rmdir /S /Q %InfraDemoProjectOutFold% 2>NUL