@echo off

call Script\Infra\Var

set WinDeployQt=windeployqt.exe

call Script\Infra\UpdateDeploy

pushd %InfraDeployFold%
%WinDeployQt% Infra.dll
popd

call Script\Infra\DeployClangFile libc++.dll
call Script\Infra\DeployClangFile libomp.dll
call Script\Infra\DeployClangFile libunwind.dll
call Script\Infra\DeployClangFile libwinpthread-1.dll