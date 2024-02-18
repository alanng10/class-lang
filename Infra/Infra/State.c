#include "State.h"



InfraClassNew(State)






Int State_Init(Int o)
{
    return true;
}




Int State_Final(Int o)
{
    return true;
}





Int State_GetMaide(Int o)
{
    State* m;

    m = CastPointer(o);


    return m->Maide;
}





Int State_SetMaide(Int o, Int value)
{
    State* m;

    m = CastPointer(o);



    m->Maide = value;



    return true;
}






Int State_GetArg(Int o)
{
    State* m;

    m = CastPointer(o);


    return m->Arg;
}





Int State_SetArg(Int o, Int value)
{
    State* m;

    m = CastPointer(o);



    m->Arg = value;



    return true;
}

