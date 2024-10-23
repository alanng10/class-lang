@echo off

echo Copy Header
set SaberConsoleDataFold=.\Saber\Saber.Console\Saber.Console.data

copy /Y Infra\Infra\Prusate.h %SaberConsoleDataFold%\Infra_Prusate.h
copy /Y Infra\InfraIntern\Prusate.h %SaberConsoleDataFold%\InfraIntern_Prusate.h