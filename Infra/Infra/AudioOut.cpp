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

CppFieldGet(AudioOut, Muted)

Int AudioOut_MutedSet(Int o, Int value)
{
    AudioOut* m;

    m = CP(o);



    m->Muted = value;



    bool bu;

    bu = (!(m->Muted == 0));



    m->Intern->setMuted(bu);



    return true;
}

CppFieldGet(AudioOut, Volume)

Int AudioOut_VolumeSet(Int o, Int value)
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

    ua = InternValueGet(m->Volume);



    qreal uU;

    uU = CastIntToDouble(ua);




    float uo;

    uo = uU;



    m->Intern->setVolume(uo);



    return true;
}

Int AudioOut_Intern(Int o)
{
    AudioOut* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}