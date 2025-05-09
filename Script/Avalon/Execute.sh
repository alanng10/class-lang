#!/bin/bash

pushd Out/net8.0
dotnet Demo.dll < ../../Avalon/Input.txt
popd