#!/bin/bash

InfraPackageOutFold=Out/Infra-Linux-Release

mkdir $InfraPackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraPackageOutFold
qmake6 ../../Infra/Infra/Infra.pro
popd