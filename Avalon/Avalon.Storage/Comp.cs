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

    public virtual bool Exist(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_Exist(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Fold(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong k;
        k = Extern.StorageComp_Fold(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = !(k == 0);
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

    public virtual Array EntryList(String path, bool fold)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong foldU;
        foldU = 0;
        if (fold)
        {
            foldU = 1;
        }

        ulong k;
        k = Extern.StorageComp_EntryList(this.Intern, pathU, foldU);

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

            String a;
            a = this.InternInfra.StringCreateIntern(u);

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

            this.InternInfra.StringDelete(ua);

            i = i + 1;
        }

        Extern.Array_Final(k);
        Extern.Array_Delete(k);

        return array;
    }
}