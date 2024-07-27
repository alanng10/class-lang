#include "VideoOut.hpp"

CppClassNew(VideoOut)

Int VideoOut_Init(Int o)
{
    VideoOut* m;
    m = CP(o);
    VideoOutIntern* uo;
    uo = new VideoOutIntern;
    uo->VideoOut = o;
    uo->Init();

    m->Intern = uo;
    return true;
}

Int VideoOut_Final(Int o)
{
    VideoOut* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(VideoOut, Frame)
CppField(VideoOut, FrameState)

Int VideoOut_FrameChange(Int o)
{
    VideoOut* m;
    m = CP(o);

    Int state;
    state = m->FrameState;

    if (state == null)
    {
        return true;
    }

    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    if (aa == null)
    {
        return true;
    }

    Int oa;
    oa = m->Frame;

    VideoOut_Frame_Maide maide;
    maide = (VideoOut_Frame_Maide)aa;

    maide(o, oa, arg);

    return true;
}

Int VideoOut_Intern(Int o)
{
    VideoOut* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}