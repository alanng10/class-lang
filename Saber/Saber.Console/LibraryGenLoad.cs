namespace Saber.Console;

public class LibraryGenLoad : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.SModule = this.S("Module");
        return true;
    }

    public virtual Table BinaryTable { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual String ClassPath { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual String SModule { get; set; }

    protected virtual bool BinaryLoadRecurse(ModuleRef moduleRef)
    {
        if (this.BinaryTable.Valid(moduleRef))
        {
            return true;
        }

        BinaryBinary binary;
        binary = this.BinaryLoad(moduleRef);
        if (binary == null)
        {
            return false;
        }

        Array array;
        array = binary.Import;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = array.GetAt(i) as BinaryImport;

            bool b;
            b = this.BinaryLoadRecurse(import.Module);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);

        return true;
    }

    protected virtual BinaryBinary BinaryLoad(ModuleRef moduleRef)
    {
        String moduleRefString;
        moduleRefString = this.ModuleRefString(moduleRef);

        String filePath;
        filePath = this.AddClear().Add(this.ClassInfra.ClassModulePath(this.ClassPath))
            .Add(this.TextInfra.PathCombine).Add(moduleRefString)
            .Add(this.TextInfra.PathCombine).Add(this.SModule).AddResult();

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            return null;
        }

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;

        read.Execute();

        BinaryBinary binary;
        binary = read.Result;

        read.Result = null;

        BinaryBinary a;
        a = binary;

        return a;
    }

    protected virtual String ModuleRefString(ModuleRef k)
    {
        String verString;
        verString = this.ClassInfra.VerString(k.Ver);

        String a;
        a = this.ClassInfra.ModuleRefString(k.Name, verString);
        return a;
    }
}