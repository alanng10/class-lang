#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release

mkdir $InfraDemoPackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraDemoPackageOutFold
qmake6 ../../Infra/InfraDemo/InfraDemo.pro
popd