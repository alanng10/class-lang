@echo off

call Script\Avalon\Clean
call Script\Avalon\DeployInfra

call Script\Avalon\MakeModule
echo:
call Script\Avalon\MakeDemo