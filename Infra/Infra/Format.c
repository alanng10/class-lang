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





Int Format_GetArgCount(Int this)
{
    Format* m = CastPointer(this);



    return m->ArgCount;
}




Bool Format_SetArgCount(Int this, Int value)
{
    Format* m = CastPointer(this);




    if (m->Open)
    {
        return true;
    }




    m->ArgCount = value;


    return true;
}





Bool Format_Start(Int this)
{
    Format* m = CastPointer(this);



    Int count;


    count = m->ArgCount * sizeof(FormatArg);




    Int o;

    o = New(count);




    m->Args = (FormatArg*)o;




    m->Open = true;




    return true;
}





Bool Format_End(Int this)
{
    Format* m;
    
    m = CastPointer(this);



    Int o;

    o = CastInt(m->Args);




    Delete(o);




    m->Args = null;



    m->ArgCount = 0;



    m->Open = false;



    return true;
}





Int Format_ArgGetIndex(Int this, Int arg)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    return a->Index;
}





Bool Format_ArgSetIndex(Int this, Int arg, Int value)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    a->Index = value;


    return true;
}






Int Format_ArgGetKind(Int this, Int arg)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    return a->Kind;
}





Bool Format_ArgSetKind(Int this, Int arg, Int value)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    a->Kind = value;


    return true;
}






Int Format_ArgGetValue(Int this, Int arg)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    return a->Value;
}






Bool Format_ArgSetValue(Int this, Int arg, Int value)
{
    Format* m;
    
    m = CastPointer(this);



    FormatArg* a;

    a = (m->Args) + arg;


    a->Value = value;


    return true;
}










Int Format_GetResultString(Int this)
{
    Format* m;
    
    m = CastPointer(this);


    return m->ResultString;
}




Bool Format_SetResultString(Int this, Int value)
{
    Format* m;
    
    m = CastPointer(this);



    m->ResultString = value;


    return true;
}






