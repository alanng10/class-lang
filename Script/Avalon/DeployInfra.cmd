@echo off

echo Deploy Infra

set AvalonLibOutFold=.\Out\net8.0\Lib
set InfraDeployFold=.\Out\InfraDeploy

mkdir %AvalonLibOutFold% 1>NUL 2>NUL

xcopy /S /E /Y "%InfraDeployFold%" "%AvalonLibOutFold%" 1>NUL 2>NUL