@echo off

set DotNetModuleOutFold=.\Out\net8.0
set InfraInternOutFold=.\Out\InfraIntern-Windows-Release\release

copy /Y %InfraInternOutFold%\InfraIntern.dll %DotNetModuleOutFold% 1>NUL 2>NUL