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
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.ListInfra = ListInfra.This;

        this.ModuleFoldPath = (String)this.InternIntern.ModuleFoldPath;

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
    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Rename(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Value);

        ulong o;
        o = Extern.StorageComp_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool FileCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Value);

        ulong o;
        o = Extern.StorageComp_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool FileDelete(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageComp_FileRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool FoldCreate(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageComp_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool FoldCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Value);

        ulong o;
        o = Extern.StorageComp_FoldCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool FoldDelete(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageComp_FoldRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual bool Exist(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageComp_Exist(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    public virtual Array FileList(String path)
    {
        return this.EntryList(path, false);
    }

    public virtual Array FoldList(String path)
    {
        return this.EntryList(path, true);
    }

    public virtual String WorkFoldGet()
    {
        ulong o;
        o = Extern.StorageComp_CurrentFoldGet(this.Intern);

        String a;
        a = this.StringCreateIntern(o);

        this.InternInfra.StringDelete(o);

        return a;
    }

    public virtual bool WorkFoldSet(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageComp_CurrentFoldSet(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(o == 0);
        return a;
    }

    protected virtual Array EntryList(String path, bool fold)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = 0;
        if (!fold)
        {
            o = Extern.StorageComp_FileList(this.Intern, pathU);
        }
        if (fold)
        {
            o = Extern.StorageComp_FoldList(this.Intern, pathU);
        }

        this.InternInfra.StringDelete(pathU);

        ulong countU;
        countU = Extern.Array_CountGet(o);

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
            u = Extern.Array_ItemGet(o, indexU);

            String a;
            a = this.StringCreateIntern(u);

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
            ua = Extern.Array_ItemGet(o, indexAU);

            this.InternInfra.StringDelete(ua);

            i = i + 1;
        }

        Extern.Array_Final(o);
        Extern.Array_Delete(o);

        return array;
    }

    private String StringCreateIntern(ulong o)
    {
        byte[] k;
        k = this.InternInfra.ByteArrayCreateString(o);

        long dataCount;
        dataCount = k.LongLength;

        long count;
        count = dataCount / sizeof(uint);

        String a;
        a = new String();
        a.Value = k;
        a.Count = count;
        a.Init();
        return a;
    }
}