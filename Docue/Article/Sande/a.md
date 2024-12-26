# Sande

Sande is system programming language.
This programming language word "Sande" is a node name.

Sande is a plat.
The plat layers below System in info tech stack arch.

Sande is used to make system programming modules.

Sande modules sources has port.
The port source file has file name "Sande.Port".

Sande port can import Sande modules.
To import Sande modules, import the module classes with class names in the import section.
To export a class, write the class name in the export section.
Sande Lang port syntax is same as Class Lang port.

A Sande lang source has root node that is Class node.
The Class node has no base.
It has derived Comp classes nodes in Class node.

Comp node can be struct node, glob var node and maide node.
Glob var node is global var node.

All Comp derived classes have Count.
Count has derived classes that are PrusateCount, PronateCount and PrivateCount.

Prusate count is count that is applicable to all.
Pronate count is count that is applicable to current module.
Private count is count that is applicable to this class.

Struct var space allocation is byte granularity.

Maide state can have operate.
Operate results ref.
Input of lang elements also is assigned ref.
Marks can be assigned any ref.
A ref has no type.
Int is 64 bits. Ref is 64 bits.
Int any is passed with ref.
Int value is stored in ref value 64 bits.
Struct any is passed with ref.
Type is used to declare variable storage.
And for struct var get and set.
A struct type has StructName.

Sande Lang does not need cast operate.

Maide is shared maide. It has no this ref.
Maide has param. The param is var list.
Param var holds a ref. Param var type is not declared.
Maide result is a ref.
Maide result type is not declared.

Maide call argue is passed with ref.
The call can be passed with argue that has same count of ref as the maide param var count.
The call can be passed with argue that is any ref.
The maide state param var is the argue ref.
Param var is get and set as any other local var.
The call results a ref.

Maide state can have execute that has NullOperate.
NullOperate has syntax that is "null" word.
NullOperate results ref, same as other Operate.
Null has ref value that is zero.

Class node has syntax that starts with "class" index word, followed by Name of class ClassName,
followed by limit brace open token, followed by Part of class Part, 
followed by limit brace close token.

Struct node has syntax that starts with "struct" index word, followed by Count of class Count, 
followed by Name of class StructName,
followed by limit brace open token, followed by Part of class StructPart,
followed by limit brace close token.
StructPart is list of Var. The list is delimited by limit semicolon.

Glob vars are represented with GlobVar.
GlobVar has syntax that starts with "glob" index word, followed by Count of class Count, 
followed by Var, followed by limit semicolon.

Maide node has syntax that starts with "maide" index word, followed by Count of class Count, 
followed by Name of class MaideName, followed by limit brace round open token,
followed by Param of class Param, followed by limit brace round close token, 
followed by limit brace open token, followed by Call of class State, 
followed by limit brace close token.

Param node is list of VarName. The list is delimited by limit comma.

CallOperate is operate that call a maide.
The operate has syntax that starts with "call" index word, followed by Class of class ClassName, 
followed by Maide of class MaideName, followed by limit brace round open token, 
followed by Argue of class Argue, followed by limit brace round close token.
Maide with maide name Maide in class Class is called.
Argue is passed into the maide being called.
The operate results ref value that the maide returns.

GlobVarOperate is operate that results glob var hold ref value.
The operate has syntax that starts with "glob" index word, followed by Class of class ClassName, 
followed by Var of class VarName.

GlobVarMark is mark that input glob var.
The mark has syntax that is same as GlobVarOperate.

StructVarOperate is operate that results ref that var in struct any holds.
The operate has syntax that starts with "struct" index word, followed by Class of class ClassName, 
followed by Struct of class StructName, followed by Var of class VarName, 
followed by limit brace round open token, 
followed by Any of class Operate, followed by limit brace round close token.

StructVarMark is mark that input struct any var.
The mark has syntax that is same as StructVarOperate.

VarOperate is operate that results local var hold ref value.
The operate has syntax that is Var of class VarName.

VarMark is mark that input local var.
The mark has syntax that is same as VarOperate.

Struct var, glob var and local var operate of var that is int type that is smaller than 64 bits
results int any ref that has the int value at lower bits in the ref value.
The upper bits are zero.
Struct var, glob var and local var mark of the var, inputs int any ref 
from AreExecute Value operate.
The lower bits of the ref value is assigned to the store of the var.
The upper bits of the ref value are not used.

