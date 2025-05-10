#!/bin/bash

ModuleRef=$1

ClassPath=`cat ClassPath.txt`

SourceFold=./Gen/$ModuleRef

Import=`cat $SourceFold/Import.txt`

pushd $SourceFold
gcc -pipe -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -shared -L../../../$ClassPath -L../../../$ClassPath/Module -lInfra -lInfraIntern$Import -o $ModuleRef.dll *.c 1>/dev/null 2>../../error.txt
popd