@echo off

call Clean
echo:
echo Make Infra
call Script\Infra\MakeModuleProject
call Script\Infra\MakeModule
call Script\Infra\Deploy
echo:
echo Make Avalon
call Script\Avalon\MakeModule
echo:
echo Make Class
call Script\Class\MakeModule
echo Make Ref
call Script\Tool\Make ReferBinaryGen
call Script\Tool\Execute ReferBinaryGen