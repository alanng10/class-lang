#include "Form.hpp"

CppClassNew(Form)

Int Form_Init(Int o)
{
    Form* m;
    m = CP(o);
    QTransform* transform;
    transform = new QTransform;

    m->Intern = transform;
    return true;
}

Int Form_Final(Int o)
{
    Form* m;
    m = CP(o);
    delete m->Intern;
    return true;
}

Int Form_Reset(Int o)
{
    Form* m;
    m = CP(o);
    m->Intern->reset();
    return true;
}

Int Form_Pos(Int o, Int col, Int row)
{
    Form* m;
    m = CP(o);
    ValidValue(col);
    InternValue(col);
    ValidDouble(colU);

    ValidValue(row);
    InternValue(row);
    ValidDouble(rowU);

    m->Intern->translate(colU, rowU);
    return true;
}

Int Form_Angle(Int o, Int angle)
{
    Form* m;
    m = CP(o);
    ValidValue(angle);
    InternValue(angle);
    ValidDouble(angleU);

    m->Intern->rotate(angleU);
    return true;
}

Int Form_Scale(Int o, Int colScale, Int rowScale)
{
    Form* m;
    m = CP(o);
    ValidValue(colScale);
    InternValue(colScale);
    ValidDouble(colScaleU);

    ValidValue(rowScale);
    InternValue(rowScale);
    ValidDouble(rowScaleU);

    m->Intern->scale(colScaleU, rowScaleU);
    return true;
}

Int Form_ValueGet(Int o, Int col, Int row)
{
    Form* m;
    m = CP(o);
    
    QTransform* k;
    k = m->Intern;
    
    qreal array[3][3] =
    {
        { k->m11(), k->m12(), k->m13() },
        { k->m21(), k->m22(), k->m23() },
        { k->m31(), k->m32(), k->m33() },
    };

    qreal u;
    u = array[row][col];

    ValueFromInternValue(u);

    Int a;
    a = uA;
    return a;
}

Int Form_ValueSet(Int o, Int col, Int row, Int value)
{
    Form* m;
    m = CP(o);

    ValidValue(value);

    InternValue(value);

    ValidDouble(valueU);

    QTransform* k;
    k = m->Intern;

    qreal array[3][3] =
    {
        { k->m11(), k->m12(), k->m13() },
        { k->m21(), k->m22(), k->m23() },
        { k->m31(), k->m32(), k->m33() },
    };

    array[row][col] = valueU;

    k->setMatrix(
        array[0][0], array[0][1], array[0][2],
        array[1][0], array[1][1], array[1][2],
        array[2][0], array[2][1], array[2][2]
    );

    return true;
}

Int Form_Mul(Int o, Int other)
{
    Form* m;
    m = CP(o);
    Int otherU;
    otherU = Form_Intern(other);

    QTransform* uu;
    uu = (QTransform*)otherU;

    (*(m->Intern)) = (*uu) * (*(m->Intern));
    return true;
}

Int Form_Ident(Int o)
{
    Form* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isIdentity();
    Bool a;
    a = bu;
    return a;
}

Int Form_IsInvertible(Int o)
{
    Form* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isInvertible();
    Bool a;
    a = bu;
    return a;
}

Int Form_Invert(Int o, Int result)
{
    Form* m;
    m = CP(o);

    Form* aa;
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
    Form* m;
    m = CP(o);

    Form* aa;
    aa = CP(result);

    QTransform uu;
    uu = m->Intern->transposed();

    *(aa->Intern) = uu;
    return true;
}

Int Form_Intern(Int o)
{
    Form* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}