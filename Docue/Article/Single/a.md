# Single

Single is system programming language.

Single is a plat.
The plat layers below System in info tech stack arch.

Single is used to make system programming modules.

Single modules sources has port.
The port source file has file name "Single.Port".

Single port can import Single modules.
To import Single modules, import the module classes with class names in the import section.
To export a class, write the class name in the export section.
Single Lang port syntax is same as Class Lang port.

A Single lang source has root node that is Class node.
The Class node has no base.
It has derived Comp classes nodes in Class node.

Comp node can be struct node, var node and maide node.
Var node is global var node.

All Comp derived classes have Count.
Count has derived classes that are PrusateCount, PronateCount and PrivateCount.

Prusate count is count that is applicable to all.
Pronate count is count that is applicable to current module.
Private count is count that is applicable to this class.

Maide is shared maide. It has no this ref.
Maide has param. The param is var list.
Param var has Int type. Param var type is not declared.
Maide result type is Int type.
Maide result type is not declared.

Maide state can have operate.
Operate results ref.
Input of lang elements also is assigned ref.
A ref can be Int type, struct type.
If it is Int type, the ref value is Int value.
If it is struct type, the ref value is struct any memory index.

Maide call argue is passed with ref.
The call can be passed with argue that has same count of ref as the maide param var count.
The call can be passed with argue that is any type of ref.
The maide state param var is the argue ref.
Param var is get and set as Int type any.
The call result type is maide result type, it is Int type.

Maide state can have execute that has NullOperate.
NullOperate has syntax that is "null" word.
NullOperate results ref, same as other Operate.
Null is assignable to all type input of lang elements.
Null has ref value that is zero.

Int is 64 bits. Ref is 64 bits.

RefCallOperate is operate that call with ref value as maide memory index.
The call argue is passed with ref, same as CallOperate.
The call interface is not declared.
The call can be passed with argue that is any integer multiple of ref.
The call can be passed with argue that is any type of ref.
The call argue list count is not declared.
The call argue list type is not declared.
The call result type is not declared.
The call result type is Int type.
It is programming error, to passed argue with different count of ref with declared param count of the maide, in the call.

RefCallOperate has syntax that starts with "call" index word.
The index word is followed by var name, that is the var that hold ref value that is the maide memory index.
The var name is followed by limit brace open and matching close tokens.
The limit brace close token is the last token of the RefCallOperate node syntax.
Between the limit brace open and close tokens, RefCallOperate has Argue node.

Struct any is passed with ref.

Struct field type and local var type is declared.
The node is TypeName.
TypeName class is base class.
The class has 2 derived class.
1 derived class is IntTypeName. IntTypeName has syntax that is "int" index word.
1 derived class is StructTypeName. 
StructTypeName has syntax that is ClassName followed by colon limit, followed by StructName.