Struct vars types, glob vars types and local vars types are declared.
The node is TypeName.
TypeName class is base class.
The class has 4 derived class.
1 derived class is IntTypeName. IntTypeName represents int type name.
The int type can be byte, short, mid or int.
IntTypeName has syntax that is "byte" index word, "short" index word, "mid" index word, or "int" index word.
IntTypeName class has 1 field with name Type, that has IntType class. The field has one of IntType anys in IntType list.
1 derived class is StructTypeName.
StructTypeName represents value struct type name.
StructTypeName has syntax that starts with "value" index word, followed by Class of class ClassName, 
followed by Struct of class StructName.
Struct vars, glob vars and local vars that are declared with StructTypeName are allocated space for the struct anys.
The vars hold ref values that are memory indexes of the allocated struct anys.
The vars cannot be assigned to.
1 derived class is ArrayStructTypeName.
ArrayStructTypeName represents array of struct type name.
ArrayStructTypeName has syntax that starts with "value" index word, followed by Class of class ClassName, 
followed by Struct of class StructName, followed by limit brace square open token, 
followed by Value, followed by limit brace square close token.
Value can be either IntValue, IntHexValue, IntSignValue or IntHexSignValue.
Struct vars, glob vars and local vars that are declared with ArrayStructTypeName are allocated space for the arrays of struct anys.
The vars hold ref values that are memory indexes of the allocated arrays.
The vars cannot be assigned to.
1 derived class is ArrayIntTypeName.
ArrayIntTypeName represents array of int type name.
ArrayIntTypeName has syntax that starts with "value" index word, followed by Int of class IntTypeName, 
followed by limit brace square open token, followed by Value, followed by limit brace square close token.
Value can be either IntValue, IntHexValue, IntSignValue or IntHexSignValue.
Struct vars, glob vars and local vars that are declared with ArrayIntTypeName are allocated space for the arrays of int anys with the type Int.
The vars hold ref values that are memory indexes of the allocated arrays.
The vars cannot be assigned to.

Struct vars, glob vars and local vars are declared with Var node.
Var node syntax starts with "var" index word, followed by TypeName, followed by VarName.

Struct vars, glob vars and local vars that are arrays, are 1 dimensional arrays.

Calculate memory index with int operation operate lang elements is enough element to
do any calculate of memory index.

InfExecute and WhileExecute cond operates input any ref value as bool.
AndOperate, OrnOperate and NotOperate input any ref value as bool.
The operates output zero or one ref value as bool.

ByteOperate is operate that results byte ref at memory index.
The operate has syntax that starts with "byte" index word, followed by Any of class Operate.
Any is the memory index.
The byte int at the memory index is resulted.
The ref value resulted has the byte value at lower 8 bits.
The upper bits are zero.

ByteMark is mark that input byte ref at memory index.
The mark has syntax that is same as ByteOperate.
Any is the memory index.
The byte int at the memory index is assigned.
AreExecute Value operate ref value is assigned to byte store at memory index.
The lower 8 bits of the ref value are assigned to the store.
The upper bits of the ref value are not used.

CopyExecute is execute that copies struct any from source to dest.
CopyExecute has syntax that starts with "copy" index word, 
followed by Class of class ClassName, followed by Struct of class StructName,
followed by limit brace round open token,
followed by Dest of class Operate, followed by limit comma, 
followed by Source of class Operate, followed by limit brace round close token, 
followed by limit semicolon.
This execute copies struct any of the struct type Struct in class Class from Source memory index to Dest memory index.

RefCallOperate is operate that call with local var ref value as maide memory index.
The call argue is passed with ref, same as CallOperate.
The call interface is not declared.
The call can be passed with argue that is any integer multiple of ref.
The call can be passed with argue that is any ref.
The call argue list count is not declared.
The call argue list type is not declared.
The call result type is not declared.
It is programming error, to passed argue with different count of ref with declared param count of the maide, in the call.

RefCallOperate has syntax that starts with "refcall" index word,
followed by Var of class VarName, followed by limit brace round open token,
followed by Argue of class Argue, followed by limit brace round close token.
Var is the var that hold ref value that is the maide memory index.
Argue is argue that is passed into the maide being called.

RefMaideOperate is operate that results memory index of maide.
The operate has syntax that starts with "ref" index word, 
followed by "maide" index word, followed by Class of class ClassName,
followed by Maide of class MaideName.
Class is the class the maide in.
Maide is the maide name.

RefStructVarOperate is operate that results memory index of struct var.
The operate has syntax that starts with "ref" index word, followed by "struct" index word, 
followed by Class of class ClassName, 
followed by Struct of class StructName, followed by Var of class VarName, 
followed by limit brace round open token, 
followed by Any of class Operate, followed by limit brace round close token.

Sande Lang does not need lang element to interface to external.
Sande compiler modules have infra to generate refer binary.
The refer binary can refer to custom made machine code binary.
This is enough element to interface to external.