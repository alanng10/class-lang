#!/bin/bash

ModuleRef=$1

ClassPath=$(< ClassPath.txt)

SourceFold=./Gen/Exe-$ModuleRef

pushd $SourceFold
gcc -pipe -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -L../../../$ClassPath -lInfra -lInfraIntern -l$ModuleRef -o $ModuleRef.bin Main.c 1>/dev/null 2>../../ErrorExe.txt
popd