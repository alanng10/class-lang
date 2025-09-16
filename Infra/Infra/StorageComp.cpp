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

Int StorageComp_Entry(Int o, Int result, Int path)
{
    QString pathU;
    Int ua;
    ua = CastInt(&pathU);
    String_QStringSet(ua, path);

    QFileInfo k;
    k = QFileInfo(pathU);

    bool bExist;
    bExist = k.exists();
    Bool exist;
    exist = bExist;

    Bool fold;
    fold = false;
    Int size;
    size = 0;
    Int createTime;
    createTime = -1;
    Int modifyTime;
    modifyTime = -1;
    Int owner;
    owner = 0;
    Int group;
    group = 0;
    Int permit;
    permit = 0;

    if (exist)
    {
        bool bFold;
        bFold = k.isDir();

        fold = bFold;

        if (!fold)
        {
            qint64 ka;
            ka = k.size();

            size = ka;

            Int kaa;
            kaa = 1;
            kaa = kaa << 60;
            kaa = kaa - 1;

            size = size & kaa;
        }

        QDateTime kb;
        kb = k.birthTime();

        if (kb.isValid())
        {
            Int kba;
            kba = CastInt(&kb);

            Int kbTime;
            kbTime = Time_New();
            Time_Init(kbTime);

            Bool kbd;
            kbd = Time_SetValidTick(kbTime, kba);

            if (kbd)
            {
                createTime = Time_TotalTickGet(kbTime);
            }

            Time_Final(kbTime);
            Time_Delete(kbTime);
        }

        if (!fold)
        {
            QDateTime kc;
            kc = k.lastModified();

            Int kca;
            kca = CastInt(&kc);

            Int kcTime;
            kcTime = Time_New();
            Time_Init(kcTime);

            Bool kcd;
            kcd = Time_SetValidTick(kcTime, kca);

            if (kcd)
            {
                modifyTime = Time_TotalTickGet(kcTime);
            }

            Time_Final(kcTime);
            Time_Delete(kcTime);
        }

        owner = k.ownerId();

        group = k.groupId();

        QFileDevice::Permissions kd;
        kd = k.permissions();

        int kda;
        kda = kd.toInt();

        Int kdb;
        kdb = kda;

        Bool ownerRead;
        Bool ownerWrite;
        Bool groupRead;
        Bool groupWrite;
        Bool otherRead;
        Bool otherWrite;
        ownerRead = Environ_HasFlag(kdb, QFileDevice::ReadOwner);
        ownerWrite = Environ_HasFlag(kdb, QFileDevice::WriteOwner);
        groupRead = Environ_HasFlag(kdb, QFileDevice::ReadGroup);
        groupWrite = Environ_HasFlag(kdb, QFileDevice::WriteGroup);
        otherRead = Environ_HasFlag(kdb, QFileDevice::ReadOther);
        otherWrite = Environ_HasFlag(kdb, QFileDevice::WriteOther);

        permit = StorageComp_FlagSet(permit, 0, ownerRead);
        permit = StorageComp_FlagSet(permit, 1, ownerWrite);
        permit = StorageComp_FlagSet(permit, 2, groupRead);
        permit = StorageComp_FlagSet(permit, 3, groupWrite);
        permit = StorageComp_FlagSet(permit, 4, otherRead);
        permit = StorageComp_FlagSet(permit, 5, otherWrite);
    }

    Int name;
    name = StorageComp_EntryName(path);

    StorageEntry_NameSet(result, name);
    StorageEntry_ExistSet(result, exist);
    StorageEntry_FoldSet(result, fold);
    StorageEntry_SizeSet(result, size);
    StorageEntry_CreateTimeSet(result, createTime);
    StorageEntry_ModifyTimeSet(result, modifyTime);
    StorageEntry_OwnerSet(result, owner);
    StorageEntry_GroupSet(result, group);
    StorageEntry_PermitSet(result, permit);

    return true;
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

Int StorageComp_FlagSet(Int value, Int shift, Int bit)
{
    Int k;
    k = bit;
    k = k << shift;

    value = value | k;

    return value;
}

Int StorageComp_EntryName(Int path)
{
    Int count;
    count = String_CountGet(path);

    Int k;
    k = -1;

    Bool b;
    b = false;

    Int i;
    i = 0;
    while ((!b) & (i < count))
    {
        Int index;
        index = (count - 1) - i;

        Int ka;
        ka = String_Char(path, index);

        if (ka == '/' | ka == '\\')
        {
            k = index;
            b = true;
        }

        i = i + 1;
    }

    Int resultIndex;
    Int resultCount;
    resultIndex = 0;
    resultCount = 0;

    if (!b)
    {
        resultIndex = 0;
        resultCount = count;
    }

    if (b)
    {
        resultIndex = k + 1;
        resultCount = count - resultIndex;
    }

    Int dataCount;
    dataCount = resultCount * Constant_CharByteCount();

    Int data;
    data = Environ_New(dataCount);

    Int pathValue;
    pathValue = String_ValueGet(path);

    Int source;
    source = pathValue + resultIndex * Constant_CharByteCount();

    Environ_Copy(data, source, dataCount);

    Int result;
    result = String_New();
    String_Init(result);
    String_ValueSet(result, data);
    String_CountSet(result, resultCount);

    return result;
}