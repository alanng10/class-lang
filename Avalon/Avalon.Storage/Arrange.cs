namespace Avalon.Storage;

public class Arrange : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
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
    private ulong Intern { get; set; }

    public virtual bool Rename(string path, string destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath);

        ulong o;
        o = Extern.StorageArrange_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileCopy(string path, string destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath);

        ulong o;
        o = Extern.StorageArrange_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileRemove(string path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong o;
        o = Extern.StorageArrange_FileRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldCreate(string path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong o;
        o = Extern.StorageArrange_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldRemove(string path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong o;
        o = Extern.StorageArrange_FoldRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool Exist(string path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path);

        ulong o;
        o = Extern.StorageArrange_Exist(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }
}