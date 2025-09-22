# Sand

Sand is system program lang.
Sand is system class.
Sand is System Class.
This programming language word "Sand" is a node name.

Sand is did.

Sand is park system program lang.

Sand is tool to make system program.
Sand is not tool to make module that is executed on system program.

Sand is a plat.
The plat layers below System in info tech stack arch.

Sand is tool to make system programming modules.

Sand maide need to not expose StructType in param
to be able to abstract effect.
To reuse the maide, the maide need to cast the param IntType to StructType in state.
Because of the manual cast, Sand is not enough general to make class for effect.

Sand modules sources has port.
The port source file has file name "Sand.Port".

Sand port can import Sand modules.
To import Sand modules, import the module classes with class names in the import section.
To export a class, write the class name in the export section.
Sand Lang port syntax is same as Class Lang port.

Sand compiler classes derives from Class compiler classes.
Sand compiler module arch derives from Class compiler module arch.

A Sand lang source has token list and comment list.

A Sand lang source has root node that is Class node.
The Class node has no base.
It has derived Comp classes nodes in Class node.

Comp node can be struct node, glob node and maide node.
Glob node is global var node.

All Comp derived classes have Count.
Count has derived classes that are PrusateCount, PronateCount and PrivateCount.

Prusate count is count that is applicable to all.
Pronate count is count that is applicable to current module.
Private count is count that is applicable to this class.

Struct var space allocation is byte granularity.

Maide state can have operate.
Operate results ref.
Input of lang elements also is assigned ref.
Mark is assigned ref.
Ref is 64 bits.
Ref has type.
Type can be IntType.
IntType is 64, 32, 16, or 8 bits int.
Type can be StructType.
StructType has StructName.
StructTypes with different StructNames or in different Classes are different Types. 
Int any is passed with ref.
Ref that has IntType has the int value stored in ref value.
Struct any is passed with ref.
Ref that has StructType has the memory index of the struct any stored in ref value.

Ref that is assigned to input of lang elements is required 
to has Type that the input requires.

Storage is used to declare variable storage.

Operate that is IntType that is smaller than 64 bits
results int any ref that has the int value at lower bits in the ref value.
The upper bits are zero.
Mark that is IntType that is smaller than 64 bits, inputs int any ref.
The lower bits of the input ref value is assigned to the store of the mark.
The upper bits of the input ref value are not used.

Bool is represented with IntType.
Bool false is represented with int value zero.
Bool true is represented with int value one.
Bool input of lang element has type that is IntType.
The IntType is any IntKind.
Input value that is not zero is input bool true.
Bool output of lang element has type that is 64 bits IntType.
Bool output only outputs zero or one.

Maide is shared maide. It has no this ref.
Maide has param. The param is var list.
Param var holds a ref.
Param var has Type.
Maide result is a ref.
Maide result has Type.

Maide call argue is passed with ref.
The call can be passed with argue that has same count of ref as the maide param var count.
The call can be passed with argue that are refs with Types that are same as the Types of the param vars.
The maide state param var is the argue ref.
Param var is get and set as any other local var.
The call results a ref.

Maide that ends without return execute, results ref value zero.

Class node has syntax that starts with "class" index word, followed by Name of class ClassName,
followed by limit brace curve open token, followed by Part of class Part, 
followed by limit brace curve close token.

Comp node has 3 derived nodes.
They are Struct, Glob and Maide.

Struct node has syntax that starts with "struct" index word, followed by Count of class Count, 
followed by Name of class StructName,
followed by limit brace curve open token, followed by Part of class StructPart,
followed by limit brace curve close token.

StructPart is list of Var. The list is delimited by limit semicolon token.

Glob vars are represented with GlobVar.
GlobVar has syntax that starts with "glob" index word, followed by Count of class Count, 
followed by Var of class Var, followed by limit semicolon token.

Maide node has syntax that starts with "maide" index word, followed by Count of class Count, 
followed by Type of class TypeName, followed by Name of class MaideName, 
followed by limit brace round open token,
followed by Param of class Param, followed by limit brace round close token, 
followed by limit brace curve open token, followed by Call of class State, 
followed by limit brace curve close token.
Count is the count of the maide.
Field Type is result Type of the maide.
Name is name of the maide.
Param is the param of the maide.
Call is the state of the maide.

Param node is list of Var. The list is delimited by limit comma token.

CallOperate is operate that call a maide.
The operate has syntax that starts with "call" index word, followed by Class of class ClassName, 
followed by limit dot token, followed by Maide of class MaideName, followed by limit brace round open token, 
followed by Argue of class Argue, followed by limit brace round close token.
Maide with maide name Maide in class Class is called.
Argue is passed into the maide being called.
The operate results ref value that the maide returns.
The operate Type is the result Type of the maide.

