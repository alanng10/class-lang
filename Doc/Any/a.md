# Any

Any class is root class of all classes.
Builtin Bool, Int, and String classes has base class that is Any;
Null any has null class that has base class that is Any.

Null can be assigned to any input of lang elements except when input required class is builtin Bool or builtin Int.
The inputs include var target, set target and base set target of assignment execute.

Null ref pointer can be assigned to any ref pointer holder declared in any class.

Builtin Bool, Int, and String anys have Init maide that returns Bool true only.
If root class Any ref pointer holders that have builtin Bool, Int, or String ref pointers are called Init maide then
the calls are run time errors.