#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release
InfraOutFold=Out/Infra-Linux-Release
WorkFold=$PWD

LD_LIBRARY_PATH="$WorkFold/$InfraOutFold:$LD_LIBRARY_PATH" $InfraDemoPackageOutFold/InfraDemo