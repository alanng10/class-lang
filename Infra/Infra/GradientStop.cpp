#include "GradientStop.hpp"






CppClassNew(GradientStop)






Int GradientStop_Init(Int o)
{
    GradientStop* m;

    m = CP(o);



    Int count;

    count = m->Count;



    Int pointCount;

    pointCount = sizeof(GradientStopPoint);



    Int byteCount;

    byteCount = count * pointCount;



    Int dataValue;

    dataValue = New(byteCount);




    m->Data = Data_New();


    Data_Init(m->Data);


    Data_SetCount(m->Data, byteCount);


    Data_SetValue(m->Data, dataValue);




    return true;
}





Int GradientStop_Final(Int o)
{
    GradientStop* m;

    m = CP(o);




    Int dataValue;

    dataValue = Data_GetValue(m->Data);



    Data_Final(m->Data);


    Data_Delete(m->Data);



    Delete(dataValue);




    return true;
}






Int GradientStop_GetCount(Int o)
{
    GradientStop* m;

    m = CP(o);


    return m->Count;
}




Int GradientStop_SetCount(Int o, Int value)
{
    GradientStop* m;

    m = CP(o);


    m->Count = value;


    return true;
}






Int GradientStop_GetPoint(Int o, Int index, Int pos, Int color)
{
    GradientStopPoint* oa;

    oa = GradientStop_PointPointer(o, index);



    Int* posU;

    Int* colorU;


    posU = (Int*)pos;

    colorU = (Int*)color;



    *posU = oa->Pos;

    *colorU = oa->Color;



    return true;
}






Int GradientStop_SetPoint(Int o, Int index, Int pos, Int color)
{
    GradientStopPoint* oa;

    oa = GradientStop_PointPointer(o, index);



    oa->Pos = pos;


    oa->Color = color;




    return true;
}






GradientStopPoint* GradientStop_PointPointer(Int o, Int index)
{
    GradientStop* m;

    m = CP(o);




    Int dataValue;

    dataValue = Data_GetValue(m->Data);



    GradientStopPoint* oo;

    oo = (GradientStopPoint*)(dataValue);



    GradientStopPoint* a;

    a = oo + index;


    return a;
}


