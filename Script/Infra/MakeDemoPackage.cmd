@echo off

call Script\Infra\Var

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraDemoPackageOutFold% 1>NUL 2>NUL
pushd %InfraDemoPackageOutFold%
qmake ../../Infra/InfraDemo/InfraDemo.pro
popd