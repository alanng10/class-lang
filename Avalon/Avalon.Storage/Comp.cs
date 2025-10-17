namespace Avalon.Storage;

public class Comp : Any
{
    public static Comp This { get; } = ShareCreate();

    private static Comp ShareCreate()
    {
        Comp share;
        share = new Comp();
        Any a;
        a = share;
        a.Init();
        return share;
    }
    
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        this.ListInfra = ListInfra.This;

        this.ModuleFoldPath = this.InternInfra.ModuleFoldPath;

        this.Intern = Extern.StorageComp_New();
        Extern.StorageComp_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.StorageComp_Final(this.Intern);
        Extern.StorageComp_Delete(this.Intern);
        return true;
    }

    public virtual String ModuleFoldPath { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Rename(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath);

        ulong k;
        k = Extern.StorageComp_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool FileCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath);

        ulong k;
        k = Extern.StorageComp_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool FileDelete(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_FileDelete(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool FoldCreate(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool FoldCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath);

        ulong k;
        k = Extern.StorageComp_FoldCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool FoldDelete(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_FoldDelete(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual Entry Entry(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageEntry_New();
        Extern.StorageEntry_Init(k);

        Extern.StorageComp_Entry(this.Intern, k, pathU);

        Entry a;
        a = this.EntryFromIntern(k);

        Extern.StorageEntry_Final(k);
        Extern.StorageEntry_Delete(k);

        this.InternInfra.StringDelete(pathU);

        return a;
    }

    public virtual String ThisFoldGet()
    {
        ulong k;
        k = Extern.StorageComp_ThisFoldGet(this.Intern);

        String a;
        a = this.InternInfra.StringCreateIntern(k);

        this.InternInfra.StringDelete(k);

        return a;
    }

    public virtual bool ThisFoldSet(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_ThisFoldSet(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual Array EntryList(String path, bool fold, bool file)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong foldU;
        foldU = this.InternInfra.Bool(fold);

        ulong fileU;
        fileU = this.InternInfra.Bool(file);

        ulong k;
        k = Extern.StorageComp_EntryList(this.Intern, pathU, foldU, fileU);

        this.InternInfra.StringDelete(pathU);

        ulong countU;
        countU = Extern.Array_CountGet(k);

        long count;
        count = (long)countU;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        long i;
        i = 0;
        while (i < count)
        {
            ulong indexU;
            indexU = (ulong)i;

            ulong u;
            u = Extern.Array_ItemGet(k, indexU);

            Entry a;
            a = this.EntryFromIntern(u);

            array.SetAt(i, a);

            i = i + 1;
        }

        i = 0;
        while (i < count)
        {
            long indexA;
            indexA = count - 1 - i;

            ulong indexAU;
            indexAU = (ulong)indexA;

            ulong ua;
            ua = Extern.Array_ItemGet(k, indexAU);

            Extern.StorageEntry_Final(ua);
            Extern.StorageEntry_Delete(ua);

            i = i + 1;
        }

        Extern.Array_Final(k);
        Extern.Array_Delete(k);

        return array;
    }

    private Entry EntryFromIntern(ulong k)
    {
        ulong nameK;
        ulong existK;
        ulong foldK;
        ulong sizeK;
        ulong createTimeK;
        ulong modifyTimeK;
        ulong ownerK;
        ulong groupK;
        ulong permitK;
        nameK = Extern.StorageEntry_NameGet(k);
        existK = Extern.StorageEntry_ExistGet(k);
        foldK = Extern.StorageEntry_FoldGet(k);
        sizeK = Extern.StorageEntry_SizeGet(k);
        createTimeK = Extern.StorageEntry_CreateTimeGet(k);
        modifyTimeK = Extern.StorageEntry_ModifyTimeGet(k);
        ownerK = Extern.StorageEntry_OwnerGet(k);
        groupK = Extern.StorageEntry_GroupGet(k);
        permitK = Extern.StorageEntry_PermitGet(k);

        String name;
        name = null;
        bool exist;
        exist = false;
        bool fold;
        fold = false;
        long size;
        size = -1;
        long createTime;
        createTime = -1;
        long modifyTime;
        modifyTime = -1;
        long owner;
        owner = -1;
        long group;
        group = -1;
        Permit permit;
        permit = null;

        name = this.InternInfra.StringCreateIntern(nameK);

        exist = !(existK == 0);

        if (exist)
        {
            fold = !(foldK == 0);

            if (!fold)
            {
                size = (long)sizeK;
            }

            createTime = (long)createTimeK;

            if (!fold)
            {
                modifyTime = (long)modifyTimeK;
            }

            owner = (long)ownerK;

            group = (long)groupK;

            permit = this.Permit((long)permitK);
        }

        Entry a;
        a = new Entry();
        a.Init();
        a.Name = name;
        a.Exist = exist;
        a.Fold = fold;
        a.Size = size;
        a.CreateTime = createTime;
        a.ModifyTime = modifyTime;
        a.Owner = owner;
        a.Group = group;
        a.Permit = permit;

        this.InternInfra.StringDelete(nameK);

        return a;
    }

    private Permit Permit(long value)
    {
        Permit a;
        a = new Permit();
        a.Init();

        a.OwnerRead = this.HasFlag(value, 0);
        a.OwnerWrite = this.HasFlag(value, 1);
        a.GroupRead = this.HasFlag(value, 2);
        a.GroupWrite = this.HasFlag(value, 3);
        a.OtherRead = this.HasFlag(value, 4);
        a.OtherWrite = this.HasFlag(value, 5);
        a.Other = -1;
        return a;
    }

    private bool HasFlag(long value, long index)
    {
        int shift;
        shift = (int)index;

        long ka;
        ka = 1;
        ka = ka << shift;

        bool a;
        a = !((value & ka) == 0);
        return a;
    }
}