@echo off



SET ToolName=%~1


SET ModuleName=Z.Tool.%ToolName%





cd Out/net6.0




dotnet %ModuleName%.dll



echo Status: %errorlevel%




cd ../..