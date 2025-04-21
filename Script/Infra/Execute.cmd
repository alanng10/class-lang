@echo off

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release
set InfraDeployFold=.\Out\InfraDeploy
set WorkFold=%cd%

setlocal
set "QT_PLUGIN_PATH=%WorkFold%\%InfraDeployFold%" && set "PATH=%WorkFold%\%InfraDeployFold%;%PATH%" && %InfraDemoPackageOutFold%\release\InfraDemo
echo Status: %errorlevel%
endlocal
