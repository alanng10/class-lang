@echo off

call Script\Infra\Var

set InfraDemoOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraDemoOutFold% 1>NUL 2>NUL
pushd %InfraDemoOutFold%
qmake ../../Infra/InfraDemo/InfraDemo.pro
popd