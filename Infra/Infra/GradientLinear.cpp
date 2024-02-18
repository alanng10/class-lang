#include "GradientLinear.hpp"




CppClassNew(GradientLinear)






Int GradientLinear_Init(Int o)
{
    GradientLinear* m;

    m = CP(o);




    Int startPos;

    startPos = m->StartPos;



    Int endPos;

    endPos = m->EndPos;




    Int startLeft;

    Int startUp;


    startLeft = Pos_GetLeft(startPos);

    startUp = Pos_GetUp(startPos);




    Int endLeft;

    Int endUp;


    endLeft = Pos_GetLeft(endPos);

    endUp = Pos_GetUp(endPos);




    InternQReal(startLeft)

    InternQReal(startUp)

    InternQReal(endLeft)

    InternQReal(endUp)




    QLinearGradient* linearGradient;


    linearGradient = new QLinearGradient(startLeftU, startUpU, endLeftU, endUpU);




    m->Intern = linearGradient;




    return true;
}






Int GradientLinear_Final(Int o)
{
    GradientLinear* m;

    m = CP(o);




    delete m->Intern;




    return true;
}







Int GradientLinear_GetStartPos(Int o)
{
    GradientLinear* m;

    m = CP(o);


    return m->StartPos;
}




Bool GradientLinear_SetStartPos(Int o, Int value)
{
    GradientLinear* m;

    m = CP(o);


    m->StartPos = value;


    return true;
}





Int GradientLinear_GetEndPos(Int o)
{
    GradientLinear* m;

    m = CP(o);


    return m->EndPos;
}




Bool GradientLinear_SetEndPos(Int o, Int value)
{
    GradientLinear* m;

    m = CP(o);


    m->EndPos = value;


    return true;
}






Int GradientLinear_GetIntern(Int o)
{
    GradientLinear* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}