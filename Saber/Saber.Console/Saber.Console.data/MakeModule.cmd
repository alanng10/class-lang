@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Gen\%ModuleRef%-Out

mkdir %ProjectOutFold% 1>NUL 2>NUL
pushd %ProjectOutFold%
mingw32-make 1>NUL 2>..\..\error.txt
popd