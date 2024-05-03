@echo off

pushd Tool\Z.Make.Infra
dotnet build -v quiet
popd