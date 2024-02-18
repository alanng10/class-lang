#include "GradientRadial.hpp"




CppClassNew(GradientRadial)










Bool GradientRadial_Init(Int o)
{
    GradientRadial* m;

    m = CP(o);




    Int centerPos;

    centerPos = m->CenterPos;



    Int centerRadius;

    centerRadius = m->CenterRadius;



    Int focusPos;

    focusPos = m->FocusPos;



    Int focusRadius;

    focusRadius = m->FocusRadius;






    Int centerLeft;

    Int centerUp;


    centerLeft = Pos_GetLeft(centerPos);

    centerUp = Pos_GetUp(centerPos);




    Int focusLeft;

    Int focusUp;


    focusLeft = Pos_GetLeft(focusPos);

    focusUp = Pos_GetUp(focusPos);




    InternQReal(centerLeft)

    InternQReal(centerUp)


    InternQReal(focusLeft)

    InternQReal(focusUp)



    InternQReal(centerRadius)

    InternQReal(focusRadius)






    QRadialGradient* radialGradient;


    radialGradient = new QRadialGradient(centerLeftU, centerUpU, centerRadiusU, focusLeftU, focusUpU, focusRadiusU);




    m->Intern = radialGradient;




    return true;
}






Bool GradientRadial_Final(Int o)
{
    GradientRadial* m;

    m = CP(o);




    delete m->Intern;




    return true;
}







Int GradientRadial_GetCenterPos(Int o)
{
    GradientRadial* m;

    m = CP(o);


    return m->CenterPos;
}




Bool GradientRadial_SetCenterPos(Int o, Int value)
{
    GradientRadial* m;

    m = CP(o);


    m->CenterPos = value;


    return true;
}




Int GradientRadial_GetCenterRadius(Int o)
{
    GradientRadial* m;

    m = CP(o);


    return m->CenterRadius;
}




Bool GradientRadial_SetCenterRadius(Int o, Int value)
{
    GradientRadial* m;

    m = CP(o);


    m->CenterRadius = value;


    return true;
}





Int GradientRadial_GetFocusPos(Int o)
{
    GradientRadial* m;

    m = CP(o);


    return m->FocusPos;
}




Bool GradientRadial_SetFocusPos(Int o, Int value)
{
    GradientRadial* m;

    m = CP(o);


    m->FocusPos = value;


    return true;
}




Int GradientRadial_GetFocusRadius(Int o)
{
    GradientRadial* m;

    m = CP(o);


    return m->FocusRadius;
}




Bool GradientRadial_SetFocusRadius(Int o, Int value)
{
    GradientRadial* m;

    m = CP(o);


    m->FocusRadius = value;


    return true;
}





Int GradientRadial_GetIntern(Int o)
{
    GradientRadial* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}