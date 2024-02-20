@echo off



set InfraOutFold=.\Out\Infra-Windows-Release\release


set InfraDeployFold=.\Out\InfraDeploy



copy /Y %InfraOutFold%\Infra.dll %InfraDeployFold%
