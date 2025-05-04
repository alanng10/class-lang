@echo off

call Script\Infra\Var

set InfraInternOutFold=.\Out\InfraIntern-Windows-Release

mkdir %InfraInternOutFold% 1>NUL 2>NUL
pushd %InfraInternOutFold%
qmake ../../Infra/InfraIntern/InfraIntern.pro
popd