@echo off
set InfraProjectOutFold=.\Out\Infra-Windows-Release

%QtRoot%\6.6.1\mingw_64\bin\qtenv2.bat

mkdir %InfraProjectOutFold% 1>NUL 2>NUL
pushd %InfraProjectOutFold%
qmake ../../Infra/Infra/Infra.pro
mingw32-make
popd

Script\Infra\UpdateDeploy