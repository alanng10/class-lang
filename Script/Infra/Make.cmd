@echo off 

call Script\Infra\CleanModule
call Script\Infra\CleanDemo
call Script\Infra\CleanIntern
call Script\Infra\CleanDeploy
call Script\Infra\MakeModulePackage
call Script\Infra\MakeModule
call Script\Infra\Deploy
call Script\Infra\MakeDemoPackage
call Script\Infra\MakeDemo
call Script\Infra\MakeInternPackage
call Script\Infra\MakeIntern