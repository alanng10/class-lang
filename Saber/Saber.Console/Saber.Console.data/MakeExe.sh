#!/bin/bash

Module=$1

./DeleteLibExe.sh $Module

./MakeLibExe.sh $Module

./MoveLibExe.sh $Module