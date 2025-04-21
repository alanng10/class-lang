@echo off

call Script\Infra\Var

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release
rmdir /S /Q %InfraDemoPackageOutFold% 2>NUL