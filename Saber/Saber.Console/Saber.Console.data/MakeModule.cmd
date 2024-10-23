@echo off

call Script\Infra\Var

set ModuleRef=%~1

set ProjectOutFold=.\Saber.Console.data\Gen\%ModuleRef%-Out

mkdir %ProjectOutFold% 1>NUL 2>NUL
pushd %ProjectOutFold%
mingw32-make 1>NUL
popd