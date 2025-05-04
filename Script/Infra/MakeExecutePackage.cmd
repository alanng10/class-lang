@echo off

call Script\Infra\Var

set InfraExecuteOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecuteOutFold% 1>NUL 2>NUL
pushd %InfraExecuteOutFold%
qmake ../../Infra/InfraExecute/InfraExecute.pro
popd