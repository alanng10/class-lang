#include "AudioEffect.hpp"




CppClassNew(AudioEffect)






Bool AudioEffect_Init(Int o)
{
    AudioEffect* m;

    m = CP(o);



    m->Intern = new QSoundEffect();



    Int scaleFactor;

    scaleFactor = 1 << 20;



    m->Volume = scaleFactor;




    return true;
}






Bool AudioEffect_Final(Int o)
{
    AudioEffect* m;

    m = CP(o);



    delete m->Intern;




    return true;
}






Int AudioEffect_GetSource(Int o)
{
    AudioEffect* m;

    m = CP(o);


    return m->Source;
}



Bool AudioEffect_SetSource(Int o, Int value)
{
    AudioEffect* m;

    m = CP(o);


    m->Source = value;


    return true;
}






Int AudioEffect_GetVolume(Int o)
{
    AudioEffect* m;

    m = CP(o);



    return m->Volume;
}





Int AudioEffect_SetVolume(Int o, Int value)
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

    ua = GetInternValue(m->Volume);



    qreal uU;

    uU = CastIntToDouble(ua);




    float uo;

    uo = uU;



    m->Intern->setVolume(uo);



    return true;
}






Bool AudioEffect_SetAudioSource(Int o)
{
    AudioEffect* m;

    m = CP(o);






    QString urlString;


    Int ua;

    ua = CastInt(&urlString);



    String_SetQString(ua, m->Source);





    QUrl url(urlString, QUrl::StrictMode);



    if (!url.isValid())
    {
        return false;
    }




    m->Intern->setSource(url);





    return true;
}





Bool AudioEffect_Play(Int o)
{
    AudioEffect* m;

    m = CP(o);



    m->Intern->play();



    return true;
}




Bool AudioEffect_Stop(Int o)
{
    AudioEffect* m;

    m = CP(o);



    m->Intern->stop();



    return true;
}


