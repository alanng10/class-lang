#!/bin/bash

ModuleRef=$1

ClassPath=`cat ClassPath.txt`

SourceFold=./Gen/$ModuleRef

mv $SourceFold/lib$ModuleRef.so "../$ClassPath/Module/lib$ModuleRef.so" >/dev/null