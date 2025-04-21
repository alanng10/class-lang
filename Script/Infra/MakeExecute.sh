#!/bin/bash

InfraExecutePackageOutFold=Out/InfraExecute-Linux-Release

mkdir -p $InfraExecutePackageOutFold
pushd $InfraExecutePackageOutFold
make >/dev/null
popd