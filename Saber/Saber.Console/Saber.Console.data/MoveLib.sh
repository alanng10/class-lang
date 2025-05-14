#!/bin/bash

ModuleRef=$1

ClassPath=$(< ClassPath.txt)

SourceFold=./Gen/$ModuleRef

mv $SourceFold/lib$ModuleRef.so "../$ClassPath/lib$ModuleRef.so" >/dev/null