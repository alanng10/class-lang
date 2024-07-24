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
    Int left;
    Int up;
    left = Pos_LeftGet(pos);
    up = Pos_UpGet(pos);

    int leftU;
    int upU;
    leftU = left;
    upU = up;

    QPoint point(leftU, upU);

    QPoint* u;
    u = (QPoint*)(address);
    *u = point;
    return true;
}