@echo off

set DocueOutFold=.\Out\Docue
mkdir %DocueOutFold% 1>NUL 2>NUL

pushd Out\net8.0
saber.exe docue "..\..\Docue" "..\..\%DocueOutFold%"
echo Status: %errorlevel%
popd