@echo off

call Script\Infra\Var

set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release

mkdir %InfraDemoProjectOutFold% 1>NUL 2>NUL
pushd %InfraDemoProjectOutFold%
mingw32-make 1>NUL
popd