@echo off

call Script\Infra\Var

set InfraOutFold=.\Out\Infra-Windows-Release\release
set InfraDeployFold=.\Out\InfraDeploy
mkdir %InfraDeployFold% 1>NUL 2>NUL
copy /Y %InfraOutFold%\Infra.dll %InfraDeployFold%
