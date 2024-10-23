@echo off

call Script\Saber\CleanModule
echo:
call Script\Saber\CleanTest
echo:
call Script\Saber\MakeModule
echo:
call Script\Saber\MakeTest