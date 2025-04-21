@echo off

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release
set InfraDeployFold=.\Out\InfraDeploy
set WorkingFold=%cd%

pushd %InfraDemoPackageOutFold%

setlocal
set "QT_PLUGIN_PATH=%WorkingFold%\%InfraDeployFold%" && set "PATH=%WorkingFold%\%InfraDeployFold%;%PATH%" && release\InfraDemo
echo Status: %errorlevel%
endlocal

popd