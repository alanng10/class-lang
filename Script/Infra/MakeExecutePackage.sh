#!/bin/bash

InfraExecuteOutFold=Out/InfraExecute-Linux-Release

mkdir -p $InfraExecuteOutFold
pushd $InfraExecuteOutFold
qmake6 ../../Infra/InfraExecute/InfraExecute.pro
popd