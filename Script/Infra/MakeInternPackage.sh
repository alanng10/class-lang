#!/bin/bash

InfraInternPackageOutFold=Out/InfraIntern-Linux-Release

mkdir $InfraInternPackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraInternPackageOutFold
qmake6 ../../Infra/InfraIntern/InfraIntern.pro
popd