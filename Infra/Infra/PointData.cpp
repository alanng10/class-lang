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



    Pos_SetLeft(result, left);


    Pos_SetUp(result, up);



    return true;
}






Bool PointData_SetPoint(Int address, Int pos)
{
    Int left;

    Int up;


    left = Pos_GetLeft(pos);

    up = Pos_GetUp(pos);




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


