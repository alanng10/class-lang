@echo off

set DocGitHubOutFold=.\Out\DocGitHub
mkdir %DocGitHubOutFold% 1>NUL 2>NUL

Out\net8.0\class.exe doc "Doc" "%DocGitHubOutFold%" -d
echo Status: %errorlevel%