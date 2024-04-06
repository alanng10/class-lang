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

CppField(Play, Source)

Int Play_SourceThisSet(Int o)
{
    Play* m;
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

CppFieldGet(Play, VideoOut)

Int Play_VideoOutSet(Int o, Int value)
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
    oa = VideoOut_Intern(m->VideoOut);
    VideoOutIntern* ua;
    ua = (VideoOutIntern*)oa;

    QVideoSink* u;
    u = ua;

    m->Intern->setVideoOutput(u);
    return true;
}

CppFieldGet(Play, AudioOut)

Int Play_AudioOutSet(Int o, Int value)
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
    u = AudioOut_Intern(m->AudioOut);

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

Int Play_TimeGet(Int o)
{
    Play* m;
    m = CP(o);
    qint64 u;
    u = m->Intern->duration();
    Int a;
    a = u;
    return a;
}

Int Play_TimeSet(Int o, Int value)
{
    return true;
}

Int Play_PosGet(Int o)
{
    Play* m;
    m = CP(o);
    qint64 u;
    u = m->Intern->position();
    Int a;
    a = u;
    return a;
}

Int Play_PosSet(Int o, Int value)
{
    Play* m;
    m = CP(o);
    qint64 u;
    u = value;
    m->Intern->setPosition(u);
    return true;
}