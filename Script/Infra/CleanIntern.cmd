@echo off

call Script\Infra\Var

set InfraInternOutFold=.\Out\InfraIntern-Windows-Release
rmdir /S /Q %InfraInternOutFold% 2>NUL