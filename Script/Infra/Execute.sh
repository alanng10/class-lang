#!/bin/bash

InfraDemoOutFold=Out/InfraDemo-Linux-Release
InfraOutFold=Out/Infra-Linux-Release
WorkFold=$PWD

LD_LIBRARY_PATH="$WorkFold/$InfraOutFold:$LD_LIBRARY_PATH" $InfraDemoOutFold/InfraDemo