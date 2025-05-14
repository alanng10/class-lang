#!/bin/bash

ModuleRef=$1

ClassPath=$(< ClassPath.txt)

rm -f "../$ClassPath/$ModuleRef.bin" 2>/dev/null