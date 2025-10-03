@echo off

set Module=%~1
set DotNetOutFold=.\Out\net8.0

echo Make Library %Module%
pushd %DotNetOutFold%
saber library System.%Module%-0.00.00
popd