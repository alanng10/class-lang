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

Maide is shared maide. It has no this ref.
Maide has param. The param is var list.
Param var has 64 bits int type. Param var type is not declared.
Maide result type is 64 bits int type.
Maide result type is not declared.

Maide state can have operate.
Operate results ref.
Input of lang elements also is assigned ref.
A ref can be 64 bits int type or struct type.
If it is 64 bits int type, the ref value is 64 bits int value.
If it is struct type, the ref value is struct any memory index.
A struct type can be builtin string struct type or struct type that has StructName.
Struct any is passed with ref.

Maide call argue is passed with ref.
The call can be passed with argue that has same count of ref as the maide param var count.
The call can be passed with argue that is any type of ref.
The maide state param var is the argue ref.
Param var is get and set as 64 bits int type any.
The call result type is maide result type, it is 64 bits int type.

Maide state can have execute that has NullOperate.
NullOperate has syntax that is "null" word.
NullOperate results ref, same as other Operate.
Null is assignable to all type input of lang elements.
Null has ref value that is zero.

Int is 64 bits. Ref is 64 bits.

Class node has syntax that starts with "class" index word, followed by Name of class ClassName,
followed by limit brace open token, followed by Part of class Part, 
followed by limit brace close token.

Struct node has syntax that starts with "struct" index word, followed by Name of class StructName.
followed by limit brace open token, followed by Part of class StructPart,
followed by limit brace close token.
StructPart is list of Var. The list is delimited by limit semicolon.

GlobVarOperate is operate that results glob var hold ref value.
The operate has syntax that starts with "glob" index word, followed by ClassName, 
followed by VarName.

GlobVarMark is mark that input glob var.
The mark has syntax that is same as GlobVarOperate.

StructVarOperate is operate that results ref that var in struct any holds.
The operate has syntax that starts with Any of class Operate, followed by limit dot, 
followed by Var of class VarName.
Any operate type is struct type.

StructVarMark is mark that input struct any var.
The mark has syntax that is same as StructVarOperate.
Any operate type is struct type.

Struct var, glob var and local var operate of var that is int type that is smaller than 64 bits
results int any ref that has the int value at lower bits in the ref value.
The upper bits are zero.
The type of the operates is 64 bits int type.
Struct var, glob var and local var mark of the var, inputs int any ref 
from AreExecute Value operate.
The lower bits of the ref value is assigned to the store of the var.
The upper bits of the ref value are not used.
The type of the marks is 64 bits int type.

Struct vars types, glob vars types and local vars types are declared.
The node is TypeName.
TypeName class is base class.
The class has 5 derived class.
1 derived class is IntTypeName. IntTypeName represents int type name.
The int type can be byte, short, mid or int.
IntTypeName has syntax that is "byte" index word, "short" index word, "mid" index word, or "int" index word.
IntTypeName class has 1 field with name Type, that has IntType class. The field has one of IntType anys in IntType list.
1 derived class is StringTypeName.
StringTypeName represents builtin string struct type name.
StringTypeName has syntax that is "string" index word.
Struct vars, glob vars and local vars that are declared with StringTypeName hold ref that is memory index of builtin string struct any.
1 derived class is StructTypeName.
StructTypeName represents struct type name.
StructTypeName has syntax that starts with ClassName, followed by StructName.
Struct vars, glob vars and local vars that are declared with StructTypeName hold ref that is memory index of struct any. 
1 derived class is ValueStructTypeName.
ValueStructTypename represents value struct type name.
ValueStructTypeName has syntax that starts with "value" index word, followed by Type of class TypeName.
Type can be either StringTypeName or StructTypeName.
Struct vars, glob vars and local vars that are declared with ValueStructTypeName are allocated space for the struct anys.
The vars hold ref values that are memory indexes of the allocated struct anys.
StructVarOperate, GlobVarOperate and VarOperate of the vars have type that is the struct type that is Type.
The vars cannot be assigned to.
1 derived class is ValueArrayTypeName.
ValueArrayTypeName represents array of int or struct type name.
ValueArrayTypeName has syntax that starts with "value" index word, followed by Type of class TypeName, followed by limit brace square open token, 
followed by Value, followed by limit brace square close token.
Type can be either IntTypeName, StringTypeName or StructTypeName.
Value can be either IntValue, IntHexValue, IntSignValue or IntHexSignValue.
Struct vars, glob vars and local vars that are declared with ValueArrayTypeName are allocated space for the array anys.
The vars hold ref values that are memory indexes of the allocated array anys.
StructVarOperate, GlobVarOperate and VarOperate of the vars have type.
The type is the struct type for array of struct type anys, it is Type.
The type is the 64 bits int type for array of int type anys.
The vars cannot be assigned to.

