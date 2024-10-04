@echo off

echo Make Test
pushd Saber\SaberTestExe
dotnet build -v quiet
popd