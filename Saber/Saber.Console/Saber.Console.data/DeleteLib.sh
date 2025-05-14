#!/bin/bash

ModuleRef=$1

ClassPath=$(< ClassPath.txt)

rm -f "../$ClassPath/lib$ModuleRef.so" 2>/dev/null