namespace Z.Tool.ReferBinaryGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;

        Table table;
        table = new Table();
        table.Compare = new RefCompare();
        table.Compare.Init();
        table.Init();

        this.DotNetBuiltInTypeTable = table;

        this.AddDotNetBuiltInType(typeof(object), "Any");
        this.AddDotNetBuiltInType(typeof(bool), "Bool");
        this.AddDotNetBuiltInType(typeof(int), "Int");
        this.AddDotNetBuiltInType(typeof(uint), "Int");
        this.AddDotNetBuiltInType(typeof(long), "Int");
        this.AddDotNetBuiltInType(typeof(ulong), "Int");
        this.AddDotNetBuiltInType(typeof(short), "Int");
        this.AddDotNetBuiltInType(typeof(ushort), "Int");
        this.AddDotNetBuiltInType(typeof(byte), "Int");
        this.AddDotNetBuiltInType(typeof(sbyte), "Int");
        this.AddDotNetBuiltInType(typeof(char), "Int");
        this.AddDotNetBuiltInType(typeof(string), "String");
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }

    protected virtual Assembly Assembly { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Module Module { get; set; }
    protected virtual Table DotNetBuiltInTypeTable { get; set; }

    public virtual int Execute()
    {
        this.ModuleTable = new Table();
        this.ModuleTable.Compare = new StringCompare();
        this.ModuleTable.Compare.Init();
        this.ModuleTable.Init();


        this.ExecuteModule(typeof(Any).Assembly);
        this.ExecuteModule(typeof(ListList).Assembly);
        this.ExecuteModule(typeof(Math).Assembly);
        this.ExecuteModule(typeof(Text).Assembly);
        this.ExecuteModule(typeof(Comp).Assembly);
        this.ExecuteModule(typeof(Event).Assembly);
        this.ExecuteModule(typeof(Thread).Assembly);
        this.ExecuteModule(typeof(Stream).Assembly);
        this.ExecuteModule(typeof(Type).Assembly);
        this.ExecuteModule(typeof(Time).Assembly);
        this.ExecuteModule(typeof(Video).Assembly);
        this.ExecuteModule(typeof(Effect).Assembly);
        this.ExecuteModule(typeof(Storage).Assembly);
        this.ExecuteModule(typeof(Network).Assembly);
        this.ExecuteModule(typeof(Console).Assembly);
        this.ExecuteModule(typeof(Play).Assembly);
        this.ExecuteModule(typeof(Draw).Assembly);
        this.ExecuteModule(typeof(View).Assembly);
        this.ExecuteModule(typeof(Main).Assembly);
        this.ExecuteModule(typeof(EntryEntry).Assembly);

        this.ConsoleWrite();

        return 0;
    }

    protected virtual bool ExecuteModule(Assembly assembly)
    {
        this.Assembly = assembly;

        Module module;
        module = new Module();
        module.Init();
        module.Name = this.Assembly.GetName().Name;
        this.Module = module;

        ListEntry entry;
        entry = new ListEntry();
        entry.Init();
        entry.Index = module.Name;
        entry.Value = module;
        this.ModuleTable.Add(entry);

        this.SetClass();

        this.SetImport();

        return true;
    }

    protected virtual bool SetImport()
    {
        Table table;
        table = new Table();
        table.Compare = new StringCompare();
        table.Compare.Init();
        table.Init();

        this.Module.Import = table;

        Table classTable;
        classTable = this.Module.Class;

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;
            
            SystemType type;
            type = a.Type;

            SystemType baseType;
            baseType = type.BaseType;

            this.AddTypeToImportTable(baseType);

            int countA;
            int iA;

            countA = a.Property.Count;
            iA = 0;
            while (iA < countA)
            {
                PropertyInfo property;
                property = (PropertyInfo)a.Property.Get(iA);
                this.AddTypeToImportTable(property.PropertyType);
                iA = iA + 1;
            }

            countA = a.Method.Count;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = (MethodInfo)a.Method.Get(iA);
                this.AddTypeToImportTable(method.ReturnType);

                ParameterInfo[] ooo;
                ooo = method.GetParameters();

                int countAa;
                countAa = ooo.Length;
                int iAa;
                iAa = 0;
                while (iAa < countAa)
                {
                    ParameterInfo ooa;
                    ooa = ooo[iAa];

                    this.AddTypeToImportTable(ooa.ParameterType);

                    iAa = iAa + 1;
                }

                iA = iA + 1;
            }
        }
        return true;
    }

    protected virtual bool AddTypeToImportTable(SystemType type)
    {
        Assembly assembly;
        assembly = null;

        bool b;
        b = this.IsDotNetBuiltInType(type);
        if (b)
        {
            assembly = typeof(Any).Assembly;
        }
        if (!b)
        {
            assembly = type.Assembly;
        }

        if (assembly == this.Assembly)
        {
            return true;
        }

        Table table;
        table = this.Module.Import;
        
        string moduleName;
        moduleName = assembly.GetName().Name;
        if (!table.Contain(moduleName))
        {
            Table typeTable;
            typeTable = new Table();
            typeTable.Compare = new StringCompare();
            typeTable.Compare.Init();
            typeTable.Init();

            ListEntry oa;
            oa = new ListEntry();
            oa.Init();
            oa.Index = moduleName;
            oa.Value = typeTable;
            table.Add(oa);
        }
        Table oo;
        oo = (Table)table.Get(moduleName);

        string name;
        name = null;

        if (b)
        {
            name = (string)this.DotNetBuiltInTypeTable.Get(type);
        }
        if (!b)
        {
            name = type.Name;
        }

        if (oo.Contain(name))
        {
            return true;
        }
        
        ListEntry ob;
        ob = new ListEntry();
        ob.Init();
        ob.Index = name;
        ob.Value = name;
        oo.Add(ob);
        return true;
    }

    protected virtual bool SetClass()
    {
        Assembly o;
        o = this.Assembly;

        Table table;
        table = new Table();
        table.Compare = new StringCompare();
        table.Compare.Init();
        table.Init();
        
        this.Module.Class = table;


        SystemType[] typeArray;
        typeArray = o.GetExportedTypes();

        SystemType anyType;
        anyType = null;
        bool b;
        b = (this.Module.Name == "Avalon.Infra");
        if (b)
        {
            anyType = this.AnyType(typeArray);

            if (anyType == null)
            {
                global::System.Console.Error.Write("Any class not found\n");
            }

            this.AddClass(anyType);

            Class aa;
            aa = (Class)this.Module.Class.Get("Any");
            aa.Base = aa;

            this.AddInfraBuiltInTypeList();
        }

        int count;
        count = typeArray.Length;
        int i;
        i = 0;
        while (i < count)
        {
            SystemType type;
            type = typeArray[i];

            if (!(b & (type == anyType)))
            {
                this.AddClass(type);
            }

            i = i + 1;
        }

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;
            
            if (a.Base == null)
            {
                SystemType oa;
                oa = a.Type.BaseType;

                string moduleName;
                moduleName = oa.Assembly.GetName().Name;
                string name;
                name = oa.Name;

                Module module;
                module = (Module)this.ModuleTable.Get(moduleName);

                Class baseClass;
                baseClass = (Class)module.Class.Get(name);

                a.Base = baseClass;
            }
        }

        return true;
    }

    protected virtual bool ConsoleWrite()
    {
        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);

        while (iter.Next())
        {
            Module module;
            module = (Module)iter.Value;
            
            global::System.Console.Write("--------------\n");
            global::System.Console.Write(module.Name + "\n");
            global::System.Console.Write("--------------\n");

            Table table;
            table = module.Class;
            Iter iterA;
            iterA = table.IterCreate();
            table.IterSet(iterA);
            while (iterA.Next())
            {
                Class a;
                a = (Class)iterA.Value;

                SystemType type;
                type = a.Type;

                SystemType baseType;
                baseType = type.BaseType;

                global::System.Console.Write("Class: " + a.Name + ", Base: " + a.Base.Name + "(" + a.Base.Module.Name + ")" + "\n");

                int countA;
                int iA;

                countA = a.Property.Count;
                iA = 0;
                while (iA < countA)
                {
                    PropertyInfo property;
                    property = (PropertyInfo)a.Property.Get(iA);
                    global::System.Console.Write("    Field: " + property.Name + ", Count: " + this.CountString(property.GetMethod) + ", ResultType: " + property.PropertyType.Name + "\n");
                    iA = iA + 1;
                }

                countA = a.Method.Count;
                iA = 0;
                while (iA < countA)
                {
                    MethodInfo method;
                    method = (MethodInfo)a.Method.Get(iA);
                    global::System.Console.Write("    Maide: " + method.Name + ", Count: " + this.CountString(method) + ", ResultType: " + method.ReturnType.Name + "\n");
                    iA = iA + 1;
                }
            }

            global::System.Console.Write("--------\n");

            iterA = module.Import.IterCreate();
            module.Import.IterSet(iterA);

            while (iterA.Next())
            {
                string oa;
                oa = (string)iterA.Index;

                global::System.Console.Write(oa + "\n");

                Table ob;
                ob = (Table)iterA.Value;

                Iter iterB;
                iterB = ob.IterCreate();
                ob.IterSet(iterB);
                while (iterB.Next())
                {
                    string typeName;
                    typeName = (string)iterB.Index;
                    global::System.Console.Write("    " + typeName + "\n");
                }

                if (oa.StartsWith("System."))
                {
                    global::System.Console.Error.Write("Is DotNet BCL\n");
                    return true;
                }
            }
        }
        return true;
    }

    protected virtual bool AddClass(SystemType type)
    {
        Class a;
        a = new Class();
        a.Init();

        SystemType baseType;
        baseType = type.BaseType;

        a.Index = this.Module.Class.Count;
        a.Name = type.Name;
        a.Module = this.Module;

        a.Type = type;

        PropertyInfo[] propertyArrayA;
        propertyArrayA = type.GetProperties(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        MethodInfo[] methodArrayA;
        methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        int count;
        int i;
        ListList propertyList;
        propertyList = new ListList();
        propertyList.Init();

        count = propertyArrayA.Length;
        i = 0;
        while (i < count)
        {
            PropertyInfo property;
            property = propertyArrayA[i];

            if (!property.IsSpecialName & property.CanRead & property.CanWrite)
            {
                if (this.IsInAbstract(property.GetMethod) & !((type == typeof(Data)) & (property.Name == "Value")))
                {
                    propertyList.Add(property);
                }
            }

            i = i + 1;
        }

        Array propertyArray;
        propertyArray = this.ListInfra.ArrayCreateList(propertyList);

        ListList methodList;
        methodList = new ListList();
        methodList.Init();

        count = methodArrayA.Length;
        i = 0;
        while (i < count)
        {
            MethodInfo method;
            method = methodArrayA[i];

            if (!method.IsSpecialName & this.IsInAbstract(method))
            {
                methodList.Add(method);
            }

            i = i + 1;
        }

        Array methodArray;
        methodArray = this.ListInfra.ArrayCreateList(methodList);

        a.Property = propertyArray;
        a.Method = methodArray;

        ListEntry ea;
        ea = new ListEntry();
        ea.Init();
        ea.Index = a.Name;
        ea.Value = a;

        this.Module.Class.Add(ea);

        return true;
    }

    protected virtual bool AddInfraBuiltInTypeList()
    {
        this.AddBuiltInType("Bool");
        this.AddBuiltInType("Int");
        this.AddBuiltInType("String");
        return true;
    }

    protected virtual bool AddBuiltInType(string name)
    {
        int index;
        index = this.Module.Class.Count;

        Class baseClass;
        baseClass = (Class)this.Module.Class.Get("Any");

        Class a;
        a = new Class();
        a.Init();
        a.Index = index;
        a.Name = name;
        a.Base = baseClass;
        a.Module = this.Module;
        a.Property = this.ListInfra.ArrayCreate(0);
        a.Method = this.ListInfra.ArrayCreate(0);

        ListEntry entry;
        entry = new ListEntry();
        entry.Init();
        entry.Index = a.Name;
        entry.Value = a;

        this.Module.Class.Add(entry);
        return true;
    }

    protected virtual SystemType AnyType(SystemType[] typeArray)
    {
        int count;
        count = typeArray.Length;
        int i;
        i = 0;
        while (i < count)
        {
            SystemType type;
            type = typeArray[i];

            if (type.Name == "Any")
            {
                return type;
            }

            i = i + 1;
        }
        return null;
    }

    protected virtual bool AddDotNetBuiltInType(SystemType type, string name)
    {
        ListEntry entry;
        entry = new ListEntry();
        entry.Init();
        entry.Index = type;
        entry.Value = name;
        this.DotNetBuiltInTypeTable.Add(entry);
        return true;
    }

    protected virtual bool IsDotNetBuiltInType(SystemType type)
    {
        return this.DotNetBuiltInTypeTable.Contain(type);
    }

    protected virtual string CountString(MethodInfo method)
    {
        if (method.IsPublic)
        {
            return "Prudate";
        }
        if (method.IsAssembly)
        {
            return "Probate";
        }
        if (method.IsFamily)
        {
            return "Precate";
        }
        if (method.IsPrivate)
        {
            return "Private";
        }
        return null;
    }

    protected virtual bool IsInAbstract(MethodInfo method)
    {
        return method.IsPublic | method.IsFamily;
    }
}