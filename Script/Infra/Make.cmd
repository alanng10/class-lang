@echo off 

call Script\Infra\CleanModule
call Script\Infra\CleanDemo
call Script\Infra\CleanDeploy
call Script\Infra\MakeModuleProject
call Script\Infra\MakeModule
call Script\Infra\MakeDemoProject
call Script\Infra\MakeDemo
call Script\Infra\Deploy
