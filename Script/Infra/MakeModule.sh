#!/bin/bash

InfraPackageOutFold=Out/Infra-Linux-Release

mkdir -p $InfraPackageOutFold
pushd $InfraPackageOutFold
make >/dev/null
popd