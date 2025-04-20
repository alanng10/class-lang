#!/bin/bash

InfraExecutePackageOutFold=Out/InfraExecute-Linux-Release

mkdir $InfraExecutePackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraExecutePackageOutFold
qmake6 ../../Infra/InfraExecute/InfraExecute.pro
popd