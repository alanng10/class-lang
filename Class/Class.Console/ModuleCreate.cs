namespace Class.Console;

public class ModuleCreate : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table ReferTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
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

        Table aa;
        aa = new Table();
        aa.Compare = new StringCompare();
        aa.Compare.Init();
        aa.Init();

        a.Class = aa;

        Table ab;
        ab = new Table();
        ab.Compare = new ModuleRefCompare();
        ab.Compare.Init();
        ab.Init();

        a.Import = ab;

        this.Module = a;

        ReferRefer refer;
        refer = (ReferRefer)this.ReferTable.Get(this.Module.Ref);
        this.Refer = refer;

        this.AddClassList();

        this.AddImportList();

        this.AddBaseList();

        this.Refer = null;
        this.ClassArray = null;
        this.ImportArray = null;

        return true;
    }

    protected virtual bool AddClassList()
    {
        Table classTable;
        classTable = this.Module.Class;

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
    
    protected virtual bool AddImportList()
    {
        Table importTable;
        importTable = this.Module.Import;
        
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

    protected virtual bool AddBaseList()
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