namespace Saber.Console;

public class BinaryGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.BinaryState = this.CreateBinaryState();
        return true;
    }

    protected virtual BinaryState CreateBinaryState()
    {
        BinaryState a;
        a = new BinaryState();
        a.Init();
        return a;
    }

    public virtual ClassModule Module { get; set; }
    public virtual BinaryBinary Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual BinaryState BinaryState { get; set; }
    protected virtual Table IndexTable { get; set; }

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

        Iter iterA;
        iterA = new TableIter();
        iterA.Init();

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
        long k;
        k = this.IndexTable.Count;

        InfraValue value;
        value = new InfraValue();
        value.Init();
        value.Int = k;

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
        a.State = this.ExecuteState();
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

    public virtual BinaryClass ExecuteClass(ClassClass varClass)
    {
        String name;
        name = varClass.Name;

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

    public virtual BinaryImport ExecuteImport(ModuleRef moduleRef, Table table)
    {
        ModuleRef moduleRefA;
        moduleRefA = this.ExecuteModuleRef(moduleRef);

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

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            long ka;
            ka = varClass.Index;

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = ka;

            array.SetAt(i, value);

            i = i + 1;
        }

        BinaryImport a;
        a = new BinaryImport();
        a.Init();
        a.Module = moduleRefA;
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

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            long ka;
            ka = varClass.Index;

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = ka;

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

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            ClassClass baseClass;
            baseClass = varClass.Base;

            long ka;
            ka = this.ClassIndex(baseClass);

            InfraValue value;
            value = new InfraValue();
            value.Init();
            value.Int = ka;

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

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            BinaryPart a;
            a = this.ExecutePart(varClass);

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

            Field varField;
            varField = iter.Value as Field;

            BinaryField a;
            a = this.ExecuteField(varField);

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
            ka = iter.Value as Maide;

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
            ka = iter.Value as Var;

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

    public virtual Data ExecuteState()
    {
        this.BinaryState.Module = this.Module;
        this.BinaryState.IndexTable = this.IndexTable;

        this.BinaryState.Execute();

        Data k;
        k = this.BinaryState.Result;

        this.BinaryState.Result = null;

        this.BinaryState.IndexTable = null;
        this.BinaryState.Module = null;

        Data a;
        a = k;
        return a;
    }

    public virtual ModuleRef ExecuteModuleRef(ModuleRef moduleRef)
    {
        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(moduleRef.Name, moduleRef.Ver);
        return a;
    }

    public virtual long ClassIndex(ClassClass varClass)
    {
        InfraValue k;
        k = this.IndexTable.Get(varClass) as InfraValue;

        long n;
        n = k.Int;

        return n;
    }
}