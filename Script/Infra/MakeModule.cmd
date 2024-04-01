@echo off

call Script\Infra\Var

set InfraProjectOutFold=.\Out\Infra-Windows-Release

mkdir %InfraProjectOutFold% 1>NUL 2>NUL
pushd %InfraProjectOutFold%
mingw32-make
popd