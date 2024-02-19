@echo off




for /d /r %%a in ("Z.Tool.*") do (

    pushd Out\net6.0


    
    echo Execute "%%~nxa"

    echo:


    dotnet %%~nxa.dll

    echo Status: %errorlevel%


    echo:



    popd
)
