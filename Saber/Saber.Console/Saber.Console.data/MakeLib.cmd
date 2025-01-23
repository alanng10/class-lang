@echo off

set ModuleRef=%~1
set Import=%~2

set /p ClassPath=<ClassPath.txt

set SourceFold=.\Gen\%ModuleRef%

pushd %SourceFold%
clang -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -shared -Wl,-subsystem,windows -L../../../%ClassPath% -lInfra -lInfraIntern%Import% -o %ModuleRef%.dll *.c
popd