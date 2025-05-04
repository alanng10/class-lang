#include "PointData.hpp"

Int PointData_PointGet(Int memory, Int result)
{
    QPointF* u;
    u = (QPointF*)(memory);

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

Int PointData_PointSet(Int memory, Int pos)
{
    Int aPos;
    aPos = pos;

    PosValue(a);

    InternPosValue(a);

    InternPos(a);

    QPointF* u;
    u = (QPointF*)(memory);
    *u = aPosU;
    return true;
}