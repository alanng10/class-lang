@echo off

set File=%~1

set ClangBinFold=%QtRoot%\Tools\llvm-mingw1706_64\bin
set InfraDeployFold=.\Out\InfraDeploy
copy /Y "%ClangBinFold%\%File%" %InfraDeployFold%