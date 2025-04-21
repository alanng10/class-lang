#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release

mkdir -p $InfraDemoPackageOutFold
pushd $InfraDemoPackageOutFold
qmake6 ../../Infra/InfraDemo/InfraDemo.pro
popd