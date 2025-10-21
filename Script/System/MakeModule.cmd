@echo off

set Module=%~1
set DotNetOutFold=.\Out\net8.0

echo Make %Module%
pushd %DotNetOutFold%
saber make ../../System/%Module% -m
popd