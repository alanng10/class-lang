@echo off

set DotNetOutFold=.\Out\net8.0

echo Make Demo
pushd %DotNetOutFold%
saber make ../../System/SystemDemo
echo Status: %errorlevel%

saber make ../../System/SystemDemoNetwork
echo Status: %errorlevel%
popd