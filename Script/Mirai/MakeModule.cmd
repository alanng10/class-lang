@echo off

echo Make Module
pushd Mirai\Mirai.View
dotnet build -v quiet
popd
