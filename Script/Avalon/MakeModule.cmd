@echo off

echo Make Module
echo:
    pushd Avalon\MakeProject
    
    dotnet build -v quiet
    
    popd
echo:
