#include "StorageArrange.hpp"




CppClassNew(StorageArrange)






Int StorageArrange_Init(Int o)
{
    return true;
}




Int StorageArrange_Final(Int o)
{
    return true;
}






Int StorageArrange_Copy(Int o, Int path, Int destPath)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    QString destPathU;



    Int ub;

    ub = CastInt(&destPathU);



    String_QStringSet(ub, destPath);





    bool bu;


    bu = QFile::copy(pathU, destPathU);




    Bool a;

    a = bu;



    return a;
}







Int StorageArrange_Rename(Int o, Int path, Int destPath)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    QString destPathU;



    Int ub;

    ub = CastInt(&destPathU);



    String_QStringSet(ub, destPath);





    bool bu;


    bu = QFile::rename(pathU, destPathU);




    Bool a;

    a = bu;



    return a;
}






Int StorageArrange_Remove(Int o, Int path)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    bool bu;

    bu = QFile::remove(pathU);




    Bool a;

    a = bu;



    return a;
}







Int StorageArrange_Exist(Int o, Int path)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    bool bu;

    bu = QFile::exists(pathU);




    Bool a;

    a = bu;



    return a;
}






Int StorageArrange_Link(Int o, Int path, Int linkPath)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    QString linkPathU;



    Int ub;

    ub = CastInt(&linkPathU);



    String_QStringSet(ub, linkPath);





    bool bu;


    bu = QFile::link(pathU, linkPathU);




    Bool a;

    a = bu;



    return a;
}






Int StorageArrange_PermitGet(Int o, Int path)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    QFileDevice::Permissions u;

    u = QFile::permissions(pathU);




    QFileDevice::Permissions::Int uu;

    uu = u.toInt();




    Int a;

    a = uu;



    return a;
}







Int StorageArrange_PermitSet(Int o, Int path, Int value)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);





    QFileDevice::Permission ub;

    ub = (QFileDevice::Permission)value;




    QFileDevice::Permissions u;

    u = QFileDevice::Permissions(ub);




    bool bu;


    bu = QFile::setPermissions(pathU, u);




    Bool a;

    a = bu;



    return a;
}







Int StorageArrange_LinkTarget(Int o, Int path)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);




    QString oa;

    oa = QFile::symLinkTarget(pathU);




    QString* ub;

    ub = new QString(oa);




    Int a;

    a = CastInt(ub);



    return a;
}







Int StorageArrange_MoveToTrash(Int o, Int path, Int trashPath)
{
    QString pathU;



    Int ua;

    ua = CastInt(&pathU);




    String_QStringSet(ua, path);





    QString trashPathU;




    bool bu;

    bu = QFile::moveToTrash(pathU, &trashPathU);




    Bool a;

    a = bu;



    if (a)
    {
        QString* ub;

        ub = new QString(trashPathU);




        QString** uu;

        uu = (QString**)trashPath;



        *uu = ub;
    }



    return a;
}