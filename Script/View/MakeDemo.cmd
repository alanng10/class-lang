@echo off

echo Make Demo
pushd View\Demo
dotnet build -v quiet
popd