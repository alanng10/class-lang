#!/bin/bash

InfraDemoOutFold=Out/InfraDemo-Linux-Release

mkdir -p $InfraDemoOutFold
pushd $InfraDemoOutFold
qmake6 ../../Infra/InfraDemo/InfraDemo.pro
popd