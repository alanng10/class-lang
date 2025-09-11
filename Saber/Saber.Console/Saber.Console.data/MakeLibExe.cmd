@echo off

set PATH=C:\Users\aaabb\Qt\6.8.1\llvm-mingw_64\bin;C:\Users\aaabb\Qt\Tools\llvm-mingw1706_64\bin;%PATH%

set ModuleRef=%~1

set SourceFold=.\Gen\%ModuleRef%

set /p ClassPath=<ClassPath.txt

pushd %SourceFold%
clang -pipe -fno-strict-aliasing -O0 -std=gnu11 -Wall -Wno-ignored-attributes -Wno-bitwise-instead-of-logical -Wno-unused-but-set-variable -Wno-unused-variable -I. -I../.. -Wl,-s -Wl,-subsystem,console -L../../../%ClassPath% -lInfra -lInfraIntern -l%ModuleRef% -o  "../../../%ClassPath%/%ModuleRef%.exe" Main.c 1>NUL 2>..\..\ErrorExe.txt
popd