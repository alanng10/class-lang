@echo off

call Script\Infra\Var

set InfraExecutePackageOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecutePackageOutFold% 1>NUL 2>NUL
pushd %InfraExecutePackageOutFold%
qmake ../../Infra/InfraExecute/InfraExecute.pro
popd