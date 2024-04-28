@echo off

set VSCodeExtFold=VSCode\class-lang-vscode-ext
set VSCodeOutFold=.\Out\VSCode
mkdir %VSCodeOutFold% 1>NUL 2>NUL

copy /Y .\LICENSE %VSCodeExtFold%\LICENSE.txt 1>NUL 2>NUL

pushd %VSCodeExtFold%
cmd /C "vsce package -o ..\..\%VSCodeOutFold%\class.vsix"
popd