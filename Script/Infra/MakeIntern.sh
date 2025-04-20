#!/bin/bash

InfraInternPackageOutFold=Out/InfraIntern-Linux-Release

mkdir $InfraInternPackageOutFold 1>/dev/null 2>/dev/null
pushd $InfraInternPackageOutFold
make >/dev/null
popd