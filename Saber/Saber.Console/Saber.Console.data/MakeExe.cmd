@echo off

set ModuleRef=%~1

set SourceFold=.\Gen\Exe-%ModuleRef%

pushd %SourceFold%
clang -pipe -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -L../../../%ClassPath% -L../../../%ClassPath%/Module -lInfra -lInfraIntern -l%ModuleRef% -o %ModuleRef%.exe Main.c 1>NUL 2>..\..\ErrorExe.txt
popd