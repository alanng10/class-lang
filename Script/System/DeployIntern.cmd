@echo off

echo Deploy Intern

set ClassOutFold=.\Out\Class
set InfraInternOutFold=.\Out\InfraIntern-Windows-Release\release

copy /Y %InfraInternOutFold%\InfraIntern.dll %ClassOutFold% 1>NUL 2>NUL