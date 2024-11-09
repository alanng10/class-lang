@echo off

set DocueGitHubOutFold=.\Out\DocueGitHub
mkdir %DocueGitHubOutFold% 1>NUL 2>NUL

pushd Out\net8.0
saber.exe docue "..\..\Docue" "..\..\%DocueGitHubOutFold%" -d
echo Status: %errorlevel%
popd
