#!/bin/bash

InfraExecutePackageOutFold=Out/InfraExecute-Linux-Release

mkdir $InfraExecutePackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraExecutePackageOutFold
make >/dev/null
popd