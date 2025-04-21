@echo off

call Script\Infra\Var

set InfraInternPackageOutFold=.\Out\InfraIntern-Windows-Release

mkdir %InfraInternPackageOutFold% 1>NUL 2>NUL
pushd %InfraInternPackageOutFold%
qmake ../../Infra/InfraIntern/InfraIntern.pro
popd