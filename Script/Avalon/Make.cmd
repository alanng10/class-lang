@echo off




rmdir /S /Q .\Out\net6.0

echo:



cd Demo


dotnet clean -v quiet


cd ..


echo:


echo:



call MakeModule

echo:



call MakePackage

echo:



..\nuget delete Avalon 1.0.0 -NonInteractive

echo:


..\nuget locals all -clear

echo:


..\nuget push Avalon.1.0.0.nupkg

echo:

echo:



call MakeDemo

echo: