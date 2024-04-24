@echo off

set DotNetModuleOutFold=.\Out\net8.0
set DeployFold=.\Out\Class
set DeployModuleFold=%DeployFold%\Module
mkdir %DeployModuleFold% 1>NUL 2>NUL

copy /Y %DotNetModuleOutFold%\Avalon.*.dll %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\System.*.ref %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.dll %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.ref %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*-ExeCon.deps.json %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*-ExeCon.runtimeconfig.json %DeployModuleFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\class.exe %DeployModuleFold% 1>NUL 2>NUL

pushd %DotNetModuleOutFold%
for /d %%a in ("*.data") do ( 
    mkdir "..\..\%DeployModuleFold%\%%~nxa" 1>NUL 2>NUL
    xcopy /S /E /Y ".\%%~nxa" "..\..\%DeployModuleFold%\%%~nxa" 1>NUL 2>NUL
)
popd