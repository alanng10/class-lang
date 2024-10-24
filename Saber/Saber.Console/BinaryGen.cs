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
    public virtual Table IndexTable { get; set; }

    public virtual bool Execute()
    {
        this.IndexTableSet();
        
        BinaryBinary binary;
        binary = new BinaryBinary();
        binary.Init();

        binary.Ref = this.ExecuteModuleRef(this.Module.Ref);
        binary.Class = this.ExecuteClassArray();
        binary.Import = this.ExecuteImportArray();
        binary.Export = this.ExecuteExportArray();
        binary.Base = this.ExecuteBaseArray();

        this.Result = binary;

        this.IndexTable = null;
        return true;
    }

    public virtual bool IndexTableSet()
    {
        this.IndexTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = new TableIter();
        iter.Init();
        
        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass ka;
            ka = (ClassClass)iter.Value;

            this.IndexTableAdd(ka);
        }

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            Table kk;
            kk = (Table)iter.Value;

            Iter iterA;
            iterA = new TableIter();
            iterA.Init();

            kk.IterSet(iterA);

            while (iterA.Next())
            {
                ClassClass kb;
                kb = (ClassClass)iterA.Value;

                this.IndexTableAdd(kb);
            }
        }

        return true;
    }

    public virtual bool IndexTableAdd(ClassClass ka)
    {
        long n;
        n = this.IndexTable.Count;

        InfraValue value;
        value = new InfraValue();
        value.Init();
        value.Int = n;

        this.ListInfra.TableAdd(this.IndexTable, ka, value);
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
        ModuleRef moduleRef;
        moduleRef = this.ExecuteModuleRef(ka);

        long count;
        count = kb.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = kb.IterCreate();
        kb.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass kd;
            kd = (ClassClass)iter.Value;

            long n;
            n = kd.Index;

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = n;

            array.SetAt(i, value);

            i = i + 1;
        }

        BinaryImport a;
        a = new BinaryImport();
        a.Init();
        a.Module = moduleRef;
        a.Class = array;
        return a;
    }

    public virtual Array ExecuteExportArray()
    {
        long count;
        count = this.Module.Export.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.Module.Export.IterCreate();
        this.Module.Export.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass ka;
            ka = (ClassClass)iter.Value;

            long n;
            n = ka.Index;

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = n;

            array.SetAt(i, value);

            i = i + 1;
        }

        return array;
    }

    public virtual Array ExecuteBaseArray()
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

            ClassClass ka;
            ka = (ClassClass)iter.Value;

            long n;
            n = this.ClassIndex(ka);

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = n;

            array.SetAt(i, value);

            i = i + 1;
        }

        return array;
    }

    public virtual ModuleRef ExecuteModuleRef(ModuleRef ks)
    {
        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(ks.Name, ks.Ver);
        return a;
    }

    public virtual long ClassIndex(ClassClass varClass)
    {
        InfraValue k;
        k = (InfraValue)this.IndexTable.Get(varClass);

        long n;
        n = k.Int;

        return n;
    }
}