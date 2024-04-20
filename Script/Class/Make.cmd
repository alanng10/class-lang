@echo off

call Script\Class\CleanModule
echo:
call Script\Class\CleanTest
echo:
call Script\Class\MakeModule
echo:
call Script\Class\MakeTest
echo:
echo Make Binary
echo:
call Script\Tool\Make ReferBinaryGen
call Script\Tool\Execute ReferBinaryGen