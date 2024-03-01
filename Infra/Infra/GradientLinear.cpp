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


    startLeft = Pos_LeftGet(startPos);

    startUp = Pos_UpGet(startPos);




    Int endLeft;

    Int endUp;


    endLeft = Pos_LeftGet(endPos);

    endUp = Pos_UpGet(endPos);




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

CppField(GradientLinear, StartPos)
CppField(GradientLinear, EndPos)

Int GradientLinear_Intern(Int o)
{
    GradientLinear* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}