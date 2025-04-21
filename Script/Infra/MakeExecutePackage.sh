#!/bin/bash

InfraExecutePackageOutFold=Out/InfraExecute-Linux-Release

mkdir -p $InfraExecutePackageOutFold
pushd $InfraExecutePackageOutFold
qmake6 ../../Infra/InfraExecute/InfraExecute.pro
popd