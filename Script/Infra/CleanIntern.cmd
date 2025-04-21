@echo off

call Script\Infra\Var

set InfraInternPackageOutFold=.\Out\InfraIntern-Windows-Release
rmdir /S /Q %InfraInternPackageOutFold% 2>NUL