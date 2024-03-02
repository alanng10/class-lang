#include "PointData.hpp"





Bool PointData_GetPoint(Int address, Int result)
{
    QPoint* u;

    u = (QPoint*)(address);




    QPoint point;

    point = *u;



    SInt leftU;

    SInt upU;

    leftU = point.x();

    upU = point.y();



    Int left;

    Int up;


    left = leftU;

    up = upU;



    Pos_LeftSet(result, left);


    Pos_UpSet(result, up);



    return true;
}






Bool PointData_SetPoint(Int address, Int pos)
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


