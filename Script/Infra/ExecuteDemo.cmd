@echo off

set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release
set InfraDemoBinaryFold=%InfraDemoProjectOutFold%\release

pushd %InfraDemoBinaryFold%
InfraDemo
popd