@echo off

set DotNetModuleOutFold=.\Out\net6.0
set DeployFold=.\Out\Deploy

rmdir /S /Q %DeployFold% 2>NUL
mkdir %DeployFold% 1>NUL 2>NUL

copy /Y %DotNetModuleOutFold%\Avalon.*.dll %DeployFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Avalon.*.ref %DeployFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.dll %DeployFold% 1>NUL 2>NUL
copy /Y %DotNetModuleOutFold%\Class.*.ref %DeployFold% 1>NUL 2>NUL

pushd %DotNetModuleOutFold%
for /d %%a in ("*.-") do ( 
    mkdir "..\..\%DeployFold%\%%~nxa" 1>NUL 2>NUL
    xcopy /S /E ".\%%~nxa" "..\..\%DeployFold%\%%~nxa" 1>NUL 2>NUL
)
popd