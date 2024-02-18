#include "AudioOut.hpp"




CppClassNew(AudioOut)







Int AudioOut_Init(Int o)
{
    AudioOut* m;

    m = CP(o);




    m->Intern = new QAudioOutput;




    return true;
}






Int AudioOut_Final(Int o)
{
    AudioOut* m;

    m = CP(o);



    delete m->Intern;



    return true;
}






Int AudioOut_GetMuted(Int o)
{
    AudioOut* m;

    m = CP(o);



    return m->Muted;
}






Int AudioOut_SetMuted(Int o, Int value)
{
    AudioOut* m;

    m = CP(o);



    m->Muted = value;



    bool bu;

    bu = (!(m->Muted == 0));



    m->Intern->setMuted(bu);



    return true;
}







Int AudioOut_GetVolume(Int o)
{
    AudioOut* m;

    m = CP(o);



    return m->Volume;
}





Int AudioOut_SetVolume(Int o, Int value)
{
    AudioOut* m;

    m = CP(o);




    m->Volume = value;





    Int scaleFactor;

    scaleFactor = 1 << 20;



    if (scaleFactor < (m->Volume))
    {
        m->Volume = scaleFactor;
    }





    Int ua;

    ua = GetInternValue(m->Volume);



    qreal uU;

    uU = CastIntToDouble(ua);




    float uo;

    uo = uU;



    m->Intern->setVolume(uo);



    return true;
}








Int AudioOut_GetIntern(Int o)
{
    AudioOut* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}


