#!/bin/bash

InfraInternPackageOutFold=Out/InfraIntern-Linux-Release

mkdir -p $InfraInternPackageOutFold
pushd $InfraInternPackageOutFold
qmake6 ../../Infra/InfraIntern/InfraIntern.pro
popd