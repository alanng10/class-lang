@echo off





echo Push Package


..\nuget delete Avalon 1.0.0 -NonInteractive

echo:


..\nuget locals all -clear

echo:


..\nuget push Avalon.1.0.0.nupkg

echo: