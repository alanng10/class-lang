#!/bin/bash

InfraDemoPackageOutFold=Out/InfraDemo-Linux-Release
InfraPackageOutFold=Out/Infra-Linux-Release
WorkFold=$PWD

LD_LIBRARY_PATH="$WorkFold/$InfraPackageOutFold:$LD_LIBRARY_PATH" $InfraDemoPackageOutFold/InfraDemo
