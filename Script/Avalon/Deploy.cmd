@echo off

set AvalonModuleOutFold=.\Out\net6.0
set DeployFold=.\Out\Deploy
set AvalonInternData=Avalon.Intern.-
mkdir %DeployFold% 1>NUL 2>NUL

del /F /Q %DeployFold%\Avalon.* 2>NUL

pushd %DeployFold%
for /d %%a in ("Avalon.*.-") do ( 
    rmdir /S /Q "%%~nxa" 2>NUL  
)
popd

copy /Y %AvalonModuleOutFold%\Avalon.*.dll %DeployFold%

mkdir %DeployFold%\%AvalonInternData% 1>NUL 2>NUL
xcopy /S /E %AvalonModuleOutFold%\%AvalonInternData% %DeployFold%\%AvalonInternData%