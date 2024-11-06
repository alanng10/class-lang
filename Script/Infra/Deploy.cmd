@echo off

call Script\Infra\Var

set WinDeployQt=windeployqt.exe

call Script\Infra\UpdateDeploy

pushd %InfraDeployFold%
%WinDeployQt% Infra.dll
popd