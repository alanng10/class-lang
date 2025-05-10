#!/bin/bash

ModuleRef=$1

SourceFold=./Gen/$ModuleRef

mv $SourceFold/$ModuleRef.dll "../$ClassPath/Module/$ModuleRef.dll" >NUL