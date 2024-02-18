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








Int VideoOut_GetFrame(Int o)
{
    VideoOut* m;

    m = CP(o);


    return m->Frame;
}




Int VideoOut_SetFrame(Int o, Int value)
{
    VideoOut* m;

    m = CP(o);


    m->Frame = value;


    return true;
}






Int VideoOut_GetFrameState(Int o)
{
    VideoOut* m;

    m = CP(o);


    return m->FrameState;
}




Int VideoOut_SetFrameState(Int o, Int value)
{
    VideoOut* m;

    m = CP(o);


    m->FrameState = value;


    return true;
}







Int VideoOut_FrameChange(Int o)
{
    VideoOut* m;

    m = CP(o);




    Int state;

    state = m->FrameState;


    Int aa;

    aa = State_GetMaide(state);



    Int arg;

    arg = State_GetArg(state);



    Int oa;

    oa = m->Frame;



    VideoOut_Frame_Maide maide;

    maide = (VideoOut_Frame_Maide)aa;



    if (!(maide == null))
    {
        maide(o, oa, arg);
    }




    return true;
}






Int VideoOut_GetIntern(Int o)
{
    VideoOut* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}


