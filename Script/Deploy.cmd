@echo off

set DotNetModuleOutFold=.\Out\net6.0
set DeployFold=.\Out\Class
set DeployModuleFold=%DeployFold%\Module
mkdir %DeployModuleFold% 1>NUL 2>NUL

copy /Y %DotNetModuleOutFold%\Avalon.*.dll %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Avalon.*.ref %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.dll %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.ref %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\ClassExe.dll %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\ClassExe.deps.json %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\ClassExe.runtimeconfig.json %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\class.exe %DeployModuleFold% 1>NUL 2>NUL

pushd %DotNetModuleOutFold%
for /d %%a in ("*.-") do ( 
    mkdir "..\..\%DeployModuleFold%\%%~nxa" 1>NUL 2>NUL
    xcopy /S /E ".\%%~nxa" "..\..\%DeployModuleFold%\%%~nxa" 1>NUL 2>NUL
)
popd