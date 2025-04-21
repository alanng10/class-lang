@echo off

call Script\Infra\Var

set InfraExecutePackageOutFold=.\Out\InfraExecute-Windows-Release

mkdir %InfraExecutePackageOutFold% 1>NUL 2>NUL
pushd %InfraExecutePackageOutFold%
mingw32-make 1>NUL
popd