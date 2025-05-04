#!/bin/bash

InfraInternOutFold=Out/InfraIntern-Linux-Release

mkdir -p $InfraInternOutFold
pushd $InfraInternOutFold
qmake6 ../../Infra/InfraIntern/InfraIntern.pro
popd