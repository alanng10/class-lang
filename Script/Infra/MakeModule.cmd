@echo off

call Script\Infra\Var

set InfraOutFold=.\Out\Infra-Windows-Release

mkdir %InfraOutFold% 1>NUL 2>NUL
pushd %InfraOutFold%
mingw32-make 1>NUL
popd