@echo off

call Script\Avalon\CleanModule
echo:
call Script\Avalon\CleanDemo
echo:
call Script\Avalon\MakeModule
echo:
call Script\Avalon\MakePackage
echo:
call Script\Avalon\PushPackage
echo:
call Script\Avalon\MakeDemo
echo: