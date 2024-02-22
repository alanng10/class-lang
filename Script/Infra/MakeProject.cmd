@echo off

set InfraProjectOutFold=.\Out\Infra-Windows-Release
set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraProjectOutFold% 1>NUL 2>NUL
pushd %InfraProjectOutFold%
qmake ../../Infra/Infra/Infra.pro
popd
mkdir %InfraDemoProjectOutFold% 1>NUL 2>NUL
pushd %InfraDemoProjectOutFold%
qmake ../../Infra/InfraDemo/InfraDemo.pro
popd