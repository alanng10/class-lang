@echo off

echo Make Module
pushd View\View.Infra
dotnet build -v quiet
popd
