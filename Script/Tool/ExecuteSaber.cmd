@echo off

pushd Tool
for /d %%a in ("Z.Tool.Saber.*") do (

    pushd ..\Out\net8.0
    echo Execute "%%~nxa"
    dotnet %%~nxa.dll
    echo Status: %errorlevel%
    echo:
    popd
)
popd