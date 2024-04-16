#include "Format.h"

InfraClassNew(Format)

#define KindCount 5

Format_ArgValueCountMaide Format_Var_ArgValueCountMaideList[KindCount] =
{
    &Format_ArgValueCountBool,
    &Format_ArgValueCountInt,
    &Format_ArgValueCountSInt,
    &Format_ArgValueCountString,
    &Format_ArgValueCountChar,
};

Format_ArgResultMaide Format_Var_ArgResultMaideList[KindCount] =
{
    &Format_ArgResultBool,
    &Format_ArgResultInt,
    &Format_ArgResultSInt,
    &Format_ArgResultString,
    &Format_ArgResultChar,
};

const char* Format_Var_TrueString = "true";
const char* Format_Var_FalseString = "false";

Int Format_Init(Int o)
{
    return true;
}

Int Format_Final(Int o)
{
    return true;
}

Int Format_ExecuteArgCount(Int o, Int arg)
{
    FormatArg* oo;
    oo = CastPointer(arg);

    Int kind;
    kind = oo->Kind;

    Format_ArgValueCountMaide maide;
    maide = Format_Var_ArgValueCountMaideList[kind];

    Int valueCount;
    valueCount = maide(o, arg);

    Int fieldWidth;
    fieldWidth = oo->FieldWidth;

    Int maxWidth;
    maxWidth = oo->MaxWidth;

    SInt u;
    u = maxWidth;
    u = u << 4;
    u = u >> 4;

    Int count;
    count = valueCount;

    if (count < fieldWidth)
    {
        count = fieldWidth;
    }

    if (!(u == -1))
    {
        if (maxWidth < count)
        {
            count = maxWidth;
        }
    }

    oo->HasCount = true;
    oo->ValueCount = valueCount;
    oo->Count = count;

    return true;
}

Int Format_ArgValueCountBool(Int o, Int arg)
{
    FormatArg* oo;
    oo = CastPointer(arg);

    Bool b;
    b = oo->Value;

    Int count;
    count = 5;
    if (b)
    {
        count = 4;
    }

    Int a;
    a = count;
    return a;
}

Int Format_ArgValueCountInt(Int o, Int arg)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int value;
    value = oo->Value;
    Int base;
    base = oo->Base;

    Int count;
    count = Format_IntDigitCount(o, value, base);

    Int a;
    a = count;
    return a;
}

Int Format_ArgValueCountSInt(Int o, Int arg)
{
    FormatArg* oo;
    oo = CastPointer(arg);

    Int value;
    value = oo->Value;
    Int base;
    base = oo->Base;
    Int sign;
    sign = oo->Sign;

    SInt valueA;
    valueA = value;
    valueA = valueA << 4;
    valueA = valueA >> 4;

    SInt oa;
    oa = valueA;

    Bool b;
    b = (oa < 0);

    Bool hasSign;
    hasSign = false;

    if (!b)
    {
        if (sign == 1)
        {
            hasSign = true;
        }
        if ((!(oa == 0)) & (sign == 2))
        {
            hasSign = true;
        }
    }
    if (b)
    {
        hasSign = true;
    }

    if (b)
    {
        oa = -oa;
    }

    Int ua;
    ua = oa;

    Int count;
    count = Format_IntDigitCount(o, ua, base);

    if (hasSign)
    {
        count = count + 1;
    }

    Int a;
    a = count;
    return a;
}

Int Format_ArgValueCountString(Int o, Int arg)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int a;
    a = String_CountGet(oo->Value);
    return a;
}

Int Format_ArgValueCountChar(Int o, Int arg)
{
    Int a;
    a = 1;
    return a;
}

Int Format_IntDigitCount(Int o, Int value, Int varBase)
{
    Int digitCount;
    digitCount = 0;

    Int oa;
    oa = value;
    while (0 < oa)
    {
        oa = oa / varBase;
        digitCount = digitCount + 1;
    }

    if (digitCount == 0)
    {
        digitCount = 1;
    }

    Int a;
    a = digitCount;
    return a;
}

Int Format_ExecuteArgResult(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int kind;
    kind = oo->Kind;
    Int resultData;
    resultData = String_DataGet(result);

    Format_ArgResultMaide maide;
    maide = Format_Var_ArgResultMaideList[kind];

    maide(o, arg, resultData);
    return true;
}

Int Format_ArgResultBool(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int valueCount;
    valueCount = oo->ValueCount;
    Int count;
    count = oo->Count;
    Int value;
    value = oo->Value;
    Bool alignLeft;
    alignLeft = oo->AlignLeft;

    Int fillCount;
    fillCount = 0;
    Int clampCount;
    clampCount = 0;

    if (valueCount < count)
    {
        fillCount = count - valueCount;
    }

    if (count < valueCount)
    {
        clampCount = valueCount - count;
    }

    Int varCase;
    varCase = oo->Case;
    Int fillChar;
    fillChar = oo->FillChar;

    Char fillCharU;
    fillCharU = fillChar;

    Char* dest;
    dest = CastPointer(result);

    Int fillStart;
    fillStart = 0;
    Int valueStart;
    valueStart = 0;
    Int valueIndex;
    valueIndex = 0;

    Int valueWriteCount;
    valueWriteCount = valueCount - clampCount;

    if (alignLeft)
    {
        fillStart = valueWriteCount;
        valueStart = 0;
        valueIndex = 0;
    }

    if (!alignLeft)
    {
        fillStart = 0;
        valueStart = fillCount;
        valueIndex = clampCount;
    }

    Format_ResultBool(o, result, value, varCase, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(dest, fillStart, fillCount, fillCharU);
    return true;
}

Int Format_ArgResultInt(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int valueCount;
    valueCount = oo->ValueCount;
    Int count;
    count = oo->Count;
    Int value;
    value = oo->Value;

    Bool alignLeft;
    alignLeft = oo->AlignLeft;

    Int fillCount;
    fillCount = 0;
    Int clampCount;
    clampCount = 0;

    if (valueCount < count)
    {
        fillCount = count - valueCount;
    }

    if (count < valueCount)
    {
        clampCount = valueCount - count;
    }

    Char* dest;
    dest = CastPointer(result);

    Int varBase;
    varBase = oo->Base;
    Int varCase;
    varCase = oo->Case;
    Int fillChar;
    fillChar = oo->FillChar;

    Char fillCharU;
    fillCharU = fillChar;

    Int fillStart;
    fillStart = 0;
    Int valueStart;
    valueStart = 0;
    Int valueIndex;
    valueIndex = 0;

    Int valueWriteCount;
    valueWriteCount = valueCount - clampCount;

    if (alignLeft)
    {
        fillStart = valueWriteCount;
        valueStart = 0;
        valueIndex = 0;
    }

    if (!alignLeft)
    {
        fillStart = 0;
        valueStart = fillCount;
        valueIndex = clampCount;
    }

    Format_ResultInt(o, result, value, varBase, varCase, valueCount, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(dest, fillStart, fillCount, fillCharU);
    return true;
}

Int Format_ArgResultSInt(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int valueCount;
    valueCount = oo->ValueCount;
    Int count;
    count = oo->Count;
    Int value;
    value = oo->Value;

    Bool alignLeft;
    alignLeft = oo->AlignLeft;

    Int fillCount;
    fillCount = 0;
    Int clampCount;
    clampCount = 0;

    if (valueCount < count)
    {
        fillCount = count - valueCount;
    }

    if (count < valueCount)
    {
        clampCount = valueCount - count;
    }

    Char* dest;
    dest = CastPointer(result);

    Int varBase;
    varBase = oo->Base;
    Int varCase;
    varCase = oo->Case;
    Int fillChar;
    fillChar = oo->FillChar;

    Char fillCharU;
    fillCharU = fillChar;

    Int fillStart;
    fillStart = 0;
    Int valueStart;
    valueStart = 0;
    Int valueIndex;
    valueIndex = 0;

    Int sign;
    sign = oo->Sign;

    SInt valueA;
    valueA = value;
    valueA = valueA << 4;
    valueA = valueA >> 4;

    SInt oa;
    oa = valueA;

    Bool b;
    b = (oa < 0);

    Bool hasSign;
    hasSign = false;

    if (!b)
    {
        if (sign == 1)
        {
            hasSign = true;
        }
        if ((!(oa == 0)) & (sign == 2))
        {
            hasSign = true;
        }
    }

    if (b)
    {
        hasSign = true;
    }

    if (b)
    {
        oa = -oa;
    }

    Int ua;
    ua = oa;

    Int ub;
    ub = valueCount;

    if (hasSign)
    {
        ub = ub - 1;
    }

    Int unsignedWriteCount;
    unsignedWriteCount = valueCount - clampCount;

    Bool ba;
    ba = false;

    Int signIndex;
    signIndex = 0;

    if (alignLeft)
    {
        fillStart = valueCount - clampCount;

        valueStart = 0;

        valueIndex = 0;

        if (hasSign)
        {
            valueStart = valueStart + 1;

            if (0 < unsignedWriteCount)
            {
                unsignedWriteCount = unsignedWriteCount - 1;
            }

            if (0 < count)
            {
                signIndex = 0;
                ba = true;
            }
        }
    }

    if (!alignLeft)
    {
        fillStart = 0;

        valueStart = fillCount;

        valueIndex = clampCount;

        if (hasSign)
        {
            if (clampCount == 0)
            {
                valueStart = valueStart + 1;

                if (0 < unsignedWriteCount)
                {
                    unsignedWriteCount = unsignedWriteCount - 1;
                }

                signIndex = fillCount;
                ba = true;
            }

            if (0 < clampCount)
            {
                valueIndex = valueIndex - 1;
            }
        }
    }

    Format_ResultInt(o, result, ua, varBase, varCase, ub, unsignedWriteCount, valueStart, valueIndex);

    if (ba)
    {
        Char ooc;
        ooc = '+';

        if (b)
        {
            ooc = '-';
        }

        dest[signIndex] = ooc;
    }

    Format_ResultFill(dest, fillStart, fillCount, fillCharU);
    return true;
}

Int Format_ArgResultString(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int valueCount;
    valueCount = oo->ValueCount;
    Int count;
    count = oo->Count;
    Int value;
    value = oo->Value;

    Int valueData;
    valueData = String_DataGet(value);

    Bool alignLeft;
    alignLeft = oo->AlignLeft;

    Int fillCount;
    fillCount = 0;
    Int clampCount;
    clampCount = 0;

    if (valueCount < count)
    {
        fillCount = count - valueCount;
    }

    if (count < valueCount)
    {
        clampCount = valueCount - count;
    }

    Int varCase;
    varCase = oo->Case;
    Int fillChar;
    fillChar = oo->FillChar;

    Char fillCharU;
    fillCharU = fillChar;

    Char* dest;
    dest = CastPointer(result);

    Int fillStart;
    fillStart = 0;
    Int valueStart;
    valueStart = 0;
    Int valueIndex;
    valueIndex = 0;

    Int valueWriteCount;
    valueWriteCount = valueCount - clampCount;

    if (alignLeft)
    {
        fillStart = valueWriteCount;
        valueStart = 0;
        valueIndex = 0;
    }

    if (!alignLeft)
    {
        fillStart = 0;
        valueStart = fillCount;
        valueIndex = clampCount;
    }

    Format_ResultString(o, result, valueData, varCase, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(dest, fillStart, fillCount, fillCharU);
    return true;
}

Int Format_ArgResultChar(Int o, Int arg, Int result)
{
    FormatArg* oo;
    oo = CastPointer(arg);
    Int valueCount;
    valueCount = oo->ValueCount;
    Int count;
    count = oo->Count;
    Int value;
    value = oo->Value;
    Char valueChar;
    valueChar = value;

    Bool alignLeft;
    alignLeft = oo->AlignLeft;

    Int fillCount;
    fillCount = 0;
    Int clampCount;
    clampCount = 0;

    if (valueCount < count)
    {
        fillCount = count - valueCount;
    }

    if (count < valueCount)
    {
        clampCount = valueCount - count;
    }

    Int varCase;
    varCase = oo->Case;
    Int fillChar;
    fillChar = oo->FillChar;

    Char fillCharU;
    fillCharU = fillChar;

    Char* dest;
    dest = CastPointer(result);

    Int valueData;
    valueData = CastInt(&valueChar);

    Int fillStart;
    fillStart = 0;
    Int valueStart;
    valueStart = 0;
    Int valueIndex;
    valueIndex = 0;

    Int valueWriteCount;
    valueWriteCount = valueCount - clampCount;

    if (alignLeft)
    {
        fillStart = valueWriteCount;
        valueStart = 0;
        valueIndex = 0;
    }

    if (!alignLeft)
    {
        fillStart = 0;
        valueStart = fillCount;
        valueIndex = clampCount;
    }

    Format_ResultString(o, result, valueData, varCase, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(dest, fillStart, fillCount, fillCharU);
    return true;
}

Int Format_ResultBool(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Char* dest;
    dest = CastPointer(result);

    Bool valueBool;
    valueBool = value;

    const char* source;
    source = Format_Var_FalseString;

    if (valueBool)
    {
        source = Format_Var_TrueString;
    }

    char ouc;
    ouc = 0;
    Char oc;
    oc = 0;
    Int index;
    index = 0;
    Int count;
    count = valueWriteCount;
    Int i;
    i = 0;
    while (i < count)
    {
        index = i + valueIndex;

        ouc = source[index];
        oc = ouc;

        if (varCase == 1)
        {
            if (index == 0)
            {
                oc = ouc - 'a' + 'A';
            }
        }
        if (varCase == 2)
        {
            oc = ouc - 'a' + 'A';
        }

        dest[i + valueStart] = oc;

        i = i + 1;
    }
    return true;
}

Int Format_ResultInt(Int o, Int result, Int value, Int varBase, Int varCase, Int valueCount, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Char* dest;
    dest = CastPointer(result);

    if (value == 0)
    {
        if (!(valueWriteCount == 0))
        {
            dest[valueStart] = '0';
        }
        return true;
    }

    Int end;
    end = valueIndex + valueWriteCount;

    Int k;
    k = value;
    Int j;
    j = 0;
    Int digit;
    digit = 0;
    Int oa;
    oa = 0;
    Char c;
    c = 0;
    Bool upperCase;
    upperCase = varCase;
    Char letterDigitStart;
    letterDigitStart = 'a';
    if (upperCase)
    {
        letterDigitStart = 'A';
    }

    Int index;
    index = 0;
    Int count;
    count = valueCount;
    Int i;
    i = 0;
    while (i < count)
    {
        j = k / varBase;

        digit = k - j * varBase;

        index = count - 1 - i;

        if ((!(index < valueIndex)) && index < end)
        {
            Format_IntDigit(digit);

            oa = index - valueIndex;

            dest[valueStart + oa] = c;
        }

        k = j;

        i = i + 1;
    }
    return true;
}

Int Format_ResultString(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Char* source;
    source = CastPointer(value);
    Char* dest;
    dest = CastPointer(result);

    Char ouc;
    ouc = 0;
    Char oc;
    oc = 0;
    Int count;
    count = valueWriteCount;
    Int i;
    i = 0;
    while (i < count)
    {
        ouc = source[i + valueIndex];

        oc = ouc;

        if (varCase == 1)
        {
            if (!((ouc < 'A') | ('Z' < ouc)))
            {
                oc = ouc - 'A' + 'a';
            }
        }
        if (varCase == 2)
        {
            if (!((ouc < 'a') | ('z' < ouc)))
            {
                oc = ouc - 'a' + 'A';
            }
        }

        dest[i + valueStart] = oc;

        i = i + 1;
    }
    return true;
}

Int Format_ExecuteCount(Int o, Int varBase, Int argList)
{
    Int count;
    count = Array_CountGet(argList);
    Int arg;
    arg = null;
    FormatArg* oa;
    oa = null;
    Int ka;
    ka = 0;
    Int k;
    k = 0;
    Bool b;
    b = false;
    Int i;
    i = 0;
    while (i < count)
    {
        arg = Array_ItemGet(argList, i);

        oa = CastPointer(arg);

        b = oa->HasCount;

        if (!b)
        {
            Format_ExecuteArgCount(o, arg);
        }

        ka = oa->Count;

        k = k + ka;

        i = i + 1;
    }

    Int baseCount;
    baseCount = String_CountGet(varBase);

    k = k + baseCount;

    Int a;
    a = k;
    return a;
}

Int Format_ExecuteResult(Int o, Int varBase, Int argList, Int result)
{
    Int baseCount;
    baseCount = String_CountGet(varBase);

    Int baseData;
    baseData = String_DataGet(varBase);

    Char* baseU;
    baseU = CastPointer(baseData);

    Int argCount;
    argCount = Array_CountGet(argList);

    Int resultData;
    resultData = String_DataGet(result);

    Char* resultU;
    resultU = CastPointer(resultData);

    Int count;
    count = baseCount + 1;

    Int resultIndex;
    resultIndex = 0;

    Int arg;
    arg = null;

    Int argIndex;
    argIndex = 0;

    FormatArg* oo;
    oo = null;

    Bool b;
    b = false;

    Int k;
    k = 0;

    Bool ba;
    ba = false;

    Int kind;
    kind = 0;

    Int countA;
    countA = 0;

    Char* ua;
    ua = null;

    Int oa;
    oa = null;

    Format_ArgResultMaide maide;
    maide = null;

    Int i;
    i = 0;

    while (i < count)
    {
        b = false;

        while ((!b) & (argIndex < argCount))
        {
            arg = Array_ItemGet(argList, argIndex);

            oo = CastPointer(arg);

            k = oo->Pos;

            ba = (i == k);

            if (ba)
            {
                kind = oo->Kind;

                countA = oo->Count;

                ua = resultU + resultIndex;

                oa = CastInt(ua);

                maide = Format_Var_ArgResultMaideList[kind];

                maide(o, arg, oa);

                resultIndex = resultIndex + countA;

                argIndex = argIndex + 1;
            }

            if (!ba)
            {
                b = true;
            }
        }

        if (!(i == baseCount))
        {
            resultU[resultIndex] = baseU[i];

            resultIndex = resultIndex + 1;
        }


        i = i + 1;
    }



    return true;
}