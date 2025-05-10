#!/bin/bash

ModuleRef=$1

ClassPath=`cat ClassPath.txt`

SourceFold=./Gen/$ModuleRef

mv $SourceFold/$ModuleRef.dll "../$ClassPath/Module/$ModuleRef.dll" >NUL