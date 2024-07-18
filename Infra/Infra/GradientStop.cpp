#include "GradientStop.hpp"

CppClassNew(GradientStop)

Int GradientStop_Init(Int o)
{
    GradientStop* m;
    m = CP(o);
    Int count;
    count = m->Count;
    
    m->Intern = new QGradientStops;
    m->Intern->resize(count);
    return true;
}

Int GradientStop_Final(Int o)
{
    GradientStop* m;
    m = CP(o);
    
    delete m->Intern;
    
    return true;
}

CppField(GradientStop, Count)

Int GradientStop_PointGet(Int o, Int index, Int pos, Int color)
{
    GradientStop* m;
    m = CP(o);

    qsizetype indexU;
    indexU = index;

    QGradientStop* uu;
    uu = (QGradientStop*)(&(m->Intern->at(indexU)));

    qreal posU;
    posU = uu->first;
    Int posUu;
    posUu = CastDoubleToInt(posU);
    Int posA;
    posA = ValueGetFromInternValue(posUu);

    QColor colorU;
    colorU = uu->second;
    QRgb colorUu;
    colorUu = colorU.rgba();
    Int32 colorUa;
    colorUa = (Int32)colorUu;
    Int colorA;
    colorA = colorUa;

    Int* posAa;
    Int* colorAa;
    posAa = (Int*)pos;
    colorAa = (Int*)color;

    *posAa = posA;
    *colorAa = colorA;
    return true;
}

Int GradientStop_PointSet(Int o, Int index, Int pos, Int color)
{
    GradientStop* m;
    m = CP(o);

    qsizetype indexU;
    indexU = index;

    Int posUu;
    posUu = InternValueGet(pos);
    qreal posU;
    posU = CastIntToDouble(posUu);

    Int32 colorUa;
    colorUa = (Int32)color;
    QRgb colorUb;
    colorUb = colorUa;
    QColor colorU;
    colorU = QColor(colorUb);

    QGradientStop* uu;
    uu = (QGradientStop*)&(m->Intern->at(indexU));

    *uu = QGradientStop();

    uu->first = posU;
    uu->second = colorU;
    return true;
}