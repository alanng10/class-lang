@echo off

set DotNetOutFold=.\Out\net8.0

echo Make Demo
pushd %DotNetOutFold%
saber make ../../System/SystemDemo

saber make ../../System/SystemDemoNetwork
popd