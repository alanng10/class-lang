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

A module has 1 fold with the module ref as fold name, 
and 1 machine code library with the module ref as base name and "dll" as file extension.
Inside the fold, there is 1 file with "Module" as name that is the module data, 
and 1 fold with "Data" as name that is the data fold of the module.