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
    public virtual ReferRefer Refer { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    public virtual bool Execute()
    {
        ModuleRef o;
        o = this.Refer.Ref;
        if (this.ModuleTable.Contain(o))
        {
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ModuleRefCreate(o.Name, o.Ver);
        this.Module = a;

        this.AddClassList();

        return true;
    }

    protected virtual bool AddClassList()
    {
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
            a.Index = this.Module.Class.Count;
            a.Name = name;
            a.Module = this.Module;

            this.ListInfra.TableAdd(this.Module.Class, a.Name, a); 

            i = i + 1;
        }
        return true;
    }
    
    protected virtual bool AddImportList()
    {
        Array array;
        array = this.Refer.Import;

        Table importTable;
        importTable = new Table();
        importTable.Compare = new ModuleRefCompare();
        importTable.Compare.Init();
        importTable.Init();

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

            ClassModule module;
            module = this.ModuleGet(moduleRef);

            ReferRefer oo;
            oo = (ReferRefer)this.ReferTable.Get(moduleRef);

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
            i = i + 1;
        }

        this.Module.Import = importTable;
        return true;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(moduleRef);
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, string className)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(className);
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