Argue node is list of Operate. The list is delimited by limit comma token.

NullOperate is operate that results null ref.
The operate has syntax that is "null" index word.
Null ref has ref value that is zero.
Null ref can be assigned to ref holder of StructType.

GlobVarOperate is operate that results glob var hold ref value.
The operate has syntax that starts with "glob" index word, followed by Class of class ClassName, 
followed by limit dot token, followed by Var of class VarName.
The operate Type is the glob var Type.

GlobVarMark is mark that input glob var.
The mark has syntax that is same as GlobVarOperate.
The mark Type is the glob var Type.

StructVarOperate is operate that results ref that var in struct any holds.
The operate has syntax that starts with This of class Operate, 
followed by limit dot token, followed by Var of class VarName.
Field This is memory index of the struct any.
Field This Type is StructType.
The operate Type is the struct var Type.

StructVarMark is mark that input struct any var.
The mark has syntax that is same as StructVarOperate.
The mark Type is the struct var Type.

VarOperate is operate that results local var hold ref value.
The operate has syntax that is Var of class VarName.
The operate Type is the local var Type.

VarMark is mark that input local var.
The mark has syntax that is same as VarOperate.
The mark Type is the local var Type.

IntKind node represents int kind of different sizes.
The node has syntax that is 1 of 4 index words.
8 bits int kind uses "byte" index word.
16 bits int kind uses "short" index word.
32 bits int kind uses "mid" index word.
64 bits int kind uses "int" index word.
The node has 1 field Value of class Int.
Field Value is index of the int kind.

Sand has Int Value nodes, same as Class Lang.
The values syntaxs valid ints are unsigned 64 bits or signed 64 bits.

TypeName node represent Type of any.
TypeName is base class.
TypeName has 1 derived class.
The derived class is IntTypeName.
IntTypeName is Type name for IntType.
IntTypeName syntax is Kind of class IntKind.
TypeName has 1 derived class.
The derived class is StructTypeName.
StructTypeName is Type name for StructType.
StructTypeName syntax starts with Class of class ClassName, followed by limit dot token,
followed by Struct of class StructName.

Storage node represent storage alloc for var.
Storage syntax start with "val" index word, followed by none orn Count
of class IntDecValue orn Count of class IntHexValue.
Inf it is followed by none, storage with size of count 1 of the any size is alloc.
Inf it is followed by Count, storage with size of count Count of the any size is alloc.
Count is not zero.

Var node represent variable declaration.
Var node syntax starts with "var" index word, followed by Type of class TypeName, 
followed by Var of class VarName, followed optionally by Storage of class Storage.
Type is the the Type of the any of the var.
Var is the name of the var.
Storage is the storage alloc of the var.
Inf Type is IntTypeName and Storage is present, array of any of the IntType is alloc
with the count of the Storage, the var result type is 64 bit IntType, the var result ref
that is memory index of the array, and the var can not be assign to.
Inf Type is StructTypeName and Storage is present, array of any of the StructType is alloc
with the count of the Storage, the var result type is the StructType of the StructTypeName,
the var result ref that is memory index of the array, and the var can not be assign to.
Var that has Storage is 1 dimensional array.

CastOperate is operate that results ref of reinterpret cast to any Type or 
ref of IntType conversion of IntType int.
The operate has syntax that starts with "cast" index word, followed by Type of class TypeName,
followed by limit brace round open token, followed by Any of class Operate, 
followed by limit brace round close token.
Field Type is the Type of result ref.
Any is int any or struct any that is being casted.
Casting IntType Any to IntTypeName is IntType conversion.
Any cast that is not IntType conversion is reinterpret cast.

Calculate memory index with int operation operate lang elements is enough element to
do any calculate of memory index.

IntMemoryOperate is operate that results IntType value get from memory index.
The operate has syntax that starts with Kind of class IntKind, followed by limit brace round open token, 
followed by Any of class Operate, followed by limit brace round close token.
Any is the memory index.
Any has Type that is any Type.
The IntType is int type of Kind.
The operate results IntType value that get from memory index Any.
The operate Type is the IntType.

IntMemoryMark is mark that inputs IntType value set to memory index.
The mark has syntax that is same as IntMemoryOperate.
Any is the memory index.
The IntType is int type of Kind.
The mark inputs IntType value that set to memory index Any.
The mark Type is the IntType.

Mark that is IntType is assigned to store all 64 bits or 8 bits in 1 thread atomic operate
if the IntType is 64 bits or 8 bits.
This is enough element to do any system programming thread sync.

AreExecute is execute that assign ref to mark.
AreExecute has syntax that is same as in Class Lang.

ReturnExecute is execute that refers result and returns to current maide caller.
ReturnExecute has syntax that is same as in Class Lang.
The execute field Result has Type that is the Type of the current maide.

