@echo off

pushd Tool
for /d %%a in ("Z.Tool.Class.*") do (

    pushd ..\Out\net8.0
    echo Execute "%%~nxa"
    echo:
    dotnet %%~nxa.dll
    echo Status: %errorlevel%
    echo:
    popd
)
popd