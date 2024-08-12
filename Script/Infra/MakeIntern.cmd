@echo off

call Script\Infra\Var

set InfraInternProjectOutFold=.\Out\InfraIntern-Windows-Release

mkdir %InfraInternProjectOutFold% 1>NUL 2>NUL
pushd %InfraInternProjectOutFold%
mingw32-make 1>NUL
popd