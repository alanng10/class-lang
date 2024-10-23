@echo off

call Script\Infra\Var

set ModuleRef=%~1

set ProjectOutFold=.\Saber.Console.data\Gen\%ModuleRef%-Out

mkdir %ProjectOutFold% 1>NUL 2>NUL
pushd %ProjectOutFold%
qmake ../%ModuleRef%/Project.pro
popd