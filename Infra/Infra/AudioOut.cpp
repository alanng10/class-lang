#include "AudioOut.hpp"

CppClassNew(AudioOut)

Int AudioOut_Init(Int o)
{
    AudioOut* m;
    m = CP(o);
    m->Intern = new QAudioOutput;

    AudioOut_MuteSet(o, false);
    return true;
}

Int AudioOut_Final(Int o)
{
    AudioOut* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppFieldGet(AudioOut, Mute)

Int AudioOut_MuteSet(Int o, Int value)
{
    AudioOut* m;
    m = CP(o);

    m->Mute = value;

    bool bu;
    bu = (m->Mute == 0);
    m->Intern->setMuted(bu);
    return true;
}

CppFieldGet(AudioOut, Volume)

Int AudioOut_VolumeSet(Int o, Int value)
{
    AudioOut* m;
    m = CP(o);

    Int minValue;
    minValue = 0;

    Int capValue;
    capValue = Math_Value(null, 1, 0);

    Int k;
    Int b;

    k = Math_Less(null, value, minValue);

    if (k == CastInt(-1))
    {
        return false;
    }

    b = k;
    if (b)
    {
        value = minValue;
    }

    k = Math_Less(null, capValue, value);

    if (k == CastInt(-1))
    {
        return false;
    }

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