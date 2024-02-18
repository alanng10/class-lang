@echo off




for /d /r %%a in ("Z.Tool.*") do (
    
    pushd %%a
    
    
    echo Make "%%~nxa"

    echo:


    dotnet build -v quiet


    echo:
    

    popd

)