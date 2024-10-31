@echo off

echo Copy Infra

set DotNetModuleOutFold=.\Out\net8.0
set InfraDeployFold=.\Out\InfraDeploy

xcopy /S /E /Y "%InfraDeployFold%" "%DotNetModuleOutFold%" 1>NUL 2>NUL