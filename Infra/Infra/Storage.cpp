#include "Storage.hpp"

CppClassNew(Storage)

Int Storage_Init(Int o)
{
    return true;
}

Int Storage_Final(Int o)
{
    return true;
}

CppField(Storage, Path)
CppField(Storage, Mode)
CppField(Storage, Stream)

CppFieldGet(Storage, Status)
FieldDefaultSet(Storage, Status)

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

    String_QStringSet(uu, path);

    QIODeviceBase::OpenModeFlag modeU;
    modeU = (QIODeviceBase::OpenModeFlag)mode;

    QFile* file;
    file = new QFile;
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

        Stream_KindSet(stream, kind);
        Stream_ValueSet(stream, uo);
        Stream_CanReadSet(stream, canRead);
        Stream_CanWriteSet(stream, canWrite);
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

    Stream_KindSet(stream, null);
    Stream_ValueSet(stream, null);

    m->OpenFile = null;

    m->Status = 0;
    return true;
}

Int Storage_CountSet(Int o, Int value)
{
    Storage* m;
    m = CP(o);

    Int openFile;
    openFile = m->OpenFile;

    QIODevice* oo;
    oo = (QIODevice*)openFile;

    QFile* file;
    file = (QFile*)oo;

    qint64 uo;
    uo = value;

    bool bu;
    bu = file->resize(uo);

    Bool bo;
    bo = bu;

    QFileDevice::FileError ua;
    ua = QFileDevice::NoError;
    if (!bo)
    {
        ua = file->error();
    }

    m->Status = CastInt(ua);
    return true;
}

Int Stream_FlushStorage(Int device)
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