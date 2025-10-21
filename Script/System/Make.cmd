@echo off

call Script\System\Clean

call Script\System\DeployInfra
call Script\System\DeployIntern

call Script\System\MakeModule System.Infra
call Script\System\MakeModule System.List
call Script\System\MakeModule System.Math
call Script\System\MakeModule System.Text
call Script\System\MakeModule System.Thread
call Script\System\MakeModule System.Stream
call Script\System\MakeModule System.Time
call Script\System\MakeModule System.Storage
call Script\System\MakeModule System.Network
call Script\System\MakeModule System.Console
call Script\System\MakeModule System.Entry
call Script\System\MakeDemo