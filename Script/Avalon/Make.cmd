@echo off




rmdir /S /Q .\Out\net6.0

echo:


rmdir /S /Q .\Out\Demo

echo:



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