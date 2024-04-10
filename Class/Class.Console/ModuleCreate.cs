namespace Class.Console;

public class ModuleCreate : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.CountList = CountList.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table ReferTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual ReferRefer Refer { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }

    public virtual bool Execute()
    {
        ModuleRef o;
        o = this.ModuleRef;
        if (this.ModuleTable.Contain(o))
        {
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ModuleRefCreate(o.Name, o.Ver);

        this.Module = a;

        ReferRefer refer;
        refer = (ReferRefer)this.ReferTable.Get(this.Module.Ref);
        this.Refer = refer;

        this.SetClassList();

        this.SetImportList();

        this.SetBaseList();

        this.SetPartList();

        this.Refer = null;
        this.ClassArray = null;
        this.ImportArray = null;

        return true;
    }

    protected virtual bool SetClassList()
    {
        Table classTable;
        classTable = this.TableCreateStringCompare();
        
        this.Module.Class = classTable;

        Array array;
        array = this.Refer.Class;
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ReferClass o;
            o = (ReferClass)array.Get(i);

            string name;
            name = o.Name;

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Index = classTable.Count;
            a.Name = name;
            a.Module = this.Module;

            this.ListInfra.TableAdd(classTable, a.Name, a); 

            i = i + 1;
        }

        Array classArray;
        classArray = this.ListInfra.ArrayCreate(classTable.Count);

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        count = classArray.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            classArray.Set(i, oa);
            i = i + 1;
        }

        this.ClassArray = classArray;
        return true;
    }
    
    protected virtual bool SetImportList()
    {
        Table importTable;
        importTable = new Table();
        importTable.Compare = new ModuleRefCompare();
        importTable.Compare.Init();
        importTable.Init();

        this.Module.Import = importTable;
        
        int importTotal;
        importTotal = 0;

        Array array;
        array = this.Refer.Import;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ReferImport o;
            o = (ReferImport)array.Get(i);

            ModuleRef moduleRef;
            moduleRef = o.Module;

            if (importTable.Contain(moduleRef))
            {
                global::System.Console.Error.Write("Class.Console:ModuleCreate.AddImportList import module ref duplicate\n");
                global::System.Environment.Exit(120);
            }

            Table ol;
            ol = new Table();
            ol.Compare = new StringCompare();
            ol.Compare.Init();
            ol.Init();
            this.ListInfra.TableAdd(importTable, moduleRef, ol);
            
            Table classTable;
            classTable = (Table)importTable.Get(moduleRef);

            ClassModule module;
            module = this.ModuleGet(moduleRef);

            ReferRefer oo;
            oo = (ReferRefer)this.ReferTable.Get(moduleRef);

            Array oa;
            oa = o.Class;
            int countA;
            countA = oa.Count;
            int iA;
            iA = 0;
            while (iA < countA)
            {
                ReferClassIndex oe;
                oe = (ReferClassIndex)oa.Get(iA);

                ReferClass of;
                of = (ReferClass)oo.Class.Get(oe.Value);

                string className;
                className = of.Name;

                ClassClass varClass;
                varClass = this.ModuleClassGet(module, className);

                if (classTable.Contain(className))
                {
                    global::System.Console.Error.Write("Class.Console:ModuleCreate.AddImportList import class name duplicate\n");
                    global::System.Environment.Exit(121);
                }

                this.ListInfra.TableAdd(classTable, className, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = this.ListInfra.ArrayCreate(importTotal);

        int oi;
        oi = 0;
        Iter iter;
        iter = importTable.IterCreate();
        importTable.IterSet(iter);
        while (iter.Next())
        {
            Table ooo;
            ooo = (Table)iter.Value;

            Iter iterA;
            iterA = ooo.IterCreate();
            ooo.IterSet(iterA);
            while(iterA.Next())
            {
                ClassClass ooa;
                ooa = (ClassClass)iterA.Value;

                importArray.Set(oi, ooa);

                oi = oi + 1;
            }
        }

        this.ImportArray = importArray;
        return true;
    }

    protected virtual bool SetBaseList()
    {
        Array array;
        array = this.Refer.Base;

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

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            ReferClassIndex a;
            a = (ReferClassIndex)array.Get(i);

            ClassClass baseClass;
            baseClass = this.ClassGetIndex(a.Value);

            varClass.Base = baseClass;            

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartList()
    {
        Array array;
        array = this.Refer.Part;

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

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            ReferPart a;
            a = (ReferPart)array.Get(i);

            this.SetPart(varClass, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPart(ClassClass varClass, ReferPart part)
    {
        this.SetPartField(varClass, part.Field);
        this.SetPartMaide(varClass, part.Maide);
        return true;
    }

    protected virtual bool SetPartField(ClassClass varClass, Array referField)
    {
        Table fieldTable;
        fieldTable = this.TableCreateStringCompare();
        varClass.Field = fieldTable;

        int count;
        count = referField.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ReferField ua;
            ua = (ReferField)referField.Get(i);

            Field a;
            a = new Field();
            a.Init();
            a.Index = fieldTable.Count;
            a.Name = ua.Name;
            a.Class = this.ClassGetIndex(ua.Class);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            this.ListInfra.TableAdd(fieldTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array referMaide)
    {
        Table maideTable;
        maideTable = this.TableCreateStringCompare();
        varClass.Maide = maideTable;

        int count;
        count = referMaide.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ReferMaide ua;
            ua = (ReferMaide)referMaide.Get(i);

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = maideTable.Count;
            a.Name = ua.Name;
            a.Class = this.ClassGetIndex(ua.Class);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            this.ListInfra.TableAdd(maideTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual ClassClass ClassGetIndex(int index)
    {
        Array classArray;
        classArray = this.ClassArray;

        ClassClass a;
        a = null;
        bool b;
        b = (index < classArray.Count);
        if (b)
        {
            a = (ClassClass)classArray.Get(index);
        }
        if (!b)
        {
            int oa;
            oa = index - classArray.Count;
            a = (ClassClass)this.ImportArray.Get(oa);
        }

        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ClassGetIndex class none, index: " + index + "\n");
            global::System.Environment.Exit(125);
        }
        return a;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(moduleRef);
        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ModuleGet module not found, module: " + moduleRef.Name + "\n");
            global::System.Environment.Exit(122);
        }
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, string className)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(className);
        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ModuleClassGet module class not found, class: " + className + ", module: " + module.Ref.Name + "\n");
            global::System.Environment.Exit(123);
        }
        return a;
    }

    protected virtual ClassClass ClassGet(ModuleRef moduleRef, string className)
    {
        ClassModule ae;
        ae = this.ModuleGet(moduleRef);
        ClassClass a;
        a = this.ModuleClassGet(ae, className);
        return a;
    }

    protected virtual Table TableCreateStringCompare()
    {
        Table a;
        a = new Table();
        a.Compare = new StringCompare();
        a.Compare.Init();
        a.Init();
        return a;
    }

    protected virtual ModuleRef ModuleRefCreate(string name, long ver)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Ver = ver;
        return a;
    }
}