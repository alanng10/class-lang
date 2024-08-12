@echo off

call Script\Infra\Var

set InfraInternProjectOutFold=.\Out\InfraIntern-Windows-Release

mkdir %InfraInternProjectOutFold% 1>NUL 2>NUL
pushd %InfraInternProjectOutFold%
qmake ../../Infra/InfraIntern/InfraIntern.pro
popd