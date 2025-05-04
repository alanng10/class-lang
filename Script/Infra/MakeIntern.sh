#!/bin/bash

InfraInternOutFold=Out/InfraIntern-Linux-Release

mkdir -p $InfraInternOutFold
pushd $InfraInternOutFold
make >/dev/null
popd