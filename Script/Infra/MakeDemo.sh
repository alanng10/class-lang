#!/bin/bash

InfraDemoOutFold=Out/InfraDemo-Linux-Release

mkdir -p $InfraDemoOutFold
pushd $InfraDemoOutFold
make >/dev/null
popd