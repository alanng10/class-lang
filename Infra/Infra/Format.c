#include "Format.h"





InfraClassNew(Format)





#define KindCount 5



Format_ArgValueCountMaide Format_Var_ArgValueCountMaideList[KindCount] =
{
    &Format_ArgValueCountBool,
    &Format_ArgValueCountInt,
    &Format_ArgValueCountString,
    &Format_ArgValueCountChar,
    null,
};



Format_ArgResultMaide Format_Var_ArgResultMaideList[KindCount] =
{
    &Format_ArgResultBool,
    &Format_ArgResultInt,
    &Format_ArgResultString,
    null,
    null,
};



const char* Format_Var_TrueString = "true";

const char* Format_Var_FalseString = "false";




Bool Format_Init(Int this)
{
    return true;
}




Bool Format_Final(Int this)
{
    return true;
}





Int Format_GetBase(Int this)
{
    Format* m = CastPointer(this);



    return m->Base;
}




Bool Format_SetBase(Int this, Int value)
{
    Format* m = CastPointer(this);



    m->Base = value;


    return true;
}





Int Format_GetArgList(Int o)
{
    Format* m;

    m = CastPointer(o);



    return m->ArgList;
}




Int Format_SetArgList(Int o, Int value)
{
    Format* m;

    m = CastPointer(o);


    m->ArgList = value;


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




    Int count;

    count = Format_ArgCount(o, valueCount, fieldWidth, maxWidth);




    oo->HasCount = true;


    oo->ValueCount = valueCount;


    oo->Count = count;




    return true;
}






