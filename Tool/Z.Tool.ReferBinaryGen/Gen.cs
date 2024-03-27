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

    protected virtual Table ModuleTable { get; set; }
    protected virtual Module Module { get; set; }
    protected virtual Table DotNetBuiltInTypeTable { get; set; }
    protected virtual Class AnyClass { get; set; }
    protected virtual bool IsAvalonInfra { get; set; }

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
        Module module;
        module = new Module();
        module.Init();
        module.Name = assembly.GetName().Name;
        module.Assembly = assembly;
        this.Module = module;

        ListEntry entry;
        entry = new ListEntry();
        entry.Init();
        entry.Index = module.Name;
        entry.Value = module;
        this.ModuleTable.Add(entry);

        this.IsAvalonInfra = (this.Module.Name == "Avalon.Infra");

        this.SetClassList();

        this.SetImportList();

        return true;
    }

    protected virtual bool SetImportList()
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
            
            this.AddClassToImportTable(a.Base);
            

            int countA;
            int iA;

            countA = a.Field.Count;
            iA = 0;
            while (iA < countA)
            {
                Field field;
                field = (Field)a.Field.Get(iA);
                this.AddClassToImportTable(field.Class);
                iA = iA + 1;
            }

            countA = a.Maide.Count;
            iA = 0;
            while (iA < countA)
            {
                Maide maide;
                maide = (Maide)a.Maide.Get(iA);
                this.AddClassToImportTable(maide.Class);

                Array varArray;
                varArray = maide.Param;

                int countAa;
                countAa = varArray.Count;
                int iAa;
                iAa = 0;
                while (iAa < countAa)
                {
                    Var varVar;
                    varVar = (Var)varArray.Get(iAa);

                    this.AddClassToImportTable(varVar.Class);

                    iAa = iAa + 1;
                }

                iA = iA + 1;
            }
        }
        return true;
    }

    protected virtual bool AddClassToImportTable(Class varClass)
    {
        if (varClass.Module == this.Module)
        {
            return true;
        }

        Table table;
        table = this.Module.Import;
        
        string moduleName;
        moduleName = varClass.Module.Name;
        if (!table.Contain(moduleName))
        {
            Table classTable;
            classTable = new Table();
            classTable.Compare = new StringCompare();
            classTable.Compare.Init();
            classTable.Init();

            ListEntry oa;
            oa = new ListEntry();
            oa.Init();
            oa.Index = moduleName;
            oa.Value = classTable;
            table.Add(oa);
        }
        Table oo;
        oo = (Table)table.Get(moduleName);

        string name;
        name = varClass.Name;

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

    protected virtual bool SetClassList()
    {
        Table table;
        table = new Table();
        table.Compare = new StringCompare();
        table.Compare.Init();
        table.Init();
        
        this.Module.Class = table;

        this.AddClassList();

        this.AddBaseList();

        this.AddPartList();


        return true;
    }

    protected virtual bool AddClassList()
    {
        SystemType[] typeArray;
        typeArray = this.Module.Assembly.GetExportedTypes();

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

            this.AddInfraBuiltInClassList();
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
        return true;
    }

    protected virtual bool AddBaseList()
    {
        if (this.IsAvalonInfra)
        {
            Class anyClass;
            anyClass = this.ModuleClassGet(this.Module, "Any");
            this.AnyClass = anyClass;

            anyClass.Base = anyClass;

            this.ClassBaseSetAny("Bool");
            this.ClassBaseSetAny("Int");
            this.ClassBaseSetAny("String");
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            if (a.Base == null)
            {
                SystemType oa;
                oa = a.Type.BaseType;

                Class ob;
                ob = this.ClassGetType(oa);
                a.Base = ob;
            }
        }
        return true;
    }

    protected virtual bool AddPartList()
    {
        if (this.IsAvalonInfra)
        {
            this.ClassPartSetEmpty("Bool");
            this.ClassPartSetEmpty("Int");
            this.ClassPartSetEmpty("String");
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            if (a.Field == null)
            {
                this.AddPart(a);
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

                global::System.Console.Write("Class: " + a.Name + ", Base: " + a.Base.Name + "(" + a.Base.Module.Name + ")" + "\n");

                int countA;
                int iA;

                countA = a.Field.Count;
                iA = 0;
                while (iA < countA)
                {
                    PropertyInfo property;
                    property = (PropertyInfo)a.Field.Get(iA);
                    global::System.Console.Write("    Field: " + property.Name + ", Count: " + this.CountString(property.GetMethod) + ", ResultType: " + property.PropertyType.Name + "\n");
                    iA = iA + 1;
                }

                countA = a.Maide.Count;
                iA = 0;
                while (iA < countA)
                {
                    MethodInfo method;
                    method = (MethodInfo)a.Maide.Get(iA);
                    global::System.Console.Write("    Maide: " + method.Name + ", Count: " + this.CountString(method) + ", ResultType: " + method.ReturnType.Name + "\n");
                    
                    ParameterInfo[] parameterArray;
                    parameterArray = method.GetParameters();
                    int countAa;
                    countAa = parameterArray.Length;
                    int iAa;
                    iAa = 0;
                    while (iAa < countAa)
                    {
                        ParameterInfo parameter;
                        parameter = parameterArray[iAa];
                        global::System.Console.Write("        Var: " + parameter.Name + ", Type: " + parameter.ParameterType.Name + "\n");

                        iAa = iAa + 1;
                    }

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
                if (!oa.StartsWith("Avalon."))
                {
                    global::System.Console.Error.Write("Is Not Avalon Module\n");
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

        a.Index = this.Module.Class.Count;
        a.Name = type.Name;
        a.Module = this.Module;

        a.Type = type;


        ListEntry ea;
        ea = new ListEntry();
        ea.Init();
        ea.Index = a.Name;
        ea.Value = a;

        this.Module.Class.Add(ea);

        return true;
    }

    protected virtual bool AddPart(Class varClass)
    {
        SystemType type;
        type = varClass.Type;

        PropertyInfo[] propertyArrayA;
        propertyArrayA = type.GetProperties(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        MethodInfo[] methodArrayA;
        methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        int count;
        int i;
        ListList fieldList;
        fieldList = new ListList();
        fieldList.Init();

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
                    Field field;
                    field = new Field();
                    field.Name = property.Name;
                    field.Class = this.ClassGetType(property.PropertyType);
                    field.Count = this.CountGet(property.GetMethod);
                    field.Property = property;
                    fieldList.Add(field);
                }
            }

            i = i + 1;
        }

        Array fieldArray;
        fieldArray = this.ListInfra.ArrayCreateList(fieldList);

        ListList maideList;
        maideList = new ListList();
        maideList.Init();

        count = methodArrayA.Length;
        i = 0;
        while (i < count)
        {
            MethodInfo method;
            method = methodArrayA[i];

            if (!method.IsSpecialName & this.IsInAbstract(method) & !((type == typeof(EntryEntry)) & (method.Name == "ArgSet")))
            {
                Maide maide;
                maide = new Maide();
                maide.Init();
                maide.Name = method.Name;
                maide.Class = this.ClassGetType(method.ReturnType);
                maide.Count = this.CountGet(method);
                maide.Method = method;

                ParameterInfo[] parameterArray;
                parameterArray = method.GetParameters();
                int countA;
                countA = parameterArray.Length;

                Array varArray;
                varArray = this.ListInfra.ArrayCreate(countA);

                int iA;
                iA = 0;
                while (iA < countA)
                {
                    ParameterInfo parameter;
                    parameter = parameterArray[iA];
                    Var varVar;
                    varVar = new Var();
                    varVar.Init();
                    varVar.Name = parameter.Name;
                    varVar.Class = this.ClassGetType(parameter.ParameterType);
                    varVar.Parameter = parameter;

                    varArray.Set(iA, varVar);

                    iA = iA + 1;
                }
                maide.Param = varArray;

                maideList.Add(maide);
            }

            i = i + 1;
        }

        Array maideArray;
        maideArray = this.ListInfra.ArrayCreateList(maideList);

        varClass.Field = fieldArray;
        varClass.Maide = maideArray;

        return true;
    }

    protected virtual Module ModuleGet(string module)
    {
        return (Module)this.ModuleTable.Get(module);
    }

    protected virtual Class ModuleClassGet(Module module, string name)
    {
        return (Class)module.Class.Get(name);
    }

    protected virtual Class ClassGetType(SystemType type)
    {
        string module;
        string varClass;
        module = null;
        varClass = null;
        bool b;
        b = this.IsDotNetBuiltInType(type);
        if (b)
        {
            module = "Avalon.Infra";
            varClass = (string)this.DotNetBuiltInTypeTable.Get(type);
        }
        if (!b)
        {
            module = type.Assembly.GetName().Name;
            varClass = type.Name;
        }
        Class a;
        a = this.ClassGet(module, varClass);
        if (a == null)
        {
            global::System.Console.Write("ClassGetType no class, type: " + varClass + "(" + module + ")" + "\n");
            global::System.Environment.Exit(100);
        }
        return a;
    }

    protected virtual Class ClassGet(string module, string name)
    {
        Module o;
        o = this.ModuleGet(module);
        Class oa;
        oa = this.ModuleClassGet(o, name);
        return oa;
    }

    protected virtual bool ClassBaseSetAny(string name)
    {
        Class a;
        a = this.ModuleClassGet(this.Module, name);
        a.Base = this.AnyClass;
        return true;
    }

    protected virtual bool ClassPartSetEmpty(string name)
    {
        Class a;
        a = this.ModuleClassGet(this.Module, name);
        a.Field = this.ListInfra.ArrayCreate(0);
        a.Maide = this.ListInfra.ArrayCreate(0);
        return true;
    }

    protected virtual bool AddInfraBuiltInClassList()
    {
        this.AddBuiltInClass("Bool");
        this.AddBuiltInClass("Int");
        this.AddBuiltInClass("String");
        return true;
    }

    protected virtual bool AddBuiltInClass(string name)
    {
        int index;
        index = this.Module.Class.Count;

        Class a;
        a = new Class();
        a.Init();
        a.Index = index;
        a.Name = name;
        a.Module = this.Module;

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

    protected virtual int CountGet(MethodInfo method)
    {
        int a;
        a = -1;
        if (method.IsPublic)
        {
            a = 0;
        }
        if (method.IsAssembly)
        {
            a = 1;
        }
        if (method.IsFamily)
        {
            a = 2;
        }
        if (method.IsPrivate)
        {
            a = 3;
        }
        return a;
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