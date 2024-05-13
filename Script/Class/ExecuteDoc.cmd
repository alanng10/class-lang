@echo off

set DocOutFold=.\Out\Doc
mkdir %DocOutFold% 1>NUL 2>NUL

Out\net8.0\class.exe doc "Doc" "%DocOutFold%"
echo Status: %errorlevel%