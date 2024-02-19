@echo off




rmdir /S /Q .\Out\net6.0

echo:



pushd Avalon\Demo


dotnet clean -v quiet


popd


echo:


echo:



call Script\Avalon\MakeModule

echo:



call Script\Avalon\MakePackage

echo:


call Script\Avalon\PushPackage

echo:



call Script\Avalon\MakeDemo

echo: