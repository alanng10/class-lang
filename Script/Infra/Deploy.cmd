@echo off




SET WinDeployQt=%QtRoot%\6.6.1\mingw_64\bin\windeployqt.exe


SET InfraDeployFold=.\Out\InfraDeploy



mkdir %InfraDeployFold% 1>NUL 2>NUL



copy /Y .\Out\Infra-Windows-Release\release\Infra.dll %InfraDeployFold%



pushd %InfraDeployFold%


%WinDeployQt% Infra.dll


popd