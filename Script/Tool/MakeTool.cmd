@echo off



SET ToolName=%~1


SET ModuleName=Z.Tool.%ToolName%





cd %ModuleName%



dotnet build



cd ..