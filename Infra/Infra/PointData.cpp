#include "PointData.hpp"

Int PointData_PointGet(Int address, Int result)
{
    QPointF* u;
    u = (QPointF*)(address);

    QPointF point;
    point = *u;

    qreal left;
    qreal up;
    left = point.x();
    up = point.y();

    ValueFromInternValue(left);
    ValueFromInternValue(up);

    Pos_LeftSet(result, leftA);
    Pos_UpSet(result, upA);
    return true;
}

Int PointData_PointSet(Int address, Int pos)
{
    Int aPos;
    aPos = pos;

    PosValue(a);

    InternPosValue(a);

    InternPos(a);

    QPointF* u;
    u = (QPointF*)(address);
    *u = aPosU;
    return true;
}