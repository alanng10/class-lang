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
            SystemStorageCompFold.Move(pathK, destPathK);
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
            SystemStorageComp.Copy(pathK, destPathK, true);
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

    public virtual bool Exist(String path)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        bool k;
        try
        {
            bool ba;
            bool bb;
            ba = SystemStorageComp.Exists(pathK);
            bb = SystemStorageCompFold.Exists(pathK);
        
            k = ba | bb;
        }
        catch
        {
            return false;
        }

        return k;
    }

    public virtual bool Fold(String path)
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

    private bool FoldCopyRecursive(SystemStorageFoldInfo source, SystemStorageFoldInfo target)
    {
        SystemStorageFoldInfo[] foldArray;
        foldArray = source.GetDirectories();

        long count;
        count = foldArray.LongLength;

        long i;
        i = 0;
        while (i < count)
        {
            SystemStorageFoldInfo fold;
            fold = foldArray[i];

            this.FoldCopyRecursive(fold, target.CreateSubdirectory(fold.Name));

            i = i + 1;
        }

        SystemStorageFileInfo[] fileArray;
        fileArray = source.GetFiles();

        count = fileArray.LongLength;

        i = 0;
        while (i < count)
        {
            SystemStorageFileInfo file;
            file = fileArray[i];

            file.CopyTo(target.FullName + "/" + file.Name);

            i = i + 1;
        }

        return true;
    }

    public virtual Array EntryList(String path, bool fold)
    {
        string pathK;
        pathK = this.StringValue.ExecuteIntern(path);

        string[] k;
        k = null;
        try
        {
            if (fold)
            {
                k = SystemStorageCompFold.GetDirectories(pathK);
            }
            if (!fold)
            {
                k = SystemStorageCompFold.GetFiles(pathK);
            }
        }
        catch
        {
            return null;
        }

        long count;
        count = k.LongLength;

        long i;
        i = 0;
        while (i < count)
        {
            string ka;
            ka = k[i];

            ka = SystemStoragePath.GetFileName(ka);

            k[i] = ka;
            
            i = i + 1;
        }

        SystemArray.Sort(k);

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        i = 0;
        while (i < count)
        {
            string kb;
            kb = k[i];

            String kk;
            kk = this.StringValue.Execute(kb);

            array.SetAt(i, kk);

            i = i + 1;
        }

        return array;
    }
}