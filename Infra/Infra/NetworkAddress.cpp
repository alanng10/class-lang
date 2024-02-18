#include "NetworkAddress.hpp"





CppClassNew(NetworkAddress)







Int NetworkAddress_Init(Int o)
{
    NetworkAddress* m;

    m = CP(o);



    m->Intern = new QHostAddress;



    return true;
}






Int NetworkAddress_Final(Int o)
{
    NetworkAddress* m;

    m = CP(o);



    delete m->Intern;



    return true;
}








Int NetworkAddress_Set(Int o)
{
    NetworkAddress* m;

    m = CP(o);



    Int kind;

    kind = m->Kind;



    if (kind == null)
    {
        return true;
    }




    Int share;

    share = Infra_Share();



    Int stat;

    stat = Share_Stat(share);




    Bool b;


    b = false;




    if ((!b) & (kind == Stat_NetworkAddressKindIPv6(stat)))
    {
        Q_IPV6ADDR u;

        u = { };



        quint8* ua;

        ua = &(u.c[0]);



        Int uu;

        uu = CastInt(ua);




        NetworkAddress_SetValue(o, uu, 0, m->ValueA, 6);


        NetworkAddress_SetValue(o, uu, 6, m->ValueB, 6);


        NetworkAddress_SetValue(o, uu, 12, m->ValueC, 4);




        m->Intern->setAddress(u);



        b = true;
    }





    if ((!b) & (kind == Stat_NetworkAddressKindIPv4(stat)))
    {
        quint32 u;

        u = m->ValueA;



        m->Intern->setAddress(u);



        b = true;
    }




    if (!b)
    {
        QHostAddress::SpecialAddress uu;

        uu = (QHostAddress::SpecialAddress)(kind - 2);



        m->Intern->setAddress(uu);
    }




    return true;
}






Int NetworkAddress_GetKind(Int o)
{
    NetworkAddress* m;

    m = CP(o);


    return m->Kind;
}





Int NetworkAddress_SetKind(Int o, Int value)
{
    NetworkAddress* m;

    m = CP(o);


    m->Kind = value;


    return true;
}






Int NetworkAddress_GetValueA(Int o)
{
    NetworkAddress* m;

    m = CP(o);


    return m->ValueA;
}





Int NetworkAddress_SetValueA(Int o, Int value)
{
    NetworkAddress* m;

    m = CP(o);


    m->ValueA = value;


    return true;
}







Int NetworkAddress_GetValueB(Int o)
{
    NetworkAddress* m;

    m = CP(o);


    return m->ValueB;
}





Int NetworkAddress_SetValueB(Int o, Int value)
{
    NetworkAddress* m;

    m = CP(o);


    m->ValueB = value;


    return true;
}






Int NetworkAddress_GetValueC(Int o)
{
    NetworkAddress* m;

    m = CP(o);


    return m->ValueC;
}





Int NetworkAddress_SetValueC(Int o, Int value)
{
    NetworkAddress* m;

    m = CP(o);


    m->ValueC = value;


    return true;
}






Int NetworkAddress_SetValue(Int o, Int pointer, Int index, Int value, Int count)
{
    Int* sourceU;

    sourceU = &value;



    Int source;

    source = CastInt(sourceU);



    Int dest;

    dest = pointer + index;




    Copy(dest, source, count);




    return true;
}






Int NetworkAddress_GetIntern(Int o)
{
    NetworkAddress* m;

    m = CP(o);



    Int a;

    a = CastInt(m->Intern);



    return a;
}
