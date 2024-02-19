@echo off



SET ToolName=%~1


SET ModuleName=Z.Tool.%ToolName%





cd Tool/%ModuleName%



dotnet build



cd ..