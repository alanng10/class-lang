@echo off

echo Copy Header
set SaberConsoleDataFold=.\Saber\Saber.Console\Saber.Console.data

copy /Y Infra\Infra\Prusate.h %SaberConsoleDataFold%
copy /Y Infra\InfraIntern\Prusate.h %SaberConsoleDataFold%