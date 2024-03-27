namespace Z.Tool.ReferBinaryGen;

class ReferGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table ReferTable { get; set; }
    public virtual Table DotNetBuiltInTypeTable { get; set; }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Module Module { get; set; }
    protected virtual Table ClassIndexTable { get; set; }

    public virtual bool Execute()
    {
        this.ReferTable = new Table();
        this.ReferTable.Compare = new StringCompare();
        this.ReferTable.Compare.Init();
        this.ReferTable.Init();

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);
        while (iter.Next())
        {
            Module module;
            module = (Module)iter.Value;
            Refer refer;
            refer = this.ExecuteModule(module);
            this.ListInfra.TableAdd(this.ReferTable, refer.Ref.Name, refer);
        }

        return true;
    }

    protected virtual Refer ExecuteModule(Module module)
    {
        this.Module = module;

        this.ClassIndexTable = new Table();
        this.ClassIndexTable.Compare = new RefCompare();
        this.ClassIndexTable.Compare.Init();
        this.ClassIndexTable.Init();

        ModuleRef oa;
        oa = this.ModuleRefCreate(module.Ref.Name);

        Refer refer;
        refer = new Refer();
        refer.Init();
        refer.Ref = oa;

        refer.Class = this.ExecuteClassArray();
        refer.Import = this.ExecuteImportArray();
        refer.Base = this.ExecuteBaseArray();
        refer.Part = this.ExecutePartArray();

        return refer;
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

            ReferClass a;
            a = new ReferClass();
            a.Init();
            a.Name = oa.Name;
            
            array.Set(i, a);

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
            string name;
            name = (string)iter.Index;
            Table table;
            table = (Table)iter.Value;

            ModuleRef oa;
            oa = this.ModuleRefCreate(name);

            ReferImport a;
            a = new ReferImport();
            a.Init();
            a.Module = oa;

            Array aa;
            aa = this.ExecuteImportClassArray(table);

            a.Class = aa;

            array.Set(i, a);
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
    
            ReferImportClass a;
            a = new ReferImportClass();
            a.Init();
            a.Class = oa.Index;
            array.Set(i, a);
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

            ReferBase a;
            a = new ReferBase();
            a.Init();
            a.Class = aa;

            array.Set(i, a);
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

            ReferPart a;
            a = new ReferPart();
            a.Init();
            a.Field = this.ExecuteFieldArray(oa);
            a.Maide = this.ExecuteMaideArray(oa);

            array.Set(i, a);
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

            PropertyInfo property;
            property = (PropertyInfo)oa.Any;

            ReferField a;
            a = new ReferField();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemClass = this.SystemClassGet(property.PropertyType);
            a.Count = oa.Count.Index;
            a.Name = oa.Name;

            array.Set(i, a);
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

            MethodInfo method;
            method = (MethodInfo)oa.Any;

            ReferMaide a;
            a = new ReferMaide();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemClass = this.SystemClassGet(method.ReturnType);
            a.Count = oa.Count.Index;
            a.Name = oa.Name;

            Array varArray;
            varArray = this.ExecuteVarArray(oa.Param);
            a.Param = varArray;

            array.Set(i, a);
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

            ParameterInfo parameter;
            parameter = (ParameterInfo)oa.Any;

            ReferVar a;
            a = new ReferVar();
            a.Init();
            a.Class = this.ClassIndexGet(oa.Class);
            a.SystemClass = this.SystemClassGet(parameter.ParameterType);
            a.Name = oa.Name;

            array.Set(i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual bool ClassIndexAdd(ClassClass varClass)
    {
        ClassIndex a;
        a = new ClassIndex();
        a.Init();
        a.Value = this.ClassIndexTable.Count;
        this.ListInfra.TableAdd(this.ClassIndexTable, varClass, a);
        return true;
    }

    protected virtual int ClassIndexGet(ClassClass varClass)
    {
        ClassIndex a;
        a = (ClassIndex)this.ClassIndexTable.Get(varClass);
        return a.Value;
    }

    protected virtual int SystemClassGet(SystemType type)
    {
        BuiltInType a;
        a = this.BuitInTypeGet(type);
        if (a == null)
        {
            return 0;
        }
        return a.SystemClass;
    }

    protected virtual BuiltInType BuitInTypeGet(SystemType type)
    {
        BuiltInType a;
        a = (BuiltInType)this.DotNetBuiltInTypeTable.Get(type);
        return a;
    }
    
    protected virtual ModuleRef ModuleRefCreate(string name)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        return a;
    }
}