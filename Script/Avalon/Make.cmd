@echo off


echo Clean Module

rmdir /S /Q .\Out\net6.0

echo:


echo Clean Demo

rmdir /S /Q .\Out\Demo

echo:



call Script\Avalon\MakeModule

echo:



call Script\Avalon\MakePackage

echo:


call Script\Avalon\PushPackage

echo:



call Script\Avalon\MakeDemo

echo: