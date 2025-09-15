@echo off

call Script\System\Clean

call Script\System\DeployInfra
call Script\System\DeployIntern

call Script\System\MakeModule Infra
call Script\System\MakeModule List
call Script\System\MakeModule Math
call Script\System\MakeModule Text
call Script\System\MakeModule Thread
call Script\System\MakeModule Stream
call Script\System\MakeModule Time
call Script\System\MakeModule Storage
call Script\System\MakeModule Network
call Script\System\MakeModule Console
call Script\System\MakeModule Entry
call Script\System\MakeDemo