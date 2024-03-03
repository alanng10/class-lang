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


    Data_CountSet(m->Data, byteCount);


    Data_ValueSet(m->Data, dataValue);




    return true;
}

Int GradientStop_Final(Int o)
{
    GradientStop* m;

    m = CP(o);




    Int dataValue;

    dataValue = Data_ValueGet(m->Data);



    Data_Final(m->Data);


    Data_Delete(m->Data);



    Delete(dataValue);




    return true;
}

CppField(GradientStop, Count)

Int GradientStop_PointGet(Int o, Int index, Int pos, Int color)
{
    Int oo;
    oo = GradientStop_PointAddress(o, index);

    GradientStopPoint* oa;
    oa = (GradientStopPoint*)oo;



    Int* posU;

    Int* colorU;


    posU = (Int*)pos;

    colorU = (Int*)color;



    *posU = oa->Pos;

    *colorU = oa->Color;



    return true;
}

Int GradientStop_PointSet(Int o, Int index, Int pos, Int color)
{
    Int oo;
    oo = GradientStop_PointAddress(o, index);

    GradientStopPoint* oa;
    oa = (GradientStopPoint*)oo;



    oa->Pos = pos;


    oa->Color = color;




    return true;
}

Int GradientStop_PointAddress(Int o, Int index)
{
    GradientStop* m;

    m = CP(o);




    Int dataValue;

    dataValue = Data_ValueGet(m->Data);



    GradientStopPoint* oo;

    oo = (GradientStopPoint*)(dataValue);


    GradientStopPoint* oa;
    oa = oo + index;

    Int a;
    a = CastInt(oa);
    return a;
}