@echo off

call Script\Infra\Var

set InfraExecuteProjectOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecuteProjectOutFold% 1>NUL 2>NUL
pushd %InfraExecuteProjectOutFold%
qmake ../../Infra/InfraExecute/InfraExecute.pro
popd