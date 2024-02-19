@echo off



Set InfraOutFold=.\Out\Infra-Windows-Release\release


SET InfraDeployFold=.\Out\InfraDeploy



copy /Y %InfraOutFold%\Infra.dll %InfraDeployFold%
