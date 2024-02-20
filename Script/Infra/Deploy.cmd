@echo off




set InfraOutFold=.\Out\Infra-Windows-Release\release


set InfraDeployFold=.\Out\InfraDeploy


set WinDeployQt=%QtRoot%\6.6.1\mingw_64\bin\windeployqt.exe



mkdir %InfraDeployFold% 1>NUL 2>NUL



copy /Y %InfraOutFold%\Infra.dll %InfraDeployFold%



pushd %InfraDeployFold%


%WinDeployQt% Infra.dll


popd