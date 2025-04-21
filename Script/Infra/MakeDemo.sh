#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release

mkdir -p $InfraDemoPackageOutFold
pushd $InfraDemoPackageOutFold
make >/dev/null
popd