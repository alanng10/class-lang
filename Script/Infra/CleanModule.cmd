@echo off

call Script\Infra\Var

set InfraPackageOutFold=.\Out\Infra-Windows-Release
rmdir /S /Q %InfraPackageOutFold% 2>NUL