Int Format_ResultCount(Int this)
{
    Format* m;
    
    m = CastPointer(this);




    Int base;

    base = m->Base;



    Int baseCount;

    baseCount = String_GetCount(base);




    Int resultCount;

    resultCount = baseCount;




    Int arg;
    
    arg = 0;



    Int k;
    
    k = 0;




    Int count;

    count = m->ArgCount;



    Int i;

    i = 0;


    while (i < count)
    {
        arg = i;



        k = Format_ArgCount(m, arg);



        resultCount = resultCount + k;



        i = i + 1;
    }



    Int ret;
    
    ret = resultCount;


    return ret;
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





Bool Format_Result(Int this)
{
    Format* m;
    
    m = CastPointer(this);




    Int base;

    base = m->Base;



    Int baseCount;

    baseCount = String_GetCount(base);




    Int o;

    o = String_GetData(base);



    Char* baseChars;


    baseChars = (Char*)o;






    Int string;

    string = m->ResultString;




    o = String_GetData(string);





    Char* result;


    result = (Char*)o;




    Int resultIndex;

    resultIndex = 0;




    Int arg;

    arg = 0;



    Int i;

    i = 0;


    while (i < baseCount)
    {
        Format_ResultIndexArgs(m, i, &arg, result, &resultIndex);




        result[resultIndex] = baseChars[i];



        resultIndex = resultIndex + 1;



        i = i + 1;
    }



    Format_ResultIndexArgs(m, baseCount, &arg, result, &resultIndex);




    return true;
}





Bool Format_ResultIndexArgs(Format* this, Int index, Int* argP, Char* result, Int* resultIndexP)
{
    Int argCount = this->ArgCount;



    FormatArg* args = this->Args;



    Int arg = *argP;



    Int resultIndex = *resultIndexP;




    FormatArg* t = null;





    Bool f;

    f = false;


    while ((!f) & (arg < argCount))
    {
        t = args + arg;




        Int k;

        k = t->Index;



        Bool ba;

        ba = (index == k);


        if (ba)
        {
            Int kind;

            kind = t->Kind;


            Int value;

            value = t->Value;



            Int h;

            h = (Int)result;



            Int dest;

            dest = h + resultIndex;



            Int length = 0;




            Format_ArgResultMethod u = null;


            if (kind == 0)
            {
                u = Format_BoolArgResult;
            }



            if (kind == 1)
            {
                u = Format_IntArgResult;
            }


            if (kind == 2)
            {
                u = Format_StringArgResult;
            }




            u(this, value, dest, &length);




            resultIndex = resultIndex + length;


            arg = arg + 1;
        }


        if (!ba)
        {
            f = true;
        }
    }




    *argP = arg;



    *resultIndexP = resultIndex;




    return true;
}




Bool Format_BoolArgResult(Format* this, Int value, Int dest, Int* lengthP)
{
    Bool b;

    b = (Bool)value;



    Int sLength;

    Int sData;




    if (b)
    {
        sLength = 4;

        sData = CastInt("true");
    }



    if (!b)
    {
        sLength = 5;

        sData = CastInt("false");
    }



    Copy(dest, sData, sLength);




    *lengthP = sLength;



    return true;
}





Bool Format_IntArgResult(Format* this, Int value, Int dest, Int* countP)
{
    Int count;

    count = Format_IntCount(CastInt(this), value);




    Format_Int(CastInt(this), dest, value, count);




    *countP = count;



    return true;
}





Bool Format_StringArgResult(Format* this, Int value, Int dest, Int* lengthP)
{
    Int o = value;



    Int length = String_GetCount(o);



    Int data = String_GetData(o);




    Copy(dest, data, length);




    *lengthP = length;



    return true;
}











Int Format_IntDigitCount(Int o, Int value, Int varBase)
{
    Int digitCount;

    digitCount = 0;




    Int oa;

    oa = value;




    while (oa > 0)
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






Bool Format_Int(Int this, Int result, Int n, Int digitCount)
{
    Char* buffer = (Char*)result;




    if (n == 0)
    {
        buffer[0] = '0';



        return true;
    }






    Int k = n;




    Int j = 0;




    Byte digit = 0;



    Int o = 0;



    Char c = 0;



    Int index = 0;



    Int count = digitCount;



    Int i = 0;



    while (i < count)
    {
        j = k / 10;




        o = k - j * 10;




        digit = (Byte)o;




        index = count - 1 - i;





        c = digit + '0';




        buffer[index] = c;




        k = j;




        i++;
    }




    return true;
}








Int Format_IntHexCount(Int o)
{
    return Constant_IntByteCount() * Constant_ByteHexDigitCount();
}





Bool Format_IntHex(Int this, Int result, Int n)
{
    Char* p;

    p = (Char*)result;




    Int k = n;


    Int byteCount = Constant_IntByteCount();



    Bool t = Format_VariableCountIntHexResult(p, k, byteCount);



    Bool ret = t;


    return ret;
}





Int Format_Int32HexCount(Int this)
{
    return Constant_Int32ByteCount() * Constant_ByteHexDigitCount();
}





Bool Format_Int32Hex(Int this, Int result, Int n)
{
    Char* p = (Char*)result;




    Int k = n;



    Int byteCount = Constant_Int32ByteCount();




    Bool t = Format_VariableCountIntHexResult(p, k, byteCount);




    Bool ret = t;


    return ret;
}






Bool Format_VariableCountIntHexResult(Char* result, Int n, Int byteCount)
{
    Int count = byteCount * Constant_ByteHexDigitCount();





    Char* buffer = result;




    Char c = 0;




    Int shiftCount = 0;




    Int k = 0;




    Int index = 0;




    Int i = 0;




    while (i < count)
    {
        shiftCount = i * 4;





        k = n >> shiftCount;




        k = k & 0xf;



        
        index = count - 1 - i;




        c = Format_IntHexDigit(k);
        




        buffer[index] = c;





        i = i + 1;
    }




    return true;
}





Int Format_IntHexDigit(Int k)
{
    Char c;




    Byte u;


    u = (Byte)k;



    Bool b;

    b = (u < 10);


    if (b)
    {
        c = '0' + u;
    }


    if (!b)
    {
        Byte n;

        n = u - 10;



        c = 'a' + n;
    }




    return c;
}
