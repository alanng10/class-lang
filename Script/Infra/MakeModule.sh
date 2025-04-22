#!/bin/bash

InfraOutFold=Out/Infra-Linux-Release

mkdir -p $InfraOutFold
pushd $InfraOutFold
make >/dev/null
popd