@echo off

set GitHubDocOutFold=.\Out\GitHubDoc
mkdir %GitHubDocOutFold% 1>NUL 2>NUL

Out\net8.0\class.exe doc "Doc" "%GitHubDocOutFold%" -d
echo Status: %errorlevel%