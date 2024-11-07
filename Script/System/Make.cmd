@echo off

call Script\System\Clean

call Script\System\MakeClassFold
call Script\System\DeployInfra

call Script\System\MakeModule Infra
call Script\System\MakeModule List
call Script\System\MakeModule Math
call Script\System\MakeModule Text