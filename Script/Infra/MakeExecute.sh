#!/bin/bash

InfraExecuteOutFold=Out/InfraExecute-Linux-Release

mkdir -p $InfraExecuteOutFold
pushd $InfraExecuteOutFold
make >/dev/null
popd