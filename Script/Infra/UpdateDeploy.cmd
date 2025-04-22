@echo off

call Script\Infra\Var

set InfraOutFold=.\Out\Infra-Windows-Release
set InfraDeployFold=.\Out\InfraDeploy
mkdir %InfraDeployFold% 1>NUL 2>NUL
copy /Y %InfraOutFold%\release\Infra.dll %InfraDeployFold%