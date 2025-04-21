#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release
InfraPackageOutFold=Out/Infra-Linux-Release
WorkFold=$PWD

pushd $InfraDemoPackageOutFold

PATH=$WorkFold/$InfraPackageOutFold:$PATH" release/InfraDemo

popd