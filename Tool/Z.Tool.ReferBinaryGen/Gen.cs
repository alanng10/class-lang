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

        this.SetClass();

        this.SetImport();

        this.ConsoleWrite();

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
        
        string assemblyName;
        assemblyName = assembly.GetName().Name;
        if (!table.Contain(assemblyName))
        {
            Table typeTable;
            typeTable = new Table();
            typeTable.Compare = new StringCompare();
            typeTable.Compare.Init();
            typeTable.Init();

            ListEntry oa;
            oa = new ListEntry();
            oa.Init();
            oa.Index = assemblyName;
            oa.Value = typeTable;
            table.Add(oa);
        }
        Table oo;
        oo = (Table)table.Get(assemblyName);

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

        SystemType[] typeArray;
        typeArray = o.GetExportedTypes();

        int count;
        count = typeArray.Length;
        int i;
        i = 0;
        while (i < count)
        {
            Class a;
            a = new Class();
            a.Init();

            SystemType type;
            type = typeArray[i];

            SystemType baseType;
            baseType = type.BaseType;

            a.Type = type;

            PropertyInfo[] propertyArrayA;
            propertyArrayA = type.GetProperties(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

            MethodInfo[] methodArrayA;
            methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

            int countA;
            int iA;
            ListList propertyList;
            propertyList = new ListList();
            propertyList.Init();

            countA = propertyArrayA.Length;
            iA = 0;
            while (iA < countA)
            {
                PropertyInfo property;
                property = propertyArrayA[iA];

                if (!property.IsSpecialName & property.CanRead & property.CanWrite)
                {
                    if (this.IsInAbstract(property.GetMethod) & !((type == typeof(Data)) & (property.Name == "Value")))
                    {
                        propertyList.Add(property);
                    }
                }

                iA = iA + 1;
            }

            Array propertyArray;
            propertyArray = this.ListInfra.ArrayCreateList(propertyList);

            ListList methodList;
            methodList = new ListList();
            methodList.Init();

            countA = methodArrayA.Length;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = methodArrayA[iA];

                if (!method.IsSpecialName & this.IsInAbstract(method))
                {
                    methodList.Add(method);
                }

                iA = iA + 1;
            }

            Array methodArray;
            methodArray = this.ListInfra.ArrayCreateList(methodList);

            a.Property = propertyArray;
            a.Method = methodArray;

            ListEntry ea;
            ea = new ListEntry();
            ea.Init();
            ea.Index = a.Type.Name;
            ea.Value = a;

            table.Add(ea);

            i = i + 1;
        }


        this.Module.Class = table;

        return true;
    }

    protected virtual bool ConsoleWrite()
    {
        string assemblyName;
        assemblyName = this.Assembly.GetName().Name;
        
        global::System.Console.Write("--------------\n");
        global::System.Console.Write(assemblyName + "\n");
        global::System.Console.Write("--------------\n");

        Table table;
        table = (Table)this.Module.Class;
        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            SystemType type;
            type = a.Type;

            SystemType baseType;
            baseType = type.BaseType;

            global::System.Console.Write("Class: " + type.Name + ", Base: " + baseType.Name + "(" + baseType.Assembly.GetName().Name + ")" + "\n");

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

        iter = this.Module.Import.IterCreate();
        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            string oa;
            oa = (string)iter.Index;

            global::System.Console.Write(oa + "\n");
            if (oa.StartsWith("System."))
            {
                global::System.Console.Error.Write("Is DotNet BCL\n");
            }

            Table ob;
            ob = (Table)iter.Value;

            Iter iterA;
            iterA = ob.IterCreate();
            ob.IterSet(iterA);
            while (iterA.Next())
            {
                string typeName;
                typeName = (string)iterA.Index;
                global::System.Console.Write("    " + typeName + "\n");
            }
        }
        return true;
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