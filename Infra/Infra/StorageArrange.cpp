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

    QDir dir;
    
    bool bu;
    bu = dir.rename(pathU, destPathU);

    Bool a;
    a = bu;
    return a;
}

Int StorageArrange_FileCopy(Int o, Int path, Int destPath)
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

Int StorageArrange_FileRemove(Int o, Int path)
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


Int StorageArrange_FoldCreate(Int o, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QDir dir;
    
    bool bu;
    bu = dir.mkpath(pathU);

    Bool a;
    a = bu;
    return a;
}

Int StorageArrange_FoldCopy(Int o, Int path, Int destPath)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QString destPathU;
    Int ub;
    ub = CastInt(&destPathU);
    String_QStringSet(ub, destPath);

    Bool a;
    a = StorageArrange_FoldCopyRecurse(o, ua, ub);
    return a;
}

Int StorageArrange_FoldCopyRecurse(Int o, Int path, Int destPath)
{
    QString pathA;
    QString destPathA;
    pathA = *((QString*)path);
    destPathA = *((QString*)destPath);

    bool bu;

    QDir dir;
    bu = dir.mkpath(destPathA);
    if (!bu)
    {
        return false;
    }

    QDir dirA(pathA);

    QStringList foldList;
    foldList = dirA.entryList(QDir::Dirs | QDir::NoDotAndDotDot);

    qsizetype countU;
    countU = foldList.count();
    
    Int count;
    count = countU;
    Int i;
    i = 0;
    while (i < count)
    {
        qsizetype indexU;
        indexU = i;

        QString fold;
        fold = foldList.at(indexU);

        QString newPath;
        newPath = pathA + "/" + fold;

        QString newDestPath;
        newDestPath = destPathA + "/" + fold;

        Int uua;
        Int uub;
        uua = CastInt(&newPath);
        uub = CastInt(&newDestPath);
        
        Bool ba;
        ba = StorageArrange_FoldCopyRecurse(o, uua, uub);
        if (!ba)
        {
            return false;
        }

        i = i + 1;
    }

    QStringList fileList;
    fileList = dirA.entryList(QDir::Files);

    countU = fileList.count();
    
    count = countU;
    i = 0;
    while (i < count)
    {
        qsizetype indexU;
        indexU = i;
        
        QString file;
        file = fileList.at(indexU);

        QString newPathA;
        newPathA = pathA + "/" + file;

        QString newDestPathA;
        newDestPathA = destPathA + "/" + file;

        bool bua;
        bua = QFile::copy(newPathA, newDestPathA);
        if (!bua)
        {
            return false;
        }

        i = i + 1;
    }

    return true;
}

Int StorageArrange_FoldRemove(Int o, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QDir dir(pathU);

    bool bu;
    bu = dir.removeRecursively();

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

Int StorageArrange_FoldList(Int o, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QDir dirA(pathU);

    QStringList foldList;
    foldList = dirA.entryList(QDir::Dirs | QDir::NoDotAndDotDot, QDir::Name);

    qsizetype countU;
    countU = foldList.count();
    
    Int count;
    count = countU;

    Int array;
    array = Array_New();
    Array_CountSet(array, count);
    Array_Init(array);
    
    Int i;
    i = 0;
    while (i < count)
    {
        qsizetype indexU;
        indexU = i;

        QString fold;
        fold = foldList.at(indexU);

        Int ka;
        ka = CastInt(&fold);

        Int a;
        a = StorageArrange_StringCreate(o, ka);

        Array_ItemSet(array, i, a);

        i = i + 1;
    }
    
    return array;
}

Int StorageArrange_StringCreate(Int o, Int u)
{
    QString* ka;
    ka = (QString*)u;

    QList<uint> kk;
    kk = ka->toUcs4();

    qsizetype countU;
    countU = kk.size();

    Int count;
    count = countU;

    Int dataCount;
    dataCount = count * Constant_CharByteCount();

    Int data;
    data = New(dataCount);

    Char* p;
    p = (Char*)data;

    Int i;
    i = 0;
    while (i < count)
    {
        qsizetype iU;
        iU = i;
        
        uint n;
        n = kk.at(iU);

        p[i] = n;

        i = i + 1;
    }

    Int k;
    k = String_New();
    String_Init(k);
    String_DataSet(k, data);
    String_CountSet(k, count);

    Int a;
    a = k;
    return a;
}