Int Format_ArgCount(Int o, Int valueCount, Int fieldWidth, Int maxWidth)
{
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



    Int a;

    a = count;


    return a;
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






Int Format_ArgValueCountString(Int o, Int arg)
{
    FormatArg* oo;

    oo = CastPointer(arg);



    Int a;

    a = String_GetCount(oo->Value);



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

    resultData = String_GetData(result);



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



    Bool valueBool;

    valueBool = value;


    const char* uu;

    uu = Format_Var_FalseString;


    if (valueBool)
    {
        uu = Format_Var_TrueString;
    }



    Char* dest;

    dest = CastPointer(result);



    Int fillStart;

    fillStart = 0;



    Int valueStart;

    valueStart = 0;


    Int valueIndex;

    valueIndex = 0;



    Int countA;

    countA = valueCount;

    countA = countA - clampCount;



    if (alignLeft)
    {
        fillStart = countA;


        valueStart = 0;

        valueIndex = 0;
    }



    if (!alignLeft)
    {
        fillStart = 0;


        valueStart = fillCount;


        valueIndex = clampCount;
    }


    char ouc;

    ouc = 0;


    Char oc;

    oc = 0;


    Int index;

    index = 0;


    Int i;

    i = 0;


    while (i < countA)
    {
        index = i + valueIndex;


        ouc = uu[index];


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


    Int varBase;

    varBase = oo->Base;


    Int varCase;

    varCase = oo->Case;



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



    Int valueWriteCount;

    valueWriteCount = valueCount - clampCount;



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



    Char* dest;

    dest = CastPointer(result);


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

    valueData = String_GetData(value);



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



    Int fillChar;

    fillChar = oo->FillChar;



    Char fillCharU;

    fillCharU = fillChar;



    Char* uu;

    uu = CastPointer(valueData);


    Char* dest;

    dest = CastPointer(result);



    Int fillStart;

    fillStart = 0;



    Int valueStart;

    valueStart = 0;


    Int valueIndex;

    valueIndex = 0;



    Int countA;

    countA = valueCount;

    countA = countA - clampCount;



    if (alignLeft)
    {
        fillStart = countA;


        valueStart = 0;

        valueIndex = 0;
    }



    if (!alignLeft)
    {
        fillStart = 0;


        valueStart = fillCount;


        valueIndex = clampCount;
    }



    Int i;

    i = 0;


    while (i < countA)
    {
        dest[i + valueStart] = uu[i + valueIndex];


        i = i + 1;
    }



    Format_ResultFill(dest, fillStart, fillCount, fillCharU);



    return true;
}






Int Format_ResultInt(Int o, Int result, Int value, Int varBase, Int varCase, Int valueCount, Int writeCount, Int valueStart, Int valueIndex)
{
    Char* dest;

    dest = CastPointer(result);




    if (value == 0)
    {
        if (!(writeCount == 0))
        {
            dest[valueStart] = '0';
        }


        return true;
    }




    Int end;

    end = valueIndex + writeCount;



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









//Int Format_GetResultString(Int this)
//{
//    Format* m;
    
//    m = CastPointer(this);


//    return m->ResultString;
//}




//Bool Format_SetResultString(Int this, Int value)
//{
//    Format* m;
    
//    m = CastPointer(this);



//    m->ResultString = value;


//    return true;
//}






//Int Format_ResultCount(Int this)
//{
//    Format* m;
    
//    m = CastPointer(this);




//    Int base;

//    base = m->Base;



//    Int baseCount;

//    baseCount = String_GetCount(base);




//    Int resultCount;

//    resultCount = baseCount;




//    Int arg;
    
//    arg = 0;



//    Int k;
    
//    k = 0;




//    Int count;

//    count = m->ArgCount;



//    Int i;

//    i = 0;


//    while (i < count)
//    {
//        arg = i;



//        k = Format_ArgCount(m, arg);



//        resultCount = resultCount + k;



//        i = i + 1;
//    }



//    Int ret;
    
//    ret = resultCount;


//    return ret;
//}








//Bool Format_Result(Int this)
//{
//    Format* m;
    
//    m = CastPointer(this);




//    Int base;

//    base = m->Base;



//    Int baseCount;

//    baseCount = String_GetCount(base);




//    Int o;

//    o = String_GetData(base);



//    Char* baseChars;


//    baseChars = (Char*)o;






//    Int string;

//    string = m->ResultString;




//    o = String_GetData(string);





//    Char* result;


//    result = (Char*)o;




//    Int resultIndex;

//    resultIndex = 0;




//    Int arg;

//    arg = 0;



//    Int i;

//    i = 0;


//    while (i < baseCount)
//    {
//        Format_ResultIndexArgs(m, i, &arg, result, &resultIndex);




//        result[resultIndex] = baseChars[i];



//        resultIndex = resultIndex + 1;



//        i = i + 1;
//    }



//    Format_ResultIndexArgs(m, baseCount, &arg, result, &resultIndex);




//    return true;
//}





//Bool Format_ResultIndexArgs(Format* this, Int index, Int* argP, Char* result, Int* resultIndexP)
//{
//    Int argCount = this->ArgCount;



//    FormatArg* args = this->Args;



//    Int arg = *argP;



//    Int resultIndex = *resultIndexP;




//    FormatArg* t = null;





//    Bool f;

//    f = false;


//    while ((!f) & (arg < argCount))
//    {
//        t = args + arg;




//        Int k;

//        k = t->Index;



//        Bool ba;

//        ba = (index == k);


//        if (ba)
//        {
//            Int kind;

//            kind = t->Kind;


//            Int value;

//            value = t->Value;



//            Int h;

//            h = (Int)result;



//            Int dest;

//            dest = h + resultIndex;



//            Int length = 0;




//            Format_ArgResultMethod u = null;


//            if (kind == 0)
//            {
//                u = Format_BoolArgResult;
//            }



//            if (kind == 1)
//            {
//                u = Format_IntArgResult;
//            }


//            if (kind == 2)
//            {
//                u = Format_StringArgResult;
//            }




//            u(this, value, dest, &length);




//            resultIndex = resultIndex + length;


//            arg = arg + 1;
//        }


//        if (!ba)
//        {
//            f = true;
//        }
//    }




//    *argP = arg;



//    *resultIndexP = resultIndex;




//    return true;
//}




//Bool Format_BoolArgResult(Format* this, Int value, Int dest, Int* lengthP)
//{
//    Bool b;

//    b = (Bool)value;



//    Int sLength;

//    Int sData;




//    if (b)
//    {
//        sLength = 4;

//        sData = CastInt("true");
//    }



//    if (!b)
//    {
//        sLength = 5;

//        sData = CastInt("false");
//    }



//    Copy(dest, sData, sLength);




//    *lengthP = sLength;



//    return true;
//}





//Bool Format_IntArgResult(Format* this, Int value, Int dest, Int* countP)
//{
//    Int count;

//    count = Format_IntCount(CastInt(this), value);




//    Format_Int(CastInt(this), dest, value, count);




//    *countP = count;



//    return true;
//}





//Bool Format_StringArgResult(Format* this, Int value, Int dest, Int* lengthP)
//{
//    Int o = value;



//    Int length = String_GetCount(o);



//    Int data = String_GetData(o);




//    Copy(dest, data, length);




//    *lengthP = length;



//    return true;
//}











//Int Format_IntHexCount(Int o)
//{
//    return Constant_IntByteCount() * Constant_ByteHexDigitCount();
//}





//Bool Format_IntHex(Int this, Int result, Int n)
//{
//    Char* p;

//    p = (Char*)result;




//    Int k = n;


//    Int byteCount = Constant_IntByteCount();



//    Bool t = Format_VariableCountIntHexResult(p, k, byteCount);



//    Bool ret = t;


//    return ret;
//}





//Int Format_Int32HexCount(Int this)
//{
//    return Constant_Int32ByteCount() * Constant_ByteHexDigitCount();
//}





//Bool Format_Int32Hex(Int this, Int result, Int n)
//{
//    Char* p = (Char*)result;




//    Int k = n;



//    Int byteCount = Constant_Int32ByteCount();




//    Bool t = Format_VariableCountIntHexResult(p, k, byteCount);




//    Bool ret = t;


//    return ret;
//}






