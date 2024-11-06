@echo off

set DotNetInfraLibFold=.\Out\net8.0\Lib
set WorkingFold=%cd%

pushd Out\net8.0
setlocal
set "PATH=%WorkingFold%\%DotNetInfraLibFold%;%PATH%" && dotnet ViewDemo.dll
echo Status: %errorlevel%
endlocal
popd