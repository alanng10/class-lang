@echo off

call Script\Infra\Var

set InfraDemoOutFold=.\Out\InfraDemo-Windows-Release
rmdir /S /Q %InfraDemoOutFold% 2>NUL