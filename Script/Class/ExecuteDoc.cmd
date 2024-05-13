@echo off

set DocOutFold=.\Out\Doc
mkdir %DocOutFold% 1>NUL 2>NUL

dotnet ClassExe.dll doc "Doc" "%DocOutFold%"
echo Status: %errorlevel%