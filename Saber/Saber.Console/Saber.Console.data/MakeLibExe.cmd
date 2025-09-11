@echo off

call Var

set ModuleRef=%~1

set SourceFold=.\Gen\%ModuleRef%

set /p ClassPath=<ClassPath.txt

pushd %SourceFold%
clang -pipe -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -Wl,-subsystem,console -L../../../%ClassPath% -lInfra -lInfraIntern -l%ModuleRef% -o %ModuleRef%.exe Main.c 1>NUL 2>..\..\ErrorExe.txt
popd