Struct vars, glob vars and local vars are declared with Var node.
Var node syntax starts with "var" index word, followed by TypeName, followed by VarName.

Struct vars, glob vars and local vars that are arrays, are 1 dimensional arrays.

Calculate memory index with 64 bits int type operate lang elements is enough element to
do any calculate of memory index.

InfExecute and WhileExecute cond operate is 64 bits int type as bool type.
AndOperate, OrnOperate and NotOperate input types and output types is 64 bits int type as bool type.

Glob vars are represented with GlobVar.
GlobVar has syntax that starts with "glob" index word, followed by Var, followed by limit semicolon.

StructIndexOperate is operate that results struct any ref at index of array of struct anys.
The operate has syntax that starts with Any operate, followed by limit brace square open token, 
followed by Index operate, followed by limit brace square close token.
Any operate has type that is struct type.
Index operate has type that is 64 bits int type.
The result type of StructIndexOperate is the type of the Any operate.
The struct any ref at the unsigned index of array of struct anys of the struct type is resulted.
The array starts with memory index that is ref value of Any operate.

IntIndexOperate is operate that results int any ref at index of array of int anys.
The operate has syntax that starts with Type of class IntTypeName, followed by Any operate, followed by limit brace square open token, 
followed by Index operate, followed by limit brace square close token.
Any operate has type that is 64 bits int type.
Index operate has type that is 64 bits int type.
The result type of IntIndexOperate is 64 bits int type.
The int any ref at the unsigned index of array of the Type size int anys is resulted.
The array starts with memory index that is ref value of Any operate.
If Type is an int type smaller than 64 bits, the int any ref resulted has the int value at lower bits.
The upper bits are zero.

IntIndexMark is mark that input int any ref at index of array of int anys.
The mark has syntax that is same as IntIndexOperate.
Any operate has type that is 64 bits int type.
Index operate has type that is 64 bits int type.
The mark type of IntIndexMark is 64 bits int type.
The int any at the unsigned index of array of the Type size int anys is assigned.
The array starts with memory index that is ref value of Any operate.
AreExecute Value operate ref value is assigned at index of the array.
If Type is an int type smaller than 64 bits, the lower bits of the ref value are assigned to the store.
The upper bits of the ref value are not used.

CopyExecute is execute that copies struct any from source to dest.
CopyExecute has syntax that starts with "copy" index word, followed by limit brace round open token,
followed by Dest of class Operate, followed by limit comma, 
followed by Source of class Operate, followed by limit brace round close token, 
followed by limit semicolon.
Dest has type that is any struct type.
Source can be 64 bits int type or any struct type.
This execute copies struct any of the Dest struct type from Source memory index to Dest memory index.

RefCallOperate is operate that call with ref value as maide memory index.
The call argue is passed with ref, same as CallOperate.
The call interface is not declared.
The call can be passed with argue that is any integer multiple of ref.
The call can be passed with argue that is any type of ref.
The call argue list count is not declared.
The call argue list type is not declared.
The call result type is not declared.
The call result type is 64 bits int type.
It is programming error, to passed argue with different count of ref with declared param count of the maide, in the call.

RefCallOperate has syntax that starts with "call" index word.
The index word is followed by var name, that is the var that hold ref value that is the maide memory index.
The var is 64 bits int type.
The var name is followed by limit brace open and matching close tokens.
The limit brace close token is the last token of the RefCallOperate node syntax.
Between the limit brace open and close tokens, RefCallOperate has Argue node.

Sande Lang does not need lang element to interface to external.
Sande compiler modules have infra to generate refer binary.
The refer binary can refer to custom made machine code binary.
This is enough element to interface to external.