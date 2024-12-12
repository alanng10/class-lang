@echo off

echo Make Docue
pushd Saber\SaberDocueExe
dotnet build -v quiet
popd