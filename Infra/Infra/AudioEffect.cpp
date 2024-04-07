#include "AudioEffect.hpp"

CppClassNew(AudioEffect)

Int AudioEffect_Init(Int o)
{
    AudioEffect* m;

    m = CP(o);



    m->Intern = new QSoundEffect();



    Int scaleFactor;

    scaleFactor = 1 << 20;



    m->Volume = scaleFactor;




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