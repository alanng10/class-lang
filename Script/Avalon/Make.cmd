@echo off


echo Clean Module

SET CSharpOut=.\Out\net6.0

del /F /Q %CSharpOut%\Avalon.*

del /F /Q %CSharpOut%\MakeProject.*

rmdir /S /Q %CSharpOut%\Lib

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