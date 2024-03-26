@echo off

for /d /r %%a in ("Tool\Z.Tool.Avalon.*") do (

    pushd Out\net6.0
    echo Execute "%%~nxa"
    echo:
    dotnet %%~nxa.dll
    echo Status: %errorlevel%
    echo:
    popd
)
