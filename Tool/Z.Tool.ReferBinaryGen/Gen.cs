namespace Z.Tool.ReferBinaryGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();

        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.Console = Console.This;
        this.CountList = CountList.This;

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.DotNetBuiltInTypeTable = this.ClassInfra.TableCreateRefCompare();

        this.AddDotNetBuiltInType(typeof(object), "Any");
        this.AddDotNetBuiltInType(typeof(bool), "Bool");
        this.AddDotNetBuiltInType(typeof(ulong), "Int");
        this.AddDotNetBuiltInType(typeof(long), "Int");
        this.AddDotNetBuiltInType(typeof(uint), "Int");
        this.AddDotNetBuiltInType(typeof(int), "Int");
        this.AddDotNetBuiltInType(typeof(ushort), "Int");
        this.AddDotNetBuiltInType(typeof(short), "Int");
        this.AddDotNetBuiltInType(typeof(byte), "Int");
        this.AddDotNetBuiltInType(typeof(sbyte), "Int");
        this.AddDotNetBuiltInType(typeof(char), "Int");
        this.AddDotNetBuiltInType(typeof(string), "String");

        this.CountArray = this.ListInfra.ArrayCreate(4);
        this.Array = this.CountArray;
        this.SetCountString("Prudate");
        this.SetCountString("Probate");
        this.SetCountString("Precate");
        this.SetCountString("Private");
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Console Console { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Module Module { get; set; }
    protected virtual Table DotNetBuiltInTypeTable { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual Array CountArray { get; set; }
    protected virtual SystemType InfraAnyType { get; set; }
    protected virtual ClassClass AnyClass { get; set; }
    protected virtual bool IsAvalonInfra { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual int Index { get; set; }
    protected virtual Array SealedClassArray { get; set; }

    public virtual int Execute()
    {
        this.ModuleTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.ExecuteTypeModule(typeof(Any));
        this.ExecuteTypeModule(typeof(ListList));
        this.ExecuteTypeModule(typeof(Math));
        this.ExecuteTypeModule(typeof(Text));
        this.ExecuteTypeModule(typeof(Event));
        this.ExecuteTypeModule(typeof(Comp));
        this.ExecuteTypeModule(typeof(Thread));
        this.ExecuteTypeModule(typeof(Stream));
        this.ExecuteTypeModule(typeof(Type));
        this.ExecuteTypeModule(typeof(Time));
        this.ExecuteTypeModule(typeof(Storage));
        this.ExecuteTypeModule(typeof(Network));
        this.ExecuteTypeModule(typeof(Console));
        this.ExecuteTypeModule(typeof(Draw));
        this.ExecuteTypeModule(typeof(View));
        this.ExecuteTypeModule(typeof(Play));
        this.ExecuteTypeModule(typeof(EntryEntry));
        this.ExecuteTypeModule(typeof(ClassClass));
        this.ExecuteTypeModule(typeof(Binary));
        this.ExecuteTypeModule(typeof(InfoGen));
        this.ExecuteTypeModule(typeof(Port));
        this.ExecuteTypeModule(typeof(Token));
        this.ExecuteTypeModule(typeof(Node));
        this.ExecuteTypeModule(typeof(ModuleResult));
        this.ExecuteTypeModule(typeof(Task));

        Module module;
        module = this.ModuleGet("System.Infra");
        this.ConsoleWriteClass(this.ModuleClassGet(module, "String"));
        this.ConsoleWriteClass(this.ModuleClassGet(module, "Infra"));
        this.ConsoleWriteClass(this.ClassGet("Class.Node", "SetCreateOperate"));

        //this.ConsoleWrite();

        BinaryGen binaryGen;
        binaryGen = new BinaryGen();
        binaryGen.Init();
        binaryGen.ModuleTable = this.ModuleTable;

        binaryGen.Execute();

        this.BinaryTable = binaryGen.BinaryTable;

        this.ExecuteBinaryWrite();

        return 0;
    }

    protected virtual bool ExecuteTypeModule(SystemType type)
    {
        return this.ExecuteModule(type.Assembly);
    }

    protected virtual bool ExecuteModule(Assembly assembly)
    {
        string assemblyName;
        assemblyName = assembly.GetName().Name;
        if (assemblyName.StartsWith("System.") | assemblyName == "System")
        {
            global::System.Console.Error.Write("ExecuteModule assemblyName is BCL assembly name: " + assemblyName + "\n");
            global::System.Environment.Exit(141);
        }

        string moduleName;
        moduleName = this.ClassModuleName(assemblyName);

        ModuleRef oa;
        oa = new ModuleRef();
        oa.Init();
        oa.Name = moduleName;

        Module module;
        module = new Module();
        module.Init();
        module.Ref = oa;
        module.Any = assembly;
        this.Module = module;

        this.ListInfra.TableAdd(this.ModuleTable, module.Ref, module);

        this.IsAvalonInfra = (this.Module.Ref.Name == "System.Infra");

        this.SetClassList();

        this.SetImportList();

        this.SetVirtualList();

        this.SetEntry();
        return true;
    }

    protected virtual bool SetClassList()
    {
        Table table;
        table = this.ClassInfra.TableCreateStringCompare();

        this.Module.Class = table;

        this.AddClassList();

        this.AddBaseList();

        this.AddPartList();
        return true;
    }

    protected virtual bool AddClassList()
    {
        Assembly assembly;
        assembly = (Assembly)this.Module.Any;
        SystemType[] typeArray;
        typeArray = assembly.GetExportedTypes();

        SystemType anyType;
        anyType = null;
        bool b;
        b = this.IsAvalonInfra;
        if (b)
        {
            anyType = this.AnyTypeGet(typeArray);

            if (anyType == null)
            {
                global::System.Console.Error.Write("Any class not found\n");
                global::System.Environment.Exit(103);
            }
            this.InfraAnyType = anyType;

            this.AddClass(anyType);

            this.AddInfraBuiltInClassList();

            this.AnyClass = this.ModuleClassGet(this.Module, "Any");
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
            this.AnyClass.Base = this.AnyClass;

            this.ClassBaseSetAny("Bool");
            this.ClassBaseSetAny("Int");
            this.ClassBaseSetAny("String");

            this.SealedClassArray = this.ListInfra.ArrayCreate(4);

            Module oo;
            oo = this.Module;
            ClassClass boolClass;
            boolClass = this.ModuleClassGet(oo, "Bool");
            ClassClass intClass;
            intClass = this.ModuleClassGet(oo, "Int");
            ClassClass stringClass;
            stringClass = this.ModuleClassGet(oo, "String");

            this.Array = this.SealedClassArray;
            this.Index = 0;
            this.ArraySetItem(boolClass);
            this.ArraySetItem(intClass);
            this.ArraySetItem(stringClass);
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            if (a.Base == null)
            {
                SystemType oa;
                oa = (SystemType)a.Any;
                SystemType ob;
                ob = oa.BaseType;

                ClassClass oc;
                oc = this.ClassGetType(ob);
                
                if (this.ArrayContainItem(this.SealedClassArray, oc))
                {
                    global::System.Console.Error.Write("Class " + oc.Name + "(" + oc.Module.Ref.Name + ")" + " cannot be derived\n");
                    global::System.Environment.Exit(104);
                }

                a.Base = oc;
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
            this.ClassPartSetNameZ("String", typeof(ZString));
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            if (a.Field == null)
            {
                this.AddPart(a);
            }
        }

        return true;
    }

    protected virtual bool AddClass(SystemType type)
    {
        if (!this.TypeIsClass(type))
        {
            global::System.Console.Error.Write("AddClass type is not C# class: " + type.Name + "\n");
            global::System.Environment.Exit(143);
        }

        if ((type == typeof(StorageArrange)) | (type == typeof(ConsoleProgram)))
        {
            return true;
        }

        ClassClass a;
        a = new ClassClass();
        a.Init();

        a.Index = this.Module.Class.Count;
        a.Name = type.Name;
        a.Module = this.Module;

        a.Any = type;

        this.ListInfra.TableAdd(this.Module.Class, a.Name, a);

        return true;
    }

    protected virtual bool AddPart(ClassClass varClass)
    {
        SystemType type;
        type = (SystemType)varClass.Any;

        PropertyInfo[] propertyArrayA;
        propertyArrayA = type.GetProperties(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        MethodInfo[] methodArrayA;
        methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        Table fieldTable;
        Table maideTable;
        fieldTable = this.ClassInfra.TableCreateStringCompare();
        maideTable = this.ClassInfra.TableCreateStringCompare();

        varClass.Field = fieldTable;
        varClass.Maide = maideTable;
        
        int count;
        int i;

        count = propertyArrayA.Length;
        i = 0;
        while (i < count)
        {
            PropertyInfo property;
            property = propertyArrayA[i];

            if (!property.IsSpecialName)
            {
                MethodInfo ooo;
                ooo = null;
                if ((ooo == null) & property.CanRead)
                {
                    ooo = property.GetMethod;
                }
                if ((ooo == null) & property.CanWrite)
                {
                    ooo = property.SetMethod;
                }
                if (this.IsInAbstract(ooo) & 
                    !((type == typeof(Data)) & (property.Name == "Value")) &
                    !((type == typeof(InfraInfra)) & (property.Name == "IntCapValue")) &
                    !((type == typeof(Storage)) & (property.Name == "AnyNode"))
                    )
                {
                    if (!(property.CanWrite & property.CanRead))
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") field " + property.Name + " does not have both get and set\n");
                        global::System.Environment.Exit(109);
                    }

                    if (!(property.GetMethod.IsVirtual & property.SetMethod.IsVirtual))
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") field " + property.Name + " is not virtual\n");
                        global::System.Environment.Exit(106);
                    }

                    if (this.ClassMemberHasDefine(varClass, property.Name))
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") member name " + property.Name + " duplicate\n");
                        global::System.Environment.Exit(110);
                    }

                    if (property.PropertyType == this.InfraAnyType)
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") field " + property.Name + " is Avalon.Infra Any type\n");
                        global::System.Environment.Exit(160);
                    }

                    Info oe;
                    oe = new Info();
                    oe.Init();
                    oe.Property = property;

                    Field field;
                    field = new Field();
                    field.Init();
                    field.Name = property.Name;
                    field.Class = this.ClassGetType(property.PropertyType);
                    field.Count = this.CountGet(property.GetMethod);
                    field.Parent = varClass;
                    field.SystemInfo = this.SystemInfoCreate(property.PropertyType);
                    field.Any = oe;
                    
                    this.ListInfra.TableAdd(fieldTable, field.Name, field);
                }
            }

            i = i + 1;
        }

        count = methodArrayA.Length;
        i = 0;
        while (i < count)
        {
            MethodInfo method;
            method = methodArrayA[i];

            if (!method.IsSpecialName & this.IsInAbstract(method) & 
                !((type == typeof(EntryEntry)) & (method.Name == "ArgSet")) &
                !((type == typeof(StorageInfra)) & (
                    (method.Name == "DataReadAny") |
                    (method.Name == "DataWriteAny") |
                    (method.Name == "DataWriteRangeAny") |
                    (method.Name == "TextReadAny") |
                    (method.Name == "TextWriteAny") |
                    (method.Name == "CountSetAny")
                    ))
                )
            {
                if (!method.IsVirtual)
                {
                    global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") maide " + method.Name + " is not virtual\n");
                    global::System.Environment.Exit(107);
                }

                if (this.ClassMemberHasDefine(varClass, method.Name))
                {
                    global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") member name " + method.Name + " has define\n");
                    global::System.Environment.Exit(110);
                }

                if (method.ReturnType == this.InfraAnyType)
                {
                    global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") maide " + method.Name + " is Avalon.Infra Any type\n");
                    global::System.Environment.Exit(161);
                }

                Info of;
                of = new Info();
                of.Init();
                of.Method = method;

                Maide maide;
                maide = new Maide();
                maide.Init();
                maide.Name = method.Name;
                maide.Class = this.ClassGetType(method.ReturnType);
                maide.Count = this.CountGet(method);
                maide.Parent = varClass;
                maide.SystemInfo = this.SystemInfoCreate(method.ReturnType);
                maide.Any = of;

                Table varTable;
                varTable = this.ClassInfra.TableCreateStringCompare();

                ParameterInfo[] parameterArray;
                parameterArray = method.GetParameters();
                int countA;
                countA = parameterArray.Length;

                int iA;
                iA = 0;
                while (iA < countA)
                {
                    ParameterInfo parameter;
                    parameter = parameterArray[iA];

                    if (parameter.ParameterType == this.InfraAnyType)
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") maide " + maide.Name + 
                        " var " + parameter.Name + " is Avalon.Infra Any type\n");
                        global::System.Environment.Exit(162);
                    }

                    Info og;
                    og = new Info();
                    og.Init();
                    og.Parameter = parameter;

                    Var varVar;
                    varVar = new Var();
                    varVar.Init();
                    varVar.Name = parameter.Name;
                    varVar.Class = this.ClassGetType(parameter.ParameterType);
                    varVar.SystemInfo = this.SystemInfoCreate(parameter.ParameterType);
                    varVar.Any = og;

                    this.ListInfra.TableAdd(varTable, varVar.Name, varVar);

                    iA = iA + 1;
                }

                maide.Param = varTable;

                this.ListInfra.TableAdd(maideTable, maide.Name, maide);
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetImportList()
    {
        Table table;
        table = this.ClassInfra.TableCreateModuleRefCompare();

        this.Module.Import = table;

        Table classTable;
        classTable = this.Module.Class;

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            this.AddClassToImportTable(a.Base);


            Iter iterA;
            iterA = a.Field.IterCreate();
            a.Field.IterSet(iterA);
            while (iterA.Next())
            {
                Field field;
                field = (Field)iterA.Value;
                this.AddClassToImportTable(field.Class);
                if (!(field.Virtual == null))
                {
                    this.AddClassToImportTable(field.Virtual.Parent);
                }
            }

            iterA = a.Maide.IterCreate();
            a.Maide.IterSet(iterA);
            while (iterA.Next())
            {
                Maide maide;
                maide = (Maide)iterA.Value;
                this.AddClassToImportTable(maide.Class);
                if (!(maide.Virtual == null))
                {
                    this.AddClassToImportTable(maide.Virtual.Parent);
                }

                Table varTable;
                varTable = maide.Param;

                Iter iterAa;
                iterAa = varTable.IterCreate();
                varTable.IterSet(iterAa);
                while (iterAa.Next())
                {
                    Var varVar;
                    varVar = (Var)iterAa.Value;

                    this.AddClassToImportTable(varVar.Class);
                }
            }
        }
        return true;
    }

    protected virtual bool AddClassToImportTable(ClassClass varClass)
    {
        if (varClass.Module == this.Module)
        {
            return true;
        }

        Table table;
        table = this.Module.Import;

        ModuleRef moduleRef;
        moduleRef = varClass.Module.Ref;

        Table classTable;
        classTable = (Table)table.Get(moduleRef);
        if (classTable == null)
        {
            classTable = this.ClassInfra.TableCreateRefCompare();
            this.ListInfra.TableAdd(table, moduleRef, classTable);
        }

        if (!classTable.Valid(varClass))
        {
            this.ListInfra.TableAdd(classTable, varClass, varClass);
        }
        return true;
    }

    protected virtual bool SetVirtualList()
    {
        ClassClass boolClass;
        boolClass = null;
        ClassClass intClass;
        intClass = null;
        ClassClass stringClass;
        stringClass = null;
        if (this.IsAvalonInfra)
        {
            boolClass = this.ModuleClassGet(this.Module, "Bool");
            intClass = this.ModuleClassGet(this.Module, "Int");
            stringClass = this.ModuleClassGet(this.Module, "String");
        }
        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            if (!(this.IsAvalonInfra & (a == boolClass | a == intClass | a == stringClass)))
            {
                SystemType type;
                type = (SystemType)a.Any;

                Iter iterA;
                iterA = a.Field.IterCreate();
                a.Field.IterSet(iterA);
                while (iterA.Next())
                {
                    Field field;
                    field = (Field)iterA.Value;

                    Info aaa;
                    aaa = (Info)field.Any;

                    PropertyInfo property;
                    property = aaa.Property;

                    Field aa;
                    aa = null;
                    ClassClass ac;
                    ac = this.VirtualDefineClass(property.GetMethod);
                    if (!(ac == null))
                    {
                        aa = (Field)ac.Field.Get(field.Name);
                    }
                    
                    field.Virtual = aa;

                    // string dataName;
                    // dataName = "__D_" + field.Name;
                    // FieldInfo systemField;
                    // systemField = type.GetField(dataName, BindingFlag.Instance | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

                    // bool ad;
                    // ad = (field.Virtual == null); 
                    // if (ad)
                    // {
                    //     if (systemField == null)
                    //     {
                    //         global::System.Console.Error.Write("Class " + a.Name + "(" + a.Module.Ref.Name + ") field " + field.Name + " has no virtual and data is not defined\n");
                    //         global::System.Environment.Exit(130);
                    //     }
                    //     if (!(systemField.IsFamily))
                    //     {
                    //         global::System.Console.Error.Write("Class " + a.Name + "(" + a.Module.Ref.Name + ") field " + field.Name + " data count is not protected\n");
                    //         global::System.Environment.Exit(131);
                    //     }
                    //     if (!(systemField.FieldType == property.PropertyType))
                    //     {
                    //         global::System.Console.Error.Write("Class " + a.Name + "(" + a.Module.Ref.Name + ") field " + field.Name + " data class is not same as field class\n");
                    //         global::System.Environment.Exit(132);
                    //     }
                    // }
                    // if (!ad)
                    // {
                    //     if (!(systemField == null))
                    //     {
                    //         global::System.Console.Error.Write("Class " + a.Name + "(" + a.Module.Ref.Name + ") field " + field.Name + " has virtual and data is defined\n");
                    //         global::System.Environment.Exit(133);
                    //     }
                    // }
                }

                iterA = a.Maide.IterCreate();
                a.Maide.IterSet(iterA);
                while (iterA.Next())
                {
                    Maide maide;
                    maide = (Maide)iterA.Value;

                    Info faa;
                    faa = (Info)maide.Any;

                    MethodInfo method;
                    method = faa.Method;

                    Maide fa;
                    fa = null;
                    ClassClass fc;
                    fc = this.VirtualDefineClass(method);
                    if (!(fc == null))
                    {
                        fa = (Maide)fc.Maide.Get(maide.Name);
                    }

                    maide.Virtual = fa;
                }
            }
        }

        return true;
    }

    protected virtual bool SetEntry()
    {
        if (this.Module.Ref.Name == "Class.Console")
        {
            ClassClass a;
            a = this.ModuleClassGet(this.Module, "Entry");
            this.Module.Entry = a.Name;
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

            this.Console.Out.Write("--------------\n");
            this.Console.Out.Write(module.Ref.Name + "\n");
            this.Console.Out.Write("--------------\n");

            Table table;
            table = module.Class;
            Iter iterA;
            iterA = table.IterCreate();
            table.IterSet(iterA);
            while (iterA.Next())
            {
                ClassClass a;
                a = (ClassClass)iterA.Value;

                this.ConsoleWriteClass(a);
            }

            this.Console.Out.Write("--------\n");

            iterA = module.Import.IterCreate();
            module.Import.IterSet(iterA);

            while (iterA.Next())
            {
                ModuleRef oa;
                oa = (ModuleRef)iterA.Index;

                string oaa;
                oaa = oa.Name;

                this.Console.Out.Write(oaa + "\n");

                Table ob;
                ob = (Table)iterA.Value;

                Iter iterB;
                iterB = ob.IterCreate();
                ob.IterSet(iterB);
                while (iterB.Next())
                {
                    ClassClass aa;
                    aa = (ClassClass)iterB.Value;
                    this.Console.Out.Write("    " + aa.Name + "\n");
                }

                if (!(oaa.StartsWith("System.") | oaa.StartsWith("Class.")))
                {
                    global::System.Console.Error.Write("Import module is not System Module or Class Compiler Module\n");
                    global::System.Environment.Exit(105);
                }
            }
        }
        return true;
    }

    protected virtual bool ConsoleWriteClass(ClassClass a)
    {
        this.Console.Out.Write("Class: Name: " + a.Name + ", Base: " + a.Base.Name + "(" + a.Base.Module.Ref.Name + ")" + "\n");

        Iter iterB;
        iterB = a.Field.IterCreate();
        a.Field.IterSet(iterB);
        while (iterB.Next())
        {
            Field field;
            field = (Field)iterB.Value;
            this.Console.Out.Write("    Field: Name: " + field.Name + ", Count: " + this.CountString(field.Count.Index) + 
            ", Class: " + field.Class.Name + "(" + field.Class.Module.Ref.Name + ")" + 
            ", SystemInfo: " + field.SystemInfo.Value +
            ", Virtual: " + ((field.Virtual == null) ? "null" : (field.Virtual.Parent.Name + "(" + field.Virtual.Parent.Module.Ref.Name + ")")) +
            "\n");
        }

        iterB = a.Maide.IterCreate();
        a.Maide.IterSet(iterB);
        while (iterB.Next())
        {
            Maide maide;
            maide = (Maide)iterB.Value;
            this.Console.Out.Write("    Maide: Name: " + maide.Name + ", Count: " + this.CountString(maide.Count.Index) + 
            ", Class: " + maide.Class.Name + "(" + maide.Class.Module.Ref.Name + ")" + 
            ", SystemInfo: " + maide.SystemInfo.Value +
            ", Virtual: " + ((maide.Virtual == null) ? "null" : (maide.Virtual.Parent.Name + "(" + maide.Virtual.Parent.Module.Ref.Name + ")")) +
            "\n");

            Table varTable;
            varTable = maide.Param;
            Iter iterBa;
            iterBa = varTable.IterCreate();
            varTable.IterSet(iterBa);
            while (iterBa.Next())
            {
                Var varVar;
                varVar = (Var)iterBa.Value;
                this.Console.Out.Write("        Var: Name: " + varVar.Name + ", Class: " + varVar.Class.Name + "(" + varVar.Class.Module.Ref.Name + ")" + ", SystemInfo: " + varVar.SystemInfo.Value + "\n");
            }
        }
        return true;
    }

    protected virtual bool ExecuteBinaryWrite()
    {
        BinaryWrite write;
        write = new BinaryWrite();
        write.Init();

        Iter iter;
        iter = this.BinaryTable.IterCreate();
        this.BinaryTable.IterSet(iter);
        while (iter.Next())
        {
            Binary binary;
            binary = (Binary)iter.Value;

            write.Binary = binary;
            write.Execute();

            Data data;
            data = write.Data;
            write.Data = null;

            string name;
            name = binary.Ref.Name;

            string path;
            path = name + ".ref";

            this.StorageInfra.DataWriteAny(path, data, true);
        }
        return true;
    }

    protected virtual bool ClassMemberHasDefine(ClassClass varClass, string name)
    {
        bool ba;
        ba = varClass.Field.Valid(name);
        bool bb;
        bb = varClass.Maide.Valid(name);
        bool b;
        b = ba | bb;
        return b;
    }

    protected virtual Module ModuleGet(string name)
    {
        this.ModuleRef.Name = name;
        Module a;
        a = (Module)this.ModuleTable.Get(this.ModuleRef);
        if (a == null)
        {
            global::System.Console.Error.Write("ModuleGet no module, module: " + name + "\n");
            global::System.Environment.Exit(100);
        }
        return a;
    }

    protected virtual ClassClass ModuleClassGet(Module module, string name)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(name);
        if (a == null)
        {
            global::System.Console.Error.Write("ModuleClassGet no class, class: " + name + "(" + module.Ref.Name + ")" + "\n");
            global::System.Environment.Exit(101);
        }
        return a;
    }

    protected virtual ClassClass ClassGetType(SystemType type)
    {
        string module;
        string varClass;
        module = null;
        varClass = null;
        bool b;
        b = this.IsDotNetBuiltInType(type);
        if (b)
        {
            module = "System.Infra";
            BuiltInType oa;
            oa = (BuiltInType)this.DotNetBuiltInTypeTable.Get(type);
            varClass = oa.Name;
        }
        if (!b)
        {
            string assemblyName;
            assemblyName = type.Assembly.GetName().Name;
            if (assemblyName.StartsWith("System.") | assemblyName == "System")
            {
                global::System.Console.Error.Write("ClassGetType assemblyName is BCL assembly name: " + assemblyName + ", type name: " + type.FullName + "\n");
                global::System.Environment.Exit(140);
            }
            if (!this.TypeIsClass(type))
            {
                global::System.Console.Error.Write("ClassGetType type is not C# class: " + type.Name + "\n");
                global::System.Environment.Exit(142);
            }
            module = this.ClassModuleName(assemblyName);
            varClass = type.Name;
        }
        ClassClass a;
        a = this.ClassGet(module, varClass);
        return a;
    }

    protected virtual bool TypeIsClass(SystemType type)
    {
        if (!type.IsClass)
        {
            return false;
        }

        if (typeof(Delegate).IsAssignableFrom(type))
        {
            return false;
        }

        return true;
    }

    protected virtual ClassClass ClassGet(string moduleName, string className)
    {
        Module o;
        o = this.ModuleGet(moduleName);
        ClassClass oa;
        oa = this.ModuleClassGet(o, className);
        return oa;
    }

    protected virtual bool ClassPartSetNameZ(string name, SystemType zType)
    {
        ClassClass a;
        a = this.ModuleClassGet(this.Module, name);
        this.ClassPartSetZ(a, zType);
        return true;
    }

    protected virtual bool ClassPartSetZ(ClassClass varClass, SystemType type)
    {
        MethodInfo[] methodArrayA;
        methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

        int count;
        int i;
        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringCompare();

        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringCompare();

        count = methodArrayA.Length;
        i = 0;
        while (i < count)
        {
            MethodInfo method;
            method = methodArrayA[i];

            if (!method.IsSpecialName)
            {
                string name;
                name = method.Name;

                if (name.StartsWith("G_") | name.StartsWith("C_"))
                {
                    bool isMaide;
                    isMaide = name.StartsWith("C_");
                    string compName;
                    compName = name.Substring(2);

                    ParameterInfo[] parameterArray;
                    parameterArray = method.GetParameters();
                    int countA;
                    countA = parameterArray.Length;

                    if (countA < 1)
                    {
                        global::System.Console.Error.Write("Class " + varClass.Name + "(" + varClass.Module.Ref.Name + ") Z method " + method.Name + " has no parameter\n");
                        global::System.Environment.Exit(111);
                    }

                    SystemInfo ae;
                    ae = this.SystemInfoCreate(method.ReturnType);

                    if (!isMaide)
                    {
                        Field field;
                        field = new Field();
                        field.Init();
                        field.Name = compName;
                        field.Class = this.ClassGetType(method.ReturnType);
                        field.Count = this.CountGet(method);
                        field.Parent = varClass;
                        field.SystemInfo = ae;

                        this.ListInfra.TableAdd(fieldTable, field.Name, field);
                    }

                    if (isMaide)
                    {
                        Maide maide;
                        maide = new Maide();
                        maide.Init();
                        maide.Name = compName;
                        maide.Class = this.ClassGetType(method.ReturnType);
                        maide.Count = this.CountGet(method);
                        maide.Parent = varClass;
                        maide.SystemInfo = ae;

                        Table varTable;
                        varTable = this.ClassInfra.TableCreateStringCompare();

                        countA = countA - 1;
                        
                        int iA;
                        iA = 0;
                        while (iA < countA)
                        {
                            ParameterInfo parameter;
                            parameter = parameterArray[1 + iA];

                            SystemInfo af;
                            af = this.SystemInfoCreate(parameter.ParameterType);

                            Var varVar;
                            varVar = new Var();
                            varVar.Init();
                            varVar.Name = parameter.Name;
                            varVar.Class = this.ClassGetType(parameter.ParameterType);
                            varVar.SystemInfo = af;

                            this.ListInfra.TableAdd(varTable, varVar.Name, varVar);

                            iA = iA + 1;
                        }

                        maide.Param = varTable;

                        this.ListInfra.TableAdd(maideTable, maide.Name, maide);
                    }
                }
            }

            i = i + 1;
        }

        varClass.Field = fieldTable;
        varClass.Maide = maideTable;
        return true;
    }

    protected virtual bool ClassBaseSetAny(string name)
    {
        ClassClass a;
        a = this.ModuleClassGet(this.Module, name);
        a.Base = this.AnyClass;
        return true;
    }

    protected virtual bool ClassPartSetEmpty(string name)
    {
        ClassClass a;
        a = this.ModuleClassGet(this.Module, name);
        a.Field = this.ClassInfra.TableCreateStringCompare();
        a.Maide = this.ClassInfra.TableCreateStringCompare();
        return true;
    }

    protected virtual bool AddInfraBuiltInClassList()
    {
        this.AddClassWithName("Bool");
        this.AddClassWithName("Int");
        this.AddClassWithName("String");
        return true;
    }

    protected virtual bool AddClassWithName(string name)
    {
        int index;
        index = this.Module.Class.Count;

        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Index = index;
        a.Name = name;
        a.Module = this.Module;

        this.ListInfra.TableAdd(this.Module.Class, a.Name, a);
        return true;
    }

    protected virtual SystemType AnyTypeGet(SystemType[] typeArray)
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

    protected virtual SystemInfo SystemInfoCreate(SystemType type)
    {
        SystemInfo a;
        a = new SystemInfo();
        a.Init();

        BuiltInType f;
        f = this.BuitInTypeGet(type);
        if (!(f == null))
        {
            a.Value = f.SystemInfo;
        }
        return a;
    }

    protected virtual string ClassModuleName(string assemblyName)
    {
        string oe;
        oe = "Avalon.";

        if (assemblyName.StartsWith(oe))
        {
            string of;
            of = assemblyName.Substring(oe.Length);

            string a;
            a = "System." + of;
            return a;
        }

        return assemblyName;
    }

    protected virtual ClassClass VirtualDefineClass(MethodInfo method)
    {
        MethodInfo ua;
        ua = method.GetBaseDefinition();

        if (method.Equals(ua))
        {
            return null;
        }

        SystemType u;
        u = ua.DeclaringType;        
        ClassClass a;
        a = this.ClassGetType(u);
        return a;
    }

    protected virtual BuiltInType BuitInTypeGet(SystemType type)
    {
        BuiltInType a;
        a = (BuiltInType)this.DotNetBuiltInTypeTable.Get(type);
        return a;
    }

    protected virtual bool AddDotNetBuiltInType(SystemType type, string name)
    {
        int systemClass;
        systemClass = this.DotNetBuiltInTypeTable.Count + 1;
        BuiltInType a;
        a = new BuiltInType();
        a.Init();
        a.Type = type;
        a.Name = name;
        a.SystemInfo = systemClass;
        this.ListInfra.TableAdd(this.DotNetBuiltInTypeTable, type, a);
        return true;
    }

    protected virtual bool IsDotNetBuiltInType(SystemType type)
    {
        return this.DotNetBuiltInTypeTable.Valid(type);
    }

    protected virtual Count CountGet(MethodInfo method)
    {
        Count a;
        a = null;
        if (method.IsPublic)
        {
            a = this.CountList.Prudate;
        }
        if (method.IsAssembly)
        {
            a = this.CountList.Probate;
        }
        if (method.IsFamily)
        {
            a = this.CountList.Precate;
        }
        if (method.IsPrivate)
        {
            a = this.CountList.Private;
        }
        return a;
    }

    protected virtual string CountString(int value)
    {
        return (string)this.CountArray.GetAt(value);
    }

    protected virtual bool SetCountString(string o)
    {
        this.ArraySetItem(o);
        return true;
    }

    protected virtual bool ArrayContainItem(Array array, object value)
    {
        int count;
        count = array.Count;

        int i;
        i = 0;
        while (i < count)
        {
            if (array.GetAt(i) == value)
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    protected virtual bool ArraySetItem(object value)
    {
        int index;
        index = this.Index;
        this.Array.SetAt(index, value);
        index = index + 1;
        this.Index = index;
        return true;
    }

    protected virtual bool IsInAbstract(MethodInfo method)
    {
        return method.IsPublic | method.IsFamily;
    }
}