@echo off

call Script\Infra\Var

set InfraExecuteOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecuteOutFold% 1>NUL 2>NUL
pushd %InfraExecuteOutFold%
mingw32-make 1>NUL
popd