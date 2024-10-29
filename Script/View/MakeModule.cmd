@echo off

echo Make Module
pushd Mirai\Mirai.Infra
dotnet build -v quiet
popd
