@echo off



cd Demo/bin/Debug/net6.0



dotnet Demo.dll < ../../../../Input.txt



echo Status: %errorlevel%





cd ../../../..