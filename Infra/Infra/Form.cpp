#include "Form.hpp"

CppClassNew(Form)

Int Form_Init(Int o)
{
    Transform* m;
    m = CP(o);
    QTransform* transform;
    transform = new QTransform;

    m->Intern = transform;
    return true;
}

Int Form_Final(Int o)
{
    Transform* m;
    m = CP(o);
    delete m->Intern;
    return true;
}

Int Form_Reset(Int o)
{
    Transform* m;
    m = CP(o);
    m->Intern->reset();
    return true;
}

Int Form_Offset(Int o, Int offsetLeft, Int offsetUp)
{
    Transform* m;
    m = CP(o);
    InternValue(offsetLeft);
    InternValue(offsetUp);

    m->Intern->translate(offsetLeftU, offsetUpU);
    return true;
}

Int Form_Scale(Int o, Int horizScale, Int vertScale)
{
    Transform* m;
    m = CP(o);
    InternValue(horizScale);
    InternValue(vertScale);

    m->Intern->scale(horizScaleU, vertScaleU);
    return true;
}

Int Form_Rotate(Int o, Int angle)
{
    Transform* m;
    m = CP(o);
    InternValue(angle);

    m->Intern->rotate(angleU);
    return true;
}

Int Form_ValueGet(Int o, Int row, Int col)
{
    Transform* m;
    m = CP(o);
    TransformIntern* uo;
    uo = (TransformIntern*)(m->Intern);

    qreal* array;
    array = uo->Value();

    qreal u;
    u = array[row * 3 + col];

    ValueFromInternValue(u);

    Int a;
    a = uA;
    return a;
}

Int Form_ValueSet(Int o, Int row, Int col, Int value)
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

Int Form_Multiply(Int o, Int other)
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

Int Form_IsIdentity(Int o)
{
    Transform* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isIdentity();
    Bool a;
    a = bu;
    return a;
}

Int Form_IsInvertible(Int o)
{
    Transform* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isInvertible();
    Bool a;
    a = bu;
    return a;
}

Int Form_Invert(Int o, Int result)
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

Int Form_Transpose(Int o, Int result)
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

Int Form_Determinant(Int o)
{
    Transform* m;
    m = CP(o);

    qreal u;
    u = m->Intern->determinant();

    ValueFromInternValue(u);

    Int a;
    a = uA;
    return a;
}

Int Form_Intern(Int o)
{
    Transform* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}