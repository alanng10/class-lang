@echo off


SET Qt=..\..\Qt


SET WinDeployQt=%Qt%\6.6.1\mingw_64\bin\windeployqt.exe



mkdir .\Out\InfraDeploy 1>NUL 2>NUL


copy /Y .\Out\build-Infra-Windows-Release\release\Infra.dll .\Out\InfraDeploy



%WinDeployQt% .\Out\InfraDeploy\Infra.dll