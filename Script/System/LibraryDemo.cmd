@echo off

set DotNetOutFold=.\Out\net8.0

echo Library Demo
pushd %DotNetOutFold%
saber library SystemDemo-96207.08.47

saber library SystemDemoNetwork-0.00.00
popd