CopyExecute is execute that copies struct any from source to dest.
The execute has syntax that starts with "copy" index word, 
followed by limit brace round open token,
followed by Dest of class Operate, followed by limit comma token, 
followed by Source of class Operate, followed by limit brace round close token, 
followed by limit semicolon token.
Dest is memory index of the copy destination.
Source is memory index of the copy source.
Dest Type is StructType.
Source Type is any Type.
Dest Type is the StructType being copied.
This execute copies struct any of the Dest Type from Source to Dest.

RefCallOperate is operate that call with local var ref value as maide memory index.
The call argue is passed with ref, same as CallOperate.
The call interface is not declared.
The call can be passed with argue that is any integer multiple of ref.
The call can be passed with argue that is any ref.
The call argue list count is not declared.
The call argue list Type is not declared.
The call result Type is 64 bits IntType.
It is programming error, to passed argue with different count of ref with declared param count of the maide, in the call.

RefCallOperate has syntax that starts with "call" index word,
followed by Var of class VarName, followed by limit brace round open token,
followed by Argue of class Argue, followed by limit brace round close token.
Var is the var that hold ref value that is the maide memory index.
Var Type is any Type.
Argue is argue that is passed into the maide being called.
Maide at memory index Var is called with argue Argue passed in.

This is enough element to do any system programming ref call.

RefMaideOperate is operate that results memory index of maide.
The operate has syntax that starts with "ref" index word, 
followed by "maide" index word, followed by Class of class ClassName,
followed by limit dot token, followed by Maide of class MaideName.
Class is the class the maide in.
Maide is the maide name.
Memory index of maide Maide in class Class is resulted.
The operate Type is 64 bits IntType.

RefStructVarOperate is operate that results memory index of struct var.
The operate has syntax that starts with "ref" index word, followed by "struct" index word, 
followed by limit brace round open token, followed by This of class Operate, 
followed by limit brace round close token, followed by limit dot token, followed by Var of class VarName.
Field This Type is StructType.
Memory index of struct var Var in struct any This is resulted.
The operate Type is 64 bits IntType.

RefGlobVarOperate is operate that results memory index of glob var.
The operate has syntax that starts with "ref" index word, followed by "glob" index word, 
followed by Class of class ClassName, followed by limit dot token, followed by Var of class VarName.
Memory index of glob var Var in class Class is resulted.
The operate Type is 64 bits IntType.

RefVarOperate is operate that results memory index of local var.
The operate has syntax that starts with "ref" index word, followed by Var of class VarName.
Memory index of local var Var is resulted.
The operate Type is 64 bits IntType.

SizeOperate is operate that results struct type byte size count.
The operate has syntax that starts with "size" index word, followed by Class of class ClassName, 
followed by limit dot token, followed by Struct of class StructName.
The byte size count of struct type Struct in class Class is resulted.
The operate Type is 64 bits IntType.

LessOperate, AddOperate, SubOperate, MulOperate, DivOperate, SignLessOperate, 
SignMulOperate, SignDivOperate, BitLiteOperate, BitRiteOperate and BitSignRiteOperate 
have syntaxs that are same as Class Lang.
BitAndOperate, BitOrnOperate and BitNotOperate have syntaxs that are same as 
AndOperate, OrnOperate and NotOperate in Class Lang.
The operates input Type is IntType.
The input IntType is any IntKind.
Operates with 2 inputs has same IntType kind in both inputs.
The operates output Type is IntType.
Output that is int value is the IntType of kind that is same as input kind.
Output that is bool value is 64 bit IntType, that is same as bool operation operates output.

Operates that output int values output 64 bits int values in refs.
The operates do 64 bits int operations instead of 60 bits in Class Lang.

IntType any sign extend to more bit count is done with 
BitLiteOperate to shift lite to highest bit, followed by BitSignRiteOperate to 
sign shift rite back to original bit.
This is enough element to do any int sign extend.

This is enough element to do any int sign operation.

This is enough element to do any int operation.

StringValue uses 32 bits int as char unit.
ValueOperate that has StringValue, results memory index of the string struct
any of the string value.
The ValueOperate Type is string StructType.

StringValue is not write able.
This is enough element to do any system programming string operation.

Sand does not need enum.
Sand has StructType and glob var.
Shared list is made with glob var of StructType and init with maide.
This is enough element to do any system programming shared list.

Sand does not need glob var init at glob var declare.
Sand has maide state to do any init.
This is enough element to do any system programming glob init.

Sand Lang does not need lang element to interface to external.
Sand compiler modules have infra to generate module binary.
The generate can be specified to refer the module binary state to custom made machine code binary.
This is enough element to interface to external.

Sand compiler does not optimize output.
This is enough element to do any system programming process module making.