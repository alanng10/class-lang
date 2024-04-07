#include "Transform.hpp"

CppClassNew(Transform)

Int Transform_Init(Int o)
{
    Transform* m;
    m = CP(o);
    QTransform* transform;
    transform = new QTransform;

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

Int Transform_Reset(Int o)
{
    Transform* m;
    m = CP(o);
    m->Intern->reset();
    return true;
}

Int Transform_Offset(Int o, Int offsetLeft, Int offsetUp)
{
    Transform* m;
    m = CP(o);
    InternValue(offsetLeft);
    InternValue(offsetUp);

    m->Intern->translate(offsetLeftU, offsetUpU);
    return true;
}

Int Transform_Scale(Int o, Int horizScale, Int vertScale)
{
    Transform* m;
    m = CP(o);
    InternValue(horizScale);
    InternValue(vertScale);

    m->Intern->scale(horizScaleU, vertScaleU);
    return true;
}

Int Transform_Rotate(Int o, Int angle)
{
    Transform* m;
    m = CP(o);
    InternValue(angle);

    m->Intern->rotate(angleU);
    return true;
}

Int Transform_ValueGet(Int o, Int row, Int col)
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
    k = ValueGetFromInternValue(uu);

    Int a;
    a = k;
    return a;
}

Int Transform_ValueSet(Int o, Int row, Int col, Int value)
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

Int Transform_Multiply(Int o, Int other)
{
    Transform* m;
    m = CP(o);
    Int otherU;
    otherU = Transform_Intern(other);

    QTransform* uu;
    uu = (QTransform*)otherU;

    (*(m->Intern)) = (*uu) * (*(m->Intern));
    return true;
}

Int Transform_IsIdentity(Int o)
{
    Transform* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isIdentity();
    Bool a;
    a = bu;
    return a;
}

Int Transform_IsInvertible(Int o)
{
    Transform* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isInvertible();
    Bool a;
    a = bu;
    return a;
}

Int Transform_Invert(Int o, Int result)
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

Int Transform_Transpose(Int o, Int result)
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
    k = ValueGetFromInternValue(uu);

    Int a;
    a = k;
    return a;
}

Int Transform_Intern(Int o)
{
    Transform* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}