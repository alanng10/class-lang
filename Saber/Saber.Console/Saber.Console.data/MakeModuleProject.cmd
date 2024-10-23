@echo off

set ModuleRef=%~1

set ProjectOutFold=.\Gen\%ModuleRef%-Out

mkdir %ProjectOutFold% 1>NUL 2>NUL
pushd %ProjectOutFold%
qmake ../%ModuleRef%/Project.pro
popd