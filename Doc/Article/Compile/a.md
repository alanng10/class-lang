# Compile

Class source code is compiled to module.
The module binary is C# assembly binary.
The module binary is executed on .NET runtime.
The execution is started with execution of one of the module binary associated executable ".exe" files.

Class source code is compiled to C# source code and a refer binary, then the C# source code is compiled to C# assembly binary with .NET CLI.
The refer binary contains info of exported declarations of the module.
During compilation, class compiler reads the refer binaries of the modules that the currently compiled module imports.
Class compiler uses the declaration info in the refer binaries to do class checkings, and name checkings.

Class compiler has token stage, node stage and module stage.
Token stage splits sources texts into units of tokens and comments. Units of tokens are to contribute to nodes trees result in node stage.
Node stage creates nodes trees represent sources. The nodes trees contribute to compiled module ports and effects.
Module stage creates Anys represent declarations, do class checking, name checking and count checking.

Class compiler gens the module binary after the 3 stages.

The stages output results as Anys.