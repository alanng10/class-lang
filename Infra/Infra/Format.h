#pragma once




#include "Probate.h"



#include "Array.h"
#include "FormatArg.h"





typedef struct
{
    Int Base;
    Int ArgList;
}
Format;




typedef Int (*Format_ArgValueCountMaide)(Int o, Int arg);




Int Format_ArgValueCountBool(Int o, Int arg);
Int Format_ArgValueCountInt(Int o, Int arg);
Int Format_ArgValueCountString(Int o, Int arg);
Int Format_ArgValueCountChar(Int o, Int arg);




Int Format_IntDigitCount(Int o, Int value, Int varBase);




typedef Int (*Format_ArgResultMaide)(Int o, Int arg, Int result);



Int Format_ArgResultBool(Int o, Int arg, Int result);

Int Format_ArgResultInt(Int o, Int arg, Int result);

Int Format_ArgResultString(Int o, Int arg, Int result);

Int Format_ArgResultChar(Int o, Int arg, Int result);

Int Format_ResultBool(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex);

Int Format_ResultInt(Int o, Int result, Int value, Int varBase, Int varCase, Int valueCount, Int valueWriteCount, Int valueStart, Int valueIndex);

Int Format_ResultString(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex);



#define Format_IntDigit(digitValue) \
{\
    Bool b;\
\
    b = (digitValue < 10);\
\
\
    if (b)\
    {\
        c = '0' + digitValue;\
    }\
\
\
    if (!b)\
    {\
        Int n;\
\
        n = digitValue - 10;\
\
        c = letterDigitStart + n;\
    }\
}\





#define Format_ResultFill(dest, fillStart, fillCount, fillCharU) \
{\
    Int countOA;\
    countOA = fillCount;\
\
    Int iu;\
    iu = 0;\
\
    while (iu < countOA)\
    {\
        dest[fillStart + iu] = fillCharU;\
\
        iu = iu + 1;\
    }\
}\


