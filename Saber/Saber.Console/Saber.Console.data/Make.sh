#!/bin/bash

Module=$1

./DeleteLib.sh %Module%

./MakeLib.sh %Module%

./MoveLib.sh %Module%