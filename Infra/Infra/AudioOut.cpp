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

    Int capValue;
    capValue = Math_Value(null, 1, 0);

    Int k;
    k = Math_Less(null, capValue, value);

    if (k == CastInt(-1))
    {
        return false;
    }

    Int b;
    b = k;
    if (b)
    {
        value = capValue;
    }

    m->Volume = value;

    InternValue(value);

    float uo;
    uo = valueU;
    m->Intern->setVolume(uo);
    return true;
}

Int AudioOut_Intern(Int o)
{
    AudioOut* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}