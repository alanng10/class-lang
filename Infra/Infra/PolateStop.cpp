#include "PolateStop.hpp"

CppClassNew(PolateStop)

Int PolateStop_Init(Int o)
{
    PolateStop* m;
    m = CP(o);
    Int count;
    count = m->Count;
    
    m->Intern = new QGradientStops;
    m->Intern->resize(count);
    return true;
}

Int PolateStop_Final(Int o)
{
    PolateStop* m;
    m = CP(o);
    
    delete m->Intern;
    
    return true;
}

CppField(PolateStop, Count)

Int PolateStop_PointGetPos(Int o, Int index)
{
    PolateStop* m;
    m = CP(o);

    qsizetype indexU;
    indexU = index;

    QGradientStop* uu;
    uu = (QGradientStop*)(&(m->Intern->at(indexU)));

    qreal posU;
    posU = uu->first;

    ValueFromInternValue(posU);

    Int a;
    a = posUA;
    return a;
}

Int PolateStop_PointGetColor(Int o, Int index)
{
    PolateStop* m;
    m = CP(o);

    qsizetype indexU;
    indexU = index;

    QGradientStop* uu;
    uu = (QGradientStop*)(&(m->Intern->at(indexU)));

    QColor colorU;
    colorU = uu->second;

    QRgb colorUu;
    colorUu = colorU.rgba();
    Int32 colorUa;
    colorUa = (Int32)colorUu;
    Int colorA;
    colorA = colorUa;

    Int a;
    a = colorA;
    return a;
}

Int PolateStop_PointSet(Int o, Int index, Int pos, Int color)
{
    PolateStop* m;
    m = CP(o);

    qsizetype indexU;
    indexU = index;

    InternValue(pos);

    InternColor(color);

    QGradientStop* uu;
    uu = (QGradientStop*)(&(m->Intern->at(indexU)));

    *uu = QGradientStop();

    uu->first = posU;
    uu->second = colorU;
    return true;
}

Int PolateStop_Intern(Int o)
{
    PolateStop* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}