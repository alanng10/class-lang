namespace Saber.Console;

public class BinaryGena : Any
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
    public virtual ListInfra ListInfra { get; set; }
    public virtual ClassInfra ClassInfra { get; set; }
    public virtual Table IndexTable { get; set; }

    public virtual bool Execute()
    {
        this.IndexTableSet();
        
        BinaryBinary a;
        a = this.ExecuteBinary();

        this.Result = a;

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
            ka = iter.Value as ClassClass;

            this.IndexTableAdd(ka);
        }

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            Table kk;
            kk = iter.Value as Table;

            Iter iterA;
            iterA = new TableIter();
            iterA.Init();

            kk.IterSet(iterA);

            while (iterA.Next())
            {
                ClassClass kb;
                kb = iterA.Value as ClassClass;

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

    public virtual BinaryBinary ExecuteBinary()
    {
        BinaryBinary a;
        a = new BinaryBinary();
        a.Init();

        a.Ref = this.ExecuteModuleRef(this.Module.Ref);
        a.Class = this.ExecuteClassArray();
        a.Import = this.ExecuteImportArray();
        a.Export = this.ExecuteExportArray();
        a.Base = this.ExecuteBaseArray();
        a.Part = this.ExecutePartArray();
        a.Entry = this.ExecuteEntry();
        return a;
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
            varClass = iter.Value as ClassClass;

            BinaryClass a;
            a = this.ExecuteClass(varClass);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryClass ExecuteClass(ClassClass ka)
    {
        String name;
        name = ka.Name;

        BinaryClass a;
        a = new BinaryClass();
        a.Init();
        a.Name = name;
        return a;
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
            ka = iter.Index as ModuleRef;

            Table kb;
            kb = iter.Value as Table;

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
            kd = iter.Value as ClassClass;

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

            ClassClass baseClass;
            baseClass = ka.Base;

            long n;
            n = this.ClassIndex(baseClass);

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = n;

            array.SetAt(i, value);

            i = i + 1;
        }

        return array;
    }

    public virtual Array ExecutePartArray()
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

            BinaryPart a;
            a = this.ExecutePart(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryPart ExecutePart(ClassClass varClass)
    {
        long fieldStart;
        long maideStart;
        fieldStart = varClass.FieldStart;
        maideStart = varClass.MaideStart;

        Array field;
        field = this.ExecuteFieldArray(varClass.Field);

        Array maide;
        maide = this.ExecuteMaideArray(varClass.Maide);

        BinaryPart a;
        a = new BinaryPart();
        a.Init();
        a.FieldStart = fieldStart;
        a.MaideStart = maideStart;
        a.Field = field;
        a.Maide = maide;
        return a;
    }

    public virtual Array ExecuteFieldArray(Table table)
    {
        long count;
        count = table.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            Field ka;
            ka = (Field)iter.Value;

            BinaryField a;
            a = this.ExecuteField(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryField ExecuteField(Field ka)
    {
        long varClass;
        varClass = this.ClassIndex(ka.Class);

        long count;
        count = ka.Count.Index;

        String name;
        name = ka.Name;

        BinaryField a;
        a = new BinaryField();
        a.Init();
        a.Class = varClass;
        a.Count = count;
        a.Name = name;
        return a;
    }

    public virtual Array ExecuteMaideArray(Table table)
    {
        long count;
        count = table.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            Maide ka;
            ka = (Maide)iter.Value;

            BinaryMaide a;
            a = this.ExecuteMaide(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryMaide ExecuteMaide(Maide ka)
    {
        long varClass;
        varClass = this.ClassIndex(ka.Class);

        long count;
        count = ka.Count.Index;

        String name;
        name = ka.Name;

        Array param;
        param = this.ExecuteVarArray(ka.Param);

        BinaryMaide a;
        a = new BinaryMaide();
        a.Init();
        a.Class = varClass;
        a.Count = count;
        a.Name = name;
        a.Param = param;
        return a;
    }

    public virtual Array ExecuteVarArray(Table table)
    {
        long count;
        count = table.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            Var ka;
            ka = (Var)iter.Value;

            BinaryVar a;
            a = this.ExecuteVar(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual BinaryVar ExecuteVar(Var ka)
    {
        long varClass;
        varClass = this.ClassIndex(ka.Class);

        String name;
        name = ka.Name;

        BinaryVar a;
        a = new BinaryVar();
        a.Init();
        a.Class = varClass;
        a.Name = name;
        return a;
    }

    public virtual BinaryEntry ExecuteEntry()
    {
        long k;
        k = -1;

        String entry;
        entry = this.Module.Entry;

        if (!(entry == null))
        {
            ClassClass varClass;
            varClass = this.Module.Class.Get(entry) as ClassClass;

            k = varClass.Index;
        }

        BinaryEntry a;
        a = new BinaryEntry();
        a.Init();
        a.Class = k;
        return a;
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