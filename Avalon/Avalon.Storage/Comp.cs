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
        this.StringValue = StringValue.This;

        this.ModuleFoldPath = this.InternInfra.ModuleFoldPath;
        return true;
    }

    public virtual String ModuleFoldPath { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StringValue StringValue { get; set; }

    public virtual bool Rename(String path, String destPath)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);
        string destPathK;
        destPathK = this.StringValue.ExecuteIntern(destPath);

        try
        {
            SystemStorageComp.Move(pathK, destPathK);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FileCopy(String path, String destPath)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);
        string destPathK;
        destPathK = this.StringValue.ExecuteIntern(destPath);

        try
        {
            SystemStorageComp.Copy(pathK, destPathK);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FileDelete(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        try
        {
            SystemStorageComp.Delete(pathK);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FoldCreate(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        try
        {
            SystemStorageCompFold.CreateDirectory(pathK);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FoldCopy(String path, String destPath)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);
        string destPathK;
        destPathK = this.StringValue.ExecuteIntern(destPath);

        try
        {
            SystemStorageFoldInfo source;
            source = new SystemStorageFoldInfo(pathK);

            SystemStorageFoldInfo dest;
            dest = new SystemStorageFoldInfo(destPathK);

            dest.Create();

            this.FoldCopyRecursive(source, dest);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FoldDelete(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        try
        {
            SystemStorageCompFold.Delete(pathK, true);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public virtual bool FileExist(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        bool k;
        try
        {
            k = SystemStorageComp.Exists(pathK);
        }
        catch
        {
            return false;
        }

        return k;
    }

    public virtual bool FoldExist(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        bool k;
        try
        {
            k = SystemStorageCompFold.Exists(pathK);
        }
        catch
        {
            return false;
        }

        return k;
    }

    public virtual String ThisFoldGet()
    {
        string ka;
        try
        {
            ka = SystemStorageCompFold.GetCurrentDirectory();
        }
        catch
        {
            return null;
        }

        ka = ka.Replace('\\', '/');

        String k;
        k = this.StringValue.Execute(ka);
        return k;
    }

    public virtual bool ThisFoldSet(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        try
        {
            SystemStorageCompFold.SetCurrentDirectory(pathK);
        }
        catch
        {
            return false;
        }

        return true;
    }

    private void FoldCopyRecursive(SystemStorageFoldInfo source, SystemStorageFoldInfo target)
    {
        foreach (SystemStorageFoldInfo dir in source.GetDirectories())
        {
            this.FoldCopyRecursive(dir, target.CreateSubdirectory(dir.Name));
        }
        foreach (SystemStorageFileInfo file in source.GetFiles())
        {
            file.CopyTo(SystemStoragePath.Combine(target.FullName, file.Name));
        }
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