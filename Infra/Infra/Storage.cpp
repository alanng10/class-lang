#include "Storage.hpp"




CppClassNew(Storage)






Bool Storage_Init(Int o)
{
    return true;
}




Bool Storage_Final(Int o)
{
    return true;
}





Int Storage_GetPath(Int o)
{
    Storage* m;

    m = CP(o);


    return m->Path;
}





Bool Storage_SetPath(Int o, Int value)
{
    Storage* m;

    m = CP(o);


    m->Path = value;


    return true;
}




Int Storage_GetMode(Int o)
{
    Storage* m;

    m = CP(o);


    return m->Mode;
}





Bool Storage_SetMode(Int o, Int value)
{
    Storage* m;

    m = CP(o);


    m->Mode = value;


    return true;
}






Int Storage_GetStream(Int o)
{
    Storage* m;

    m = CP(o);


    return m->Stream;
}




Bool Storage_SetStream(Int o, Int value)
{
    Storage* m;

    m = CP(o);


    m->Stream = value;


    return true;
}

Int Storage_GetStatus(Int o)
{
    Storage* m;
    m = CP(o);
    return m->Status;
}

Int Storage_SetStatus(Int o, Int value)
{
    return true;
}

Int Storage_Open(Int o)
{
    Storage* m;

    m = CP(o);



    Int path;

    path = m->Path;



    Int mode;

    mode = m->Mode;



    Int stream;

    stream = m->Stream;





    QString fileName;



    Int uu;

    uu = CastInt(&fileName);




    String_SetQString(uu, path);




    QIODeviceBase::OpenModeFlag modeU;

    modeU = (QIODeviceBase::OpenModeFlag)mode;





    QFile* file;


    file = new QFile();


    file->setFileName(fileName);




    bool bu;


    bu = file->open(modeU);





    QIODevice* oo;

    oo = file;



    Int uo;

    uo = CastInt(oo);





    Bool bo;


    bo = bu;



    QFileDevice::FileError ua;

    ua = QFileDevice::NoError;



    if (!bo)
    {
        ua = file->error();
    }




    if (bo)
    {
        Int aaa;


        aaa = Infra_Share();



        Int stat;

        stat = Share_Stat(aaa);




        Int kind;

        kind = Stat_StreamKindStorage(stat);




        Bool canRead;

        canRead = HasFlag(mode, Stat_StorageModeRead(stat));



        Bool canWrite;

        canWrite = HasFlag(mode, Stat_StorageModeWrite(stat));




        Stream_SetKind(stream, kind);


        Stream_SetValue(stream, uo);



        Stream_SetCanRead(stream, canRead);


        Stream_SetCanWrite(stream, canWrite);
    }





    m->OpenFile = uo;



    m->Status = CastInt(ua);





    return true;
}

Int Storage_Close(Int o)
{
    Storage* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;




    Int openFile;

    openFile = m->OpenFile;




    QIODevice* oo;


    oo = (QIODevice*)openFile;




    QFile* file;


    file = (QFile*)oo;



    file->close();




    delete file;





    Stream_SetKind(stream, null);



    Stream_SetValue(stream, null);




    m->OpenFile = null;



    m->Status = 0;





    return true;
}







Bool Stream_SetStorageCount(Int device, Int value)
{
    QIODevice* ua;

    ua = (QIODevice*)device;



    QFile* file;

    file = (QFile*)ua;




    qint64 uo;

    uo = value;



    bool bu;


    bu = file->resize(uo);





    Bool bo;

    bo = bu;



    return bo;
}






Bool Stream_FlushStorage(Int device)
{
    QIODevice* ua;

    ua = (QIODevice*)device;



    QFile* file;

    file = (QFile*)ua;




    bool bu;


    bu = file->flush();




    Bool bo;

    bo = bu;



    return bo;
}





Int Stream_GetStorageStatus(Int device)
{
    QIODevice* ua;

    ua = (QIODevice*)device;



    QFile* file;

    file = (QFile*)ua;



    QFileDevice::FileError ub;

    ub = file->error();



    Int o;

    o = CastInt(ub);



    return o;
}
