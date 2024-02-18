@echo off


    
echo Make Module

echo:

    pushd MakeProject
    

    dotnet build -v quiet


    popd
    

echo:
