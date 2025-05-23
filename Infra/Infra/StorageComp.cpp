#include "StorageComp.hpp"

CppClassNew(StorageComp)

Int StorageComp_Init(Int o)
{
    return true;
}

Int StorageComp_Final(Int o)
{
    return true;
}

Int StorageComp_Rename(Int o, Int path, Int destPath)
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

Int StorageComp_FileCopy(Int o, Int path, Int destPath)
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

Int StorageComp_FileDelete(Int o, Int path)
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


Int StorageComp_FoldCreate(Int o, Int path)
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

Int StorageComp_FoldCopy(Int o, Int path, Int destPath)
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
    a = StorageComp_FoldCopyRecurse(o, ua, ub);
    return a;
}

Int StorageComp_FoldCopyRecurse(Int o, Int path, Int destPath)
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
        ba = StorageComp_FoldCopyRecurse(o, uua, uub);
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

Int StorageComp_FoldDelete(Int o, Int path)
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

Int StorageComp_Exist(Int o, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    bool bu;
    bu = QFileInfo::exists(pathU);

    Bool a;
    a = bu;
    return a;
}

Int StorageComp_Fold(Int o, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QFileInfo k;
    k = QFileInfo(pathU);

    bool bu;
    bu = k.isDir();

    Bool a;
    a = bu;
    return a;
}

Int StorageComp_EntryList(Int o, Int path, Int fold)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QDir dirA(pathU);

    Int kaa;
    kaa = 0;

    if (fold)
    {
        kaa = QDir::Dirs | QDir::NoDotAndDotDot;
    }

    if (!fold)
    {
        kaa = QDir::Files;
    }

    QDir::Filter filterU;
    filterU = (QDir::Filter)kaa;

    QDir::Filters kk;
    kk = QDir::Filters(filterU);

    QStringList entryList;
    entryList = dirA.entryList(kk, QDir::Name);

    qsizetype countU;
    countU = entryList.count();
    
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

        QString entry;
        entry = entryList.at(indexU);

        Int ka;
        ka = CastInt(&entry);

        Int a;
        a = StorageComp_StringCreate(o, ka);

        Array_ItemSet(array, i, a);

        i = i + 1;
    }
    
    return array;
}

Int StorageComp_ThisFoldGet(Int o)
{
    QString k;
    k = QDir::currentPath();

    QChar before;
    QChar after;
    before = '\\';
    after = '/';

    k.replace(before, after);

    Int ka;
    ka = CastInt(&k);

    Int a;
    a = StorageComp_StringCreate(o, ka);

    return a;
}

Int StorageComp_ThisFoldSet(Int o, Int path)
{
    QString pathU;
    Int ka;
    ka = CastInt(&pathU);
    String_QStringSet(ka, path);

    bool k;
    k = QDir::setCurrent(pathU);

    Bool a;
    a = k;
    return a;
}

Int StorageComp_StringCreate(Int o, Int u)
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

    Int value;
    value = Environ_New(dataCount);

    Char* p;
    p = (Char*)value;

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
    String_ValueSet(k, value);
    String_CountSet(k, count);

    Int a;
    a = k;
    return a;
}