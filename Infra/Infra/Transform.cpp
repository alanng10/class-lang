#include "Transform.hpp"




CppClassNew(Transform)







Int Transform_Init(Int o)
{
    Transform* m;

    m = CP(o);




    QTransform* transform;

    transform = new QTransform();



    m->Intern = transform;




    return true;
}






Int Transform_Final(Int o)
{
    Transform* m;

    m = CP(o);



    delete m->Intern;



    return true;
}





Bool Transform_Reset(Int o)
{
    Transform* m;

    m = CP(o);



    m->Intern->reset();



    return true;
}





Bool Transform_Offset(Int o, Int offsetLeft, Int offsetUp)
{
    Transform* m;

    m = CP(o);






    InternValue(offsetLeft);


    InternValue(offsetUp);





    m->Intern->translate(offsetLeftU, offsetUpU);





    return true;
}








Bool Transform_Scale(Int o, Int horizScale, Int vertScale)
{
    Transform* m;

    m = CP(o);




    InternValue(horizScale);



    InternValue(vertScale);





    m->Intern->scale(horizScaleU, vertScaleU);





    return true;
}







Bool Transform_Rotate(Int o, Int angle)
{
    Transform* m;

    m = CP(o);




    InternValue(angle);




    m->Intern->rotate(angleU);




    return true;
}






Int Transform_GetValue(Int o, Int row, Int col)
{
    Transform* m;

    m = CP(o);




    TransformIntern* uo;

    uo = (TransformIntern*)(m->Intern);




    qreal* array;

    array = uo->Value();




    qreal u;

    u = array[row * 3 + col];




    Int uu;

    uu = CastDoubleToInt(u);



    Int k;

    k = GetValueFromInternValue(uu);




    Int a;

    a = k;



    return a;
}





Bool Transform_SetValue(Int o, Int row, Int col, Int value)
{
    Transform* m;

    m = CP(o);





    InternValue(value);




    TransformIntern* uo;

    uo = (TransformIntern*)(m->Intern);




    qreal* array;

    array = uo->Value();




    array[row * 3 + col] = valueU;




    return true;
}







Bool Transform_Multiply(Int o, Int other)
{
    Transform* m;

    m = CP(o);




    Int otherU;

    otherU = Transform_GetIntern(other);



    QTransform* uu;

    uu = (QTransform*)otherU;





    (*(m->Intern)) = (*uu) * (*(m->Intern));





    return true;
}






Bool Transform_IsIdentity(Int o)
{
    Transform* m;

    m = CP(o);




    bool bu;

    bu = m->Intern->isIdentity();



    Bool bo;

    bo = bu;


    return bo;
}





Bool Transform_IsInvertible(Int o)
{
    Transform* m;

    m = CP(o);




    bool bu;

    bu = m->Intern->isInvertible();



    Bool bo;

    bo = bu;


    return bo;
}





Bool Transform_Invert(Int o, Int result)
{
    Transform* m;

    m = CP(o);




    Transform* aa;

    aa = CP(result);




    bool bu;

    bu = false;



    QTransform uu;


    uu = m->Intern->inverted(&bu);




    Bool bo;

    bo = bu;


    if (!bo)
    {
        return false;
    }



    *(aa->Intern) = uu;




    return true;
}






Bool Transform_Transpose(Int o, Int result)
{
    Transform* m;

    m = CP(o);




    Transform* aa;

    aa = CP(result);




    QTransform uu;


    uu = m->Intern->transposed();




    *(aa->Intern) = uu;



    return true;
}






Int Transform_Determinant(Int o)
{
    Transform* m;

    m = CP(o);




    qreal u;

    u = m->Intern->determinant();



    Int uu;

    uu = CastDoubleToInt(u);



    Int k;

    k = GetValueFromInternValue(uu);



    Int oo;

    oo = k;


    return oo;
}







Int Transform_GetIntern(Int o)
{
    Transform* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}