#!/bin/bash

echo Deploy Infra

AvalonOutFold=Out/net8.0
InfraOutFold=Out/Infra-Linux-Release

mkdir -p $AvalonOutFold
cp $InfraOutFold/libInfra.so $AvalonOutFold