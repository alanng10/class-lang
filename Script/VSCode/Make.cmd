@echo off

pushd VSCode\class-lang-vscode-ext
vsce package
echo Status: %errorlevel%
popd