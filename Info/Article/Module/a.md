# Module

A module is identified with module ref. A module ref has the module name and a version.

A module version has 3 parts. 
First part is major version that is a integer number.
Second part is minor version that is a 2 decimal digits integer number.
Third part is revision that is a 2 decimal digits integer number.
The version is displayed with all parts integer numbers separated by dot sign.
The version is displayed with the second part and the third part both in 2 decimal digits.
If the parts have integer number less than 10, a leading 0 is displayed in the parts.

Module ref is displayed with the module name, then a hypen sign, then the version.

A module associated files and directories, 
have 1 module binary file that is a C# assembly binary, 
1 refer binary file that is the exported declaration of the module,
1 data directory that contains all the module associated data files and directories.
These 2 files and 1 directory have names that are the displayed module ref of the module, followed with a dot sign and a extension name.
The module binary file, refer binary file, and data directory have extension names that are "dll", "ref, and "data".

If the module has entry for starting execution with the module, 
additional 2 executable files and executable related files are parts of the module associated files.
The module execution is started with the execution of 1 of the executable files.
1 executable file is for execution with console input and output in a command prompt.
Another executable file is for execution without console input and output and without command prompt.
The executable files can be executed in any working directory.

Modules read and write files in their data directories with paths that relative to their data directories.
Modules files in their data directories are not open to other modules by builtin infra.