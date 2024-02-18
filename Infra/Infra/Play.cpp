#include "Play.hpp"




CppClassNew(Play)








Int Play_Init(Int o)
{
    Play* m;

    m = CP(o);



    m->Intern = new QMediaPlayer;



    return true;
}





Int Play_Final(Int o)
{
    Play* m;

    m = CP(o);



    delete m->Intern;



    return true;
}






Int Play_GetSource(Int o)
{
    Play* m;

    m = CP(o);


    return m->Source;
}




Int Play_SetSource(Int o, Int value)
{
    Play* m;

    m = CP(o);


    m->Source = value;


    return true;
}






Int Play_SetPlaySource(Int o)
{
    Play* m;

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






Int Play_Execute(Int o)
{
    Play* m;

    m = CP(o);



    m->Intern->play();



    return true;
}





Int Play_Pause(Int o)
{
    Play* m;

    m = CP(o);



    m->Intern->pause();



    return true;
}





Int Play_Stop(Int o)
{
    Play* m;

    m = CP(o);



    m->Intern->stop();



    return true;
}







Int Play_GetVideoOut(Int o)
{
    Play* m;

    m = CP(o);


    return m->VideoOut;
}





Int Play_SetVideoOut(Int o, Int value)
{
    Play* m;

    m = CP(o);



    m->VideoOut = value;




    if (m->VideoOut == null)
    {
        m->Intern->setVideoOutput(null);


        return true;
    }




    Int oa;

    oa = VideoOut_GetIntern(m->VideoOut);




    VideoOutIntern* ua;

    ua = (VideoOutIntern*)oa;




    QVideoSink* u;

    u = ua;




    m->Intern->setVideoOutput(u);




    return true;
}





Int Play_GetAudioOut(Int o)
{
    Play* m;

    m = CP(o);


    return m->AudioOut;
}





Int Play_SetAudioOut(Int o, Int value)
{
    Play* m;

    m = CP(o);



    m->AudioOut = value;



    if (m->AudioOut == null)
    {
        m->Intern->setAudioOutput(null);


        return true;
    }



    Int u;

    u = AudioOut_GetIntern(m->AudioOut);




    QAudioOutput* audioOutput;

    audioOutput = (QAudioOutput*)u;



    m->Intern->setAudioOutput(audioOutput);



    return true;
}






Int Play_HasVideo(Int o)
{
    Play* m;

    m = CP(o);



    bool bu;

    bu = m->Intern->hasVideo();



    Bool a;

    a = bu;

    return a;
}





Int Play_HasAudio(Int o)
{
    Play* m;

    m = CP(o);



    bool bu;

    bu = m->Intern->hasAudio();



    Bool a;

    a = bu;

    return a;
}






Int Play_GetTime(Int o)
{
    Play* m;

    m = CP(o);



    qint64 u;

    u = m->Intern->duration();



    Int a;

    a = u;

    return a;
}





Int Play_SetTime(Int o, Int value)
{
    return true;
}






Int Play_GetPos(Int o)
{
    Play* m;

    m = CP(o);



    qint64 u;

    u = m->Intern->position();



    Int a;

    a = u;

    return a;
}




Int Play_SetPos(Int o, Int value)
{
    Play* m;

    m = CP(o);



    qint64 u;

    u = value;


    m->Intern->setPosition(u);



    return true;
}




