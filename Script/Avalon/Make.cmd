@echo off




rmdir /S /Q .\Out\net6.0

echo:



pushd Avalon\Demo


dotnet clean -v quiet


popd


echo:


echo:



call MakeModule

echo:



call MakePackage

echo:


call PushPackage

echo:



call MakeDemo

echo: