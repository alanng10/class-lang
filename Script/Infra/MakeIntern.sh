#!/bin/bash

InfraInternPackageOutFold=Out/InfraIntern-Linux-Release

mkdir -p $InfraInternPackageOutFold
pushd $InfraInternPackageOutFold
make >/dev/null
popd