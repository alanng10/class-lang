@echo off

set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraDemoProjectOutFold% 1>NUL 2>NUL
pushd %InfraDemoProjectOutFold%
qmake ../../Infra/InfraDemo/InfraDemo.pro
popd