#include "Format.h"

InfraClassNew(Format)

#define KindCount 3

Format_ArgValueCountMaide Format_Var_ArgValueCountMaideList[KindCount] =
{
    &Format_ArgValueCountBool,
    &Format_ArgValueCountInt,
    &Format_ArgValueCountString,
};

Format_ArgResultMaide Format_Var_ArgResultMaideList[KindCount] =
{
    &Format_ArgResultBool,
    &Format_ArgResultInt,
    &Format_ArgResultString,
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
    FormatArg* argK;
    argK = CastPointer(arg);

    Int kind;
    kind = argK->Kind;

    Format_ArgValueCountMaide maide;
    maide = Format_Var_ArgValueCountMaideList[kind];

    Int valueCount;
    valueCount = maide(o, arg);

    Int fieldWidth;
    fieldWidth = argK->FieldWidth;

    Int maxWidth;
    maxWidth = argK->MaxWidth;

    SInt u;
    u = maxWidth;

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

    argK->ValueCount = valueCount;
    argK->Count = count;

    return true;
}

Int Format_ArgValueCountBool(Int o, Int arg)
{
    FormatArg* argK;
    argK = CastPointer(arg);

    Bool b;
    b = argK->Value;

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
    FormatArg* argK;
    argK = CastPointer(arg);
    Int value;
    value = argK->Value;
    Int varBase;
    varBase = argK->Base;

    Int count;
    count = Format_IntDigitCount(o, value, varBase);

    Int a;
    a = count;
    return a;
}

Int Format_ArgValueCountString(Int o, Int arg)
{
    FormatArg* argK;
    argK = CastPointer(arg);
    Int a;
    a = String_CountGet(argK->Value);
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
    FormatArg* argK;
    argK = CastPointer(arg);
    Int kind;
    kind = argK->Kind;
    Int resultData;
    resultData = String_ValueGet(result);

    Format_ArgResultMaide maide;
    maide = Format_Var_ArgResultMaideList[kind];

    maide(o, arg, resultData);
    return true;
}

Int Format_ArgResultBool(Int o, Int arg, Int result)
{
    FormatArg* argK;
    argK = CastPointer(arg);
    Int valueCount;
    valueCount = argK->ValueCount;
    Int count;
    count = argK->Count;
    Int value;
    value = argK->Value;
    Bool alignLeft;
    alignLeft = argK->AlignLeft;

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

    Int fillChar;
    fillChar = argK->FillChar;
    Int form;
    form = argK->Form;

    Int fillStart;
    Int valueStart;
    Int valueIndex;
    fillStart = 0;
    valueStart = 0;
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

    Format_ResultBool(o, result, form, value, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(result, fillStart, fillCount, fillChar);
    return true;
}

Int Format_ArgResultInt(Int o, Int arg, Int result)
{
    FormatArg* argK;
    argK = CastPointer(arg);
    Int valueCount;
    valueCount = argK->ValueCount;
    Int count;
    count = argK->Count;
    Int value;
    value = argK->Value;

    Bool alignLeft;
    alignLeft = argK->AlignLeft;

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

    Int varBase;
    varBase = argK->Base;
    Int fillChar;
    fillChar = argK->FillChar;
    Int form;
    form = argK->Form;

    Int fillStart;
    Int valueStart;
    Int valueIndex;
    fillStart = 0;
    valueStart = 0;
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

    Format_ResultInt(o, result, form, value, varBase, valueCount, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(result, fillStart, fillCount, fillChar);
    return true;
}

Int Format_ArgResultString(Int o, Int arg, Int result)
{
    FormatArg* argK;
    argK = CastPointer(arg);
    Int valueCount;
    valueCount = argK->ValueCount;
    Int count;
    count = argK->Count;
    Int value;
    value = argK->Value;

    Int valueData;
    valueData = String_ValueGet(value);

    Bool alignLeft;
    alignLeft = argK->AlignLeft;

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

    Int fillChar;
    fillChar = argK->FillChar;
    Int form;
    form = argK->Form;

    Int fillStart;
    Int valueStart;
    Int valueIndex;
    fillStart = 0;
    valueStart = 0;
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

    Format_ResultString(o, result, form, valueData, valueWriteCount, valueStart, valueIndex);

    Format_ResultFill(result, fillStart, fillCount, fillChar);
    return true;
}

Int Format_ResultBool(Int o, Int result, Int form, Int value, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Bool valueBool;
    valueBool = value;

    const char* source;
    source = Format_Var_FalseString;

    if (valueBool)
    {
        source = Format_Var_TrueString;
    }

    Char* dest;
    dest = CastPointer(result);

    Bool baa;
    baa = (form == null);

    Int formMaide;
    Int formArg;
    formMaide = null;
    formArg = null;

    Format_FormMaide maideA;
    maideA = null;

    if (!baa)
    {
        formMaide = State_MaideGet(form);
        formArg = State_ArgGet(form);
        maideA = (Format_FormMaide)formMaide;
    }

    Int count;
    count = valueWriteCount;
    Int i;
    i = 0;
    while (i < count)
    {
        Int n;
        n = source[i + valueIndex];

        if (!baa)
        {
            n = maideA(formArg, n);
        }

        dest[i + valueStart] = n;

        i = i + 1;
    }
    return true;
}

Int Format_ResultInt(Int o, Int result, Int form, Int value, Int varBase, Int valueCount, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Char* dest;
    dest = CastPointer(result);

    Bool baa;
    baa = (form == null);

    Int formMaide;
    Int formArg;
    formMaide = null;
    formArg = null;

    Format_FormMaide maideA;
    maideA = null;

    if (!baa)
    {
        formMaide = State_MaideGet(form);
        formArg = State_ArgGet(form);
        maideA = (Format_FormMaide)formMaide;
    }

    if (value == 0)
    {
        if (!(valueWriteCount == 0))
        {
            Int na;
            na = '0';

            if (!baa)
            {
                na = maideA(formArg, na);
            }
            dest[valueStart] = na;
        }
        return true;
    }

    Int end;
    end = valueIndex + valueWriteCount;

    Char letterStart;
    letterStart = 'a';

    Int k;
    k = value;

    Int index;
    index = 0;

    Int count;
    count = valueCount;

    Int i;
    i = 0;

    while (i < count)
    {
        Int j;
        j = k / varBase;

        index = count - 1 - i;

        if ((!(index < valueIndex)) & (index < end))
        {
            Int ka;
            ka = k - j * varBase;

            Int digit;
            digit = ka;

            Int n;        
            n = Format_IntDigit(digit, letterStart);

            Int kd;
            kd = index - valueIndex;

            if (!baa)
            {
                n = maideA(formArg, n);
            }

            dest[valueStart + kd] = n;
        }

        k = j;

        i = i + 1;
    }
    return true;
}

Int Format_ResultString(Int o, Int result, Int form, Int value, Int valueWriteCount, Int valueStart, Int valueIndex)
{
    Char* source;
    source = CastPointer(value);
    Char* dest;
    dest = CastPointer(result);

    Bool baa;
    baa = (form == null);

    Int formMaide;
    Int formArg;
    formMaide = null;
    formArg = null;

    Format_FormMaide maideA;
    maideA = null;

    if (!baa)
    {
        formMaide = State_MaideGet(form);
        formArg = State_ArgGet(form);
        maideA = (Format_FormMaide)formMaide;
    }

    Int count;
    count = valueWriteCount;
    Int i;
    i = 0;
    while (i < count)
    {
        Int n;
        n = source[i + valueIndex];

        if (!baa)
        {
            n = maideA(formArg, n);
        }

        dest[i + valueStart] = n;

        i = i + 1;
    }
    return true;
}

Int Format_ExecuteCount(Int o, Int varBase, Int argList)
{
    Int count;
    count = Array_CountGet(argList);

    Int k;
    k = 0;

    Int i;
    i = 0;
    while (i < count)
    {
        Int arg;
        arg = Array_ItemGet(argList, i);

        FormatArg* argK;
        argK = CastPointer(arg);

        Format_ExecuteArgCount(o, arg);

        Int ka;
        ka = argK->Count;

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
    Int baseValue;
    baseValue = String_ValueGet(varBase);
    Int baseCount;
    baseCount = String_CountGet(varBase);
    Char* baseU;
    baseU = CastPointer(baseValue);

    Int argCount;
    argCount = Array_CountGet(argList);

    Int resultData;
    resultData = String_ValueGet(result);
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

Int Format_ResultFill(Int dest, Int fillIndex, Int fillCount, Int fillChar)
{
    Char fillCharK;
    fillCharK = fillChar;

    Char* destK;
    destK = CastPointer(dest);

    Int count;
    count = fillCount;

    Int i;
    i = 0;
    while (i < count)
    {
        destK[fillIndex + i] = fillCharK;
        i = i + 1;
    }

    return true;
}

Int Format_IntDigit(Int digitValue, Int letterStart)
{
    Int k;
    k = 0;

    Bool b;
    b = (digitValue < 10);

    if (b)
    {
        k = '0' + digitValue;
    }

    if (!b)
    {
        Int n;
        n = digitValue - 10;

        k = letterStart + n;
    }

    return k;
}

