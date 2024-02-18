@echo off




call UpdateInfra

echo:



rmdir /S /Q .\Out

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