@echo off

call Script\Infra\Var

set InfraInternOutFold=.\Out\InfraIntern-Windows-Release

mkdir %InfraInternOutFold% 1>NUL 2>NUL
pushd %InfraInternOutFold%
mingw32-make 1>NUL
popd