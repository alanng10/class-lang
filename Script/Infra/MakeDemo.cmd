@echo off

call Script\Infra\Var

set InfraDemoPackageOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraDemoPackageOutFold% 1>NUL 2>NUL
pushd %InfraDemoPackageOutFold%
mingw32-make 1>NUL
popd