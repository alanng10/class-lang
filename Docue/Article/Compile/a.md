# Compile

Class source code is compiled to module.
The module binary has refer and state.

The binary refer contains info of declarations of the module.
During compilation, class compiler reads the binaries of the modules that the currently compiled module imports.
Class compiler uses the declaration info in the binaries refers to do class checking, name checking and count checking.

Class compiler has token stage, node stage and module stage.
Token stage splits sources texts into units of tokens and comments. Units of tokens are to contribute to nodes trees result in node stage.
Node stage creates nodes trees represent sources. The nodes trees contribute to compiled module ports and effects.
Module stage creates Anys represent declarations, does class checking, name checking and count checking.

Class compiler gens the module binary after the 3 stages.

The stages output results as Anys.

Class compiler does not optimize output.
This is enough element to do any process module making.

Class compiler has task kind to generate machine code library module
for module binary.
Module binary is executed by execute the library module on operating system.