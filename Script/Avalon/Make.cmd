@echo off

call Script\Avalon\CleanModule
echo:
call Script\Avalon\CleanDemo
echo:
call Script\Avalon\MakeModule
echo:
call Script\Avalon\MakeDemo
echo:
call Script\Avalon\CopyInfra