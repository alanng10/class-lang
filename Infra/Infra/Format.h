#pragma once




#include "Probate.h"




#include "FormatArg.h"





typedef struct
{
    Int Base;


    Int ArgList;
}
Format;





Int Format_ArgCount(Int o, Int valueCount, Int fieldWidth, Int maxWidth);




typedef Int (*Format_ArgValueCountMaide)(Int o, Int arg);




Int Format_ArgValueCountBool(Int o, Int arg);


Int Format_ArgValueCountInt(Int o, Int arg);


Int Format_ArgValueCountString(Int o, Int arg);


Int Format_ArgValueCountChar(Int o, Int arg);




Int Format_IntDigitCount(Int o, Int value, Int varBase);




Bool Format_VariableCountIntHexResult(Char* result, Int n, Int byteCount);









Bool Format_ResultIndexArgs(Format* o, Int index, Int* argP, Char* result, Int* resultIndexP);






typedef Bool (*Format_ArgResultMethod)(Format* o, Int value, Int dest, Int* lengthP);





Bool Format_BoolArgResult(Format* o, Int value, Int dest, Int* lengthP);



Bool Format_IntArgResult(Format* o, Int value, Int dest, Int* lengthP);



Bool Format_StringArgResult(Format* o, Int value, Int dest, Int* lengthP);
