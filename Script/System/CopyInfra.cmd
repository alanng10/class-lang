@echo off

echo Copy Infra

set ClassOutFold=.\Out\Class
set InfraDeployFold=.\Out\InfraDeploy

xcopy /S /E /Y "%InfraDeployFold%" "%ClassOutFold%" 1>NUL 2>NUL