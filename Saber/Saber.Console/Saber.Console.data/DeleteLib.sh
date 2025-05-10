#!/bin/bash

ModuleRef=$1

ClassPath=`cat ClassPath.txt`

rm "../$ClassPath/Module/lib$ModuleRef.so" 2>/dev/null