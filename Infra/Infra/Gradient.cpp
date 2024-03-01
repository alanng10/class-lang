#include "Gradient.hpp"

CppClassNew(Gradient)

Int Gradient_Init(Int o)
{
    Gradient* m;

    m = CP(o);



    Int kind;

    kind = m->Kind;


    Int value;

    value = m->Value;


    Int stop;

    stop = m->Stop;


    Int spread;

    spread = m->Spread;




    if ((kind == null) | (spread == null))
    {
        return true;
    }




    Int share;

    share = Infra_Share();



    Int stat;

    stat = Share_Stat(share);





    QGradient* u;

    u = null;



    Int uo;

    uo = 0;




    if (kind == Stat_GradientKindLinear(stat))
    {
        uo = GradientLinear_GetIntern(value);


        QLinearGradient* ua;

        ua = (QLinearGradient*)uo;


        u = ua;
    }


    if (kind == Stat_GradientKindRadial(stat))
    {
        uo = GradientRadial_GetIntern(value);


        QRadialGradient* ua;

        ua = (QRadialGradient*)uo;


        u = ua;
    }






    QGradientStops ao;



    QGradientStops* po;

    po = &ao;



    Int au;

    au = CastInt(po);




    Gradient_SetInternStop(au, stop);




    QGradient::Spread spreadU;

    spreadU = (QGradient::Spread)(spread - 1);




    u->setStops(ao);


    u->setSpread(spreadU);




    m->Intern = u;





    return true;
}

Int Gradient_Final(Int o)
{
    return true;
}

CppField(Gradient, Kind)
CppField(Gradient, Value)
CppField(Gradient, Stop)
CppField(Gradient, Spread)

Bool Gradient_SetInternStopPoint(Int result, Int pos, Int color)
{
    Int posUu;

    posUu = GetInternValue(pos);



    qreal posU;

    posU = CastIntToDouble(posUu);





    Int32 colorUa;

    colorUa = (Int32)color;



    QRgb colorUb;

    colorUb = colorUa;



    QColor colorU;

    colorU = QColor(colorUb);




    QGradientStop* uu;

    uu = (QGradientStop*)result;



    *uu = QGradientStop();



    uu->first = posU;

    uu->second = colorU;




    return true;
}






Bool Gradient_SetInternStop(Int result, Int stop)
{
    QGradientStops* ua;

    ua = (QGradientStops*)result;





    Int count;

    count = GradientStop_CountGet(stop);





    qsizetype countU;

    countU = count;




    *ua = QGradientStops();



    ua->reserve(countU);






    Int i;

    i = 0;

    while (i < count)
    {
        Int pos;

        Int color;


        Int posU;

        Int colorU;


        posU = CastInt(&pos);

        colorU = CastInt(&color);



        GradientStop_GetPoint(stop, i, posU, colorU);




        QGradientStop aa;



        Int pa;

        pa = CastInt(&aa);




        Gradient_SetInternStopPoint(pa, pos, color);




        ua->append(aa);





        i = i + 1;
    }



    return true;
}







Int Gradient_Intern(Int o)
{
    Gradient* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}