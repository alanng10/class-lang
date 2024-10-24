namespace Saber.Console;

public class BinaryGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual BinaryBinary Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public virtual bool Execute()
    {
        BinaryBinary binary;
        binary = new BinaryBinary();
        binary.Init();

        binary.Ref = this.ExecuteModuleRef(this.Module.Ref);
        binary.Class = this.ExecuteClassArray();
        binary.Import = this.ExecuteImportArray();

        this.Result = binary;
        return true;
    }

    public virtual Array ExecuteClassArray()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            BinaryClass a;
            a = new BinaryClass();
            a.Init();
            a.Name = varClass.Name;

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual Array ExecuteImportArray()
    {
        long count;
        count = this.Module.Import.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.Module.Import.IterCreate();
        this.Module.Import.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ModuleRef ka;
            ka = (ModuleRef)iter.Index;

            Table kb;
            kb = (Table)iter.Value;

            BinaryImport a;
            a = this.ExecuteImport(ka, kb);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryImport ExecuteImport(ModuleRef ka, Table kb)
    {

        return null;
    }

    public virtual ModuleRef ExecuteModuleRef(ModuleRef ks)
    {
        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(ks.Name, ks.Ver);
        return a;
    }
}