#include "PointData.hpp"

Int PointData_PointGet(Int address, Int result)
{
    QPointF* u;
    u = (QPointF*)(address);

    QPointF point;
    point = *u;

    qreal col;
    qreal row;
    col = point.x();
    row = point.y();

    ValueFromInternValue(col);
    ValueFromInternValue(row);

    Pos_ColSet(result, colA);
    Pos_RowSet(result, rowA);
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