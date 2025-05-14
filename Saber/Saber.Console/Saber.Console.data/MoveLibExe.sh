#!/bin/bash

ModuleRef=$1

ClassPath=$(< ClassPath.txt)

SourceFold=./Gen/Exe-$ModuleRef

mv $SourceFold/$ModuleRef.bin "../$ClassPath/$ModuleRef.bin" >/dev/null