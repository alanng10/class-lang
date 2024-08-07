namespace Z.Tool.ReferBinaryGen;

class BinaryGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Module Module { get; set; }
    protected virtual Table ClassIndexTable { get; set; }

    public virtual bool Execute()
    {
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefCompare();

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);
        while (iter.Next())
        {
            Module module;
            module = (Module)iter.Value;
            Binary binary;
            binary = this.ExecuteModule(module);
            this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);
        }
        return true;
    }

    protected virtual Binary ExecuteModule(Module module)
    {
        this.Module = module;

        this.ClassIndexTable = this.ClassInfra.TableCreateRefCompare();

        ModuleRef oa;
        oa = this.ClassInfra.ModuleRefCreate(module.Ref.Name, module.Ref.Version);

        Binary binary;
        binary = new Binary();
        binary.Init();
        binary.Ref = oa;

        binary.Class = this.ExecuteClassArray();
        binary.Import = this.ExecuteImportArray();
        binary.Base = this.ExecuteBaseArray();
        binary.Part = this.ExecutePartArray();
        binary.Entry = this.ExecuteEntry();

        this.Module = null;
        this.ClassIndexTable = null;

        return binary;
    }

    protected virtual Array ExecuteClassArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            BinaryClass a;
            a = new BinaryClass();
            a.Init();
            a.Name = oa.Name;
            
            array.SetAt(i, a);

            this.ClassIndexAdd(oa);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecuteImportArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Module.Import.Count);

        Iter iter;
        iter = this.Module.Import.IterCreate();
        this.Module.Import.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            Table table;
            table = (Table)iter.Value;

            ModuleRef oa;
            oa = this.ClassInfra.ModuleRefCreate(moduleRef.Name, moduleRef.Version);

            BinaryImport a;
            a = new BinaryImport();
            a.Init();
            a.Module = oa;

            Array aa;
            aa = this.ExecuteImportClassArray(table);

            a.Class = aa;

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecuteImportClassArray(Table classTable)
    {
        Array array;
        array = this.ListInfra.ArrayCreate(classTable.Count);

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;
    
            Value a;
            a = new Value();
            a.Init();
            a.Mid = oa.Index;
            array.SetAt(i, a);
            this.ClassIndexAdd(oa);
            i = i + 1;
        }
        return array;
    }

    protected virtual Array ExecuteBaseArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            ClassClass ob;
            ob = oa.Base;

            int aa;
            aa = this.ClassIndexGet(ob);

            Value a;
            a = new Value();
            a.Init();
            a.Mid = aa;

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecutePartArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            BinaryPart a;
            a = new BinaryPart();
            a.Init();
            a.Field = this.ExecuteFieldArray(oa);
            a.Maide = this.ExecuteMaideArray(oa);

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecuteFieldArray(ClassClass varClass)
    {
        Array array;
        array = this.ListInfra.ArrayCreate(varClass.Field.Count);

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            Field oa;
            oa = (Field)iter.Value;

            int of;
            of = -1;
            if (!(oa.Virtual == null))
            {
                of = this.ClassIndexGet(oa.Virtual.Parent);
            }

            BinaryField a;
            a = new BinaryField();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemInfo = oa.SystemInfo.Value;
            a.Count = oa.Count.Index;
            a.Virtual = of;
            a.Name = oa.Name;

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecuteMaideArray(ClassClass varClass)
    {
        Array array;
        array = this.ListInfra.ArrayCreate(varClass.Maide.Count);

        Iter iter;
        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            Maide oa;
            oa = (Maide)iter.Value;

            int of;
            of = -1;
            if (!(oa.Virtual == null))
            {
                of = this.ClassIndexGet(oa.Virtual.Parent);
            }

            BinaryMaide a;
            a = new BinaryMaide();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemInfo = oa.SystemInfo.Value;
            a.Count = oa.Count.Index;
            a.Virtual = of;
            a.Name = oa.Name;

            Array varArray;
            varArray = this.ExecuteVarArray(oa.Param);
            a.Param = varArray;

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Array ExecuteVarArray(Table varTable)
    {
        Array array;
        array = this.ListInfra.ArrayCreate(varTable.Count);

        Iter iter;
        iter = varTable.IterCreate();
        varTable.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            Var oa;
            oa = (Var)iter.Value;

            BinaryVar a;
            a = new BinaryVar();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemInfo = oa.SystemInfo.Value;
            a.Name = oa.Name;

            array.SetAt(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual int ExecuteEntry()
    {
        int a;
        a = -1;
        
        string entry;
        entry = this.Module.Entry;
        if (!(entry == null))
        {
            ClassClass entryClass;
            entryClass = (ClassClass)this.Module.Class.Get(entry);
            a = this.ClassIndexGet(entryClass);
        }
        return a;
    }

    protected virtual bool ClassIndexAdd(ClassClass varClass)
    {
        Value a;
        a = new Value();
        a.Init();
        a.Mid = this.ClassIndexTable.Count;
        this.ListInfra.TableAdd(this.ClassIndexTable, varClass, a);
        return true;
    }

    protected virtual int ClassIndexGet(ClassClass varClass)
    {
        Value a;
        a = (Value)this.ClassIndexTable.Get(varClass);
        return a.Mid;
    }
}