@echo off

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release
set InfraDeployFold=.\Out\InfraDeploy
set WorkFold=%cd%

pushd %InfraDemoPackageOutFold%

setlocal
set "QT_PLUGIN_PATH=%WorkFold%\%InfraDeployFold%" && set "PATH=%WorkFold%\%InfraDeployFold%;%PATH%" && release\InfraDemo
echo Status: %errorlevel%
endlocal

popd