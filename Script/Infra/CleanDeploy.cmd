@echo off

call Script\Infra\Var

set InfraDeployFold=.\Out\InfraDeploy
rmdir /S /Q %InfraDeployFold%