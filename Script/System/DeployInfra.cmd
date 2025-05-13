@echo off

echo Deploy Infra

set ClassOutFold=.\Out\Class
set InfraDeployFold=.\Out\InfraDeploy

mkdir %ClassOutFold% 1>NUL 2>NUL

xcopy /S /E /Y "%InfraDeployFold%" "%ClassOutFold%" 1>NUL 2>NUL