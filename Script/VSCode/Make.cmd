@echo off

set VSCodeExtFold=VSCode\class-lang-vscode-ext
copy /Y .\LICENSE %VSCodeExtFold%\LICENSE.txt 1>NUL 2>NUL

pushd %VSCodeExtFold%
cmd /C "vsce package"
popd