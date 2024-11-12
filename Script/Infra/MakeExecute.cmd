@echo off

call Script\Infra\Var

set InfraExecuteProjectOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecuteProjectOutFold% 1>NUL 2>NUL
pushd %InfraExecuteProjectOutFold%
mingw32-make 1>NUL
popd