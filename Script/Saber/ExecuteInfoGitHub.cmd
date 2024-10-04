@echo off

set InfoGitHubOutFold=.\Out\InfoGitHub
mkdir %InfoGitHubOutFold% 1>NUL 2>NUL

Out\net8.0\saber.exe info "Info" "%InfoGitHubOutFold%" -d
echo Status: %errorlevel%