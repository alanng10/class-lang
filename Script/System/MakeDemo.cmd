@echo off

set Module=%~1
set DotNetOutFold=.\Out\net8.0

echo Make Module %Module%
pushd %DotNetOutFold%
saber make ../../System/SystemDemo
echo Status: %errorlevel%
popd
