@echo off
set InfraProjectOutFold=.\Out\Infra-Windows-Release

mkdir %InfraProjectOutFold% 1>NUL 2>NUL
pushd %InfraProjectOutFold%
qmake ../../Infra/Infra/Infra.pro
popd