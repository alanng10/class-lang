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
        this.Intern = Extern.StorageArrange_New();
        Extern.StorageArrange_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.StorageArrange_Final(this.Intern);
        Extern.StorageArrange_Delete(this.Intern);
        return true;
    }

    public virtual string ModuleFoldPath
    {
        get
        {
            return this.InternIntern.ModuleFoldPath;
        }
        set
        {
        }
    }
    public virtual string ExecuteFoldPath
    {
        get
        {
            return this.InternIntern.ExecuteFoldPath;
        }
        set
        {
        }
    }
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
        o = Extern.StorageArrange_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Value);

        ulong o;
        o = Extern.StorageArrange_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileRemove(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageArrange_FileRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldCreate(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageArrange_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Value);

        ulong o;
        o = Extern.StorageArrange_FoldCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldRemove(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageArrange_FoldRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool Exist(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageArrange_Exist(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual Array FoldList(String path)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        ulong pathU;
        pathU = internInfra.StringCreate(path.Value);

        ulong o;
        o = Extern.StorageArrange_FoldList(this.Intern, pathU);

        internInfra.StringDelete(pathU);

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

            byte[] k;
            k = internInfra.ByteArrayCreateString(u);

            long dataCount;
            dataCount = k.LongLength;

            long countA;
            countA = dataCount / sizeof(uint);

            String a;
            a = new String();
            a.Value = k;
            a.Count = countA;
            a.Init();

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

            ulong dataA;
            dataA = Extern.String_DataGet(ua);

            Extern.String_Final(ua);
            Extern.String_Delete(ua);

            Extern.Delete(dataA);

            i = i + 1;
        }

        Extern.Array_Final(o);
        Extern.Array_Delete(o);

        return array;
    }
}