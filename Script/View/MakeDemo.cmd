@echo off

echo Make Demo
pushd Mirai\Demo
dotnet build -v quiet
popd