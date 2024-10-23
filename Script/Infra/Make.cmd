@echo off 

call Script\Infra\CleanModule
call Script\Infra\CleanDemo
call Script\Infra\CleanIntern
call Script\Infra\CleanDeploy
call Script\Infra\MakeModuleProject
call Script\Infra\MakeModule
call Script\Infra\Deploy
call Script\Infra\MakeDemoProject
call Script\Infra\MakeDemo
call Script\Infra\MakeInternProject
call Script\Infra\MakeIntern
call Script\Infra\UpdateDeployIntern