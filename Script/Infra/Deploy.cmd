@echo off

call Script\Infra\Var

set WinDeployQt=%QtRoot%\6.6.1\mingw_64\bin\windeployqt.exe

call Script\Infra\UpdateDeploy

pushd %InfraDeployFold%
%WinDeployQt% Infra.dll
popd