@echo off

call Script\Infra\Var

set InfraInternOutFold=.\Out\InfraIntern-Windows-Release\release
set InfraDeployFold=.\Out\InfraDeploy
mkdir %InfraDeployFold% 1>NUL 2>NUL
copy /Y %InfraInternOutFold%\InfraIntern.dll %InfraDeployFold%