@echo off

set DotNetOutFold=.\Out\net8.0

echo Make Module
pushd %DotNetOutFold%
saber make ../../System/System.Infra -m
popd
