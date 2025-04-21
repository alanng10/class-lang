@echo off

call Script\Infra\Var

set InfraPackageOutFold=.\Out\Infra-Windows-Release

mkdir %InfraPackageOutFold% 1>NUL 2>NUL
pushd %InfraPackageOutFold%
qmake ../../Infra/Infra/Infra.pro
popd