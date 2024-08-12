@echo off

call Script\Infra\Var

set InfraInternProjectOutFold=.\Out\InfraIntern-Windows-Release
rmdir /S /Q %InfraInternProjectOutFold% 2>NUL