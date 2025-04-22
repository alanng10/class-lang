#!/bin/bash

InfraOutFold=Out/Infra-Linux-Release

mkdir -p $InfraOutFold
pushd $InfraOutFold
qmake6 ../../Infra/Infra/Infra.pro
popd