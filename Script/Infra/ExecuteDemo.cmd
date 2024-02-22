@echo off

set InfraDemoProjectOutFold=.\Out\InfraDemo-Windows-Release
pushd %InfraDemoProjectOutFold%
release\InfraDemo
popd