@echo off

pushd Tool
for /d %%a in ("Z.Tool.Infra.*") do (

    pushd ..\Out\net8.0
    echo Execute "%%~nxa"
    dotnet %%~nxa.dll
    echo:
    popd
)
popd