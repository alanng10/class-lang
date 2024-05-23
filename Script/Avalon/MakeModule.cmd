@echo off

echo Make Module
pushd Avalon\MakeProject
dotnet build -v quiet
popd
