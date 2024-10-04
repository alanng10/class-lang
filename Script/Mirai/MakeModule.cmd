@echo off

echo Make Module
pushd Mirai\View
dotnet build -v quiet
popd
