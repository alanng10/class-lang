@echo off

call Script\System\MakeModuleLibrary Infra
call Script\System\MakeModuleLibrary List
call Script\System\MakeModuleLibrary Math
call Script\System\MakeModuleLibrary Text
call Script\System\MakeModuleLibrary Thread
call Script\System\MakeModuleLibrary Stream
call Script\System\MakeModuleLibrary Time
call Script\System\MakeModuleLibrary Storage
call Script\System\MakeModuleLibrary Network
call Script\System\MakeModuleLibrary Console
call Script\System\MakeModuleLibrary Entry
call Script\System\MakeDemoLibrary