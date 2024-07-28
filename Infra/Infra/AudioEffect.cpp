#include "AudioEffect.hpp"

CppClassNew(AudioEffect)

Int AudioEffect_Init(Int o)
{
    AudioEffect* m;
    m = CP(o);

    m->Intern = new QSoundEffect;

    Int capValue;
    capValue = Math_Value(null, 1, 0);
    
    AudioEffect_VolumeSet(o, capValue);
    return true;
}

Int AudioEffect_Final(Int o)
{
    AudioEffect* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(AudioEffect, Source)
CppFieldGet(AudioEffect, Volume)

Int AudioEffect_VolumeSet(Int o, Int value)
{
    AudioEffect* m;
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

Int AudioEffect_SourceThisSet(Int o)
{
    AudioEffect* m;
    m = CP(o);
    QString urlString;
    Int ua;
    ua = CastInt(&urlString);
    String_QStringSet(ua, m->Source);

    QUrl url(urlString, QUrl::StrictMode);
    if (!url.isValid())
    {
        return false;
    }

    m->Intern->setSource(url);
    return true;
}

Int AudioEffect_Play(Int o)
{
    AudioEffect* m;
    m = CP(o);
    m->Intern->play();
    return true;
}

Int AudioEffect_Stop(Int o)
{
    AudioEffect* m;
    m = CP(o);
    m->Intern->stop();
    return true;
}