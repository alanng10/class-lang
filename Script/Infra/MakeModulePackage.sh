#!/bin/bash

InfraPackageOutFold=Out/Infra-Linux-Release

mkdir -p $InfraPackageOutFold
pushd $InfraPackageOutFold
qmake6 ../../Infra/Infra/Infra.pro
popd