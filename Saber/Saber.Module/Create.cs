namespace Saber.Module;

public class Create : ClassCreate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.Count = CountList.This;
        this.ErrorKind = ErrorKindList.This;

        this.System = this.CreateSystem();
        this.NullClass = this.CreateNullClass();
        this.InitTravel = this.CreateInitTravel();
        this.ClassTravel = this.CreateClassTravel();
        this.CompTravel = this.CreateCompTravel();
        this.StateTravel = this.CreateStateTravel();
        this.ModuleRef = this.CreateModuleRef();

        this.SSystemInfra = this.S("System.Infra");
        this.SAny = this.S("Any");
        this.SBool = this.S("Bool");
        this.SInt = this.S("Int");
        this.SString = this.S("String");
        return true;
    }

    protected virtual System CreateSystem()
    {
        System a;
        a = new System();
        a.Init();
        return a;
    }

    protected virtual ClassClass CreateNullClass()
    {
        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Name = this.S("_");
        return a;
    }

    protected virtual InitTravel CreateInitTravel()
    {
        InitTravel a;
        a = new InitTravel();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual ClassTravel CreateClassTravel()
    {
        ClassTravel a;
        a = new ClassTravel();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual CompTravel CreateCompTravel()
    {
        CompTravel a;
        a = new CompTravel();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual StateTravel CreateStateTravel()
    {
        StateTravel a;
        a = new StateTravel();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual ModuleRef CreateModuleRef()
    {
        return this.ClassInfra.ModuleRefCreate(null, 0);
    }

    public virtual Array Source { get; set; }
    public virtual Array RootNode { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual Result Result { get; set; }
    public virtual long SourceIndex { get; set; }
    public virtual System System { get; set; }
    public virtual ClassClass NullClass { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList Count { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual InitTravel InitTravel { get; set; }
    protected virtual ClassTravel ClassTravel { get; set; }
    protected virtual CompTravel CompTravel { get; set; }
    protected virtual StateTravel StateTravel { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual Table BaseTable { get; set; }
    protected virtual Table RangeTable { get; set; }
    protected virtual Table ClassVirtualTable { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual bool SystemInfra { get; set; }
    protected virtual String SSystemInfra { get; set; }
    protected virtual String SAny { get; set; }
    protected virtual String SBool { get; set; }
    protected virtual String SInt { get; set; }
    protected virtual String SString { get; set; }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.ErrorList = new List();
        this.ErrorList.Init();

        this.SystemInfra = this.ModuleSystemInfra();

        this.ExecuteInit();
        this.ExecuteClass();
        this.ExecuteBase();
        this.ExecuteComp();
        this.ExecuteVirtual();
        this.ExecuteExport();
        this.ExecuteEntry();
        this.ExecuteState();

        this.Result.Module = this.Module;
        this.Result.Error = this.ListInfra.ArrayCreateList(this.ErrorList);
        this.ErrorList = null;
        return true;
    }

    protected virtual bool SystemSet()
    {
        ClassModule k;
        k = null;

        if (this.SystemInfra)
        {
            k = this.Module;
        }
        if (!this.SystemInfra)
        {
            k = this.ModuleGet(this.SSystemInfra);
        }

        this.System.Any = this.ModuleClassGet(k, this.SAny);
        this.System.Bool = this.ModuleClassGet(k, this.SBool);
        this.System.Int = this.ModuleClassGet(k, this.SInt);
        this.System.String = this.ModuleClassGet(k, this.SString);
        return true;
    }

    protected virtual ClassModule ModuleGet(String moduleName)
    {
        this.ModuleRef.Name = moduleName;

        ClassModule a;
        a = this.ModuleTable.Get(this.ModuleRef) as ClassModule;
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, String className)
    {
        return module.Class.Get(className) as ClassClass;
    }

    protected virtual bool ModuleSystemInfra()
    {
        return this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemInfra));
    }

    protected virtual bool ExecuteInit()
    {
        this.ExecuteTravel(this.InitTravel);
        return true;
    }

    protected virtual bool ExecuteClass()
    {
        this.ExecuteTravel(this.ClassTravel);

        this.SystemSet();
        return true;
    }

    protected virtual bool ExecuteBase()
    {
        this.SetBaseTable();

        this.AddBaseList();

        this.BaseTable = null;

        this.BaseCountSet();
        return true;
    }

    protected virtual bool BaseCountSet()
    {
        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass k;
            k = iter.Value as ClassClass;

            long ka;
            ka = this.ClassInfra.BaseCount(k, this.System.Any);

            k.BaseCount = ka;
        }

        return true;
    }

    protected virtual bool SetBaseTable()
    {
        this.BaseTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;
            this.BaseMapAdd(varClass);
        }
        return true;
    }

    protected virtual bool BaseMapAdd(ClassClass varClass)
    {
        NodeClass nodeClass;
        nodeClass = (NodeClass)varClass.Any;

        ClassName nodeBase;
        nodeBase = nodeClass.Base;

        String baseName;
        baseName = null;
        if (!(nodeBase == null))
        {
            baseName = nodeBase.Value;
        }

        ClassClass varBase;
        varBase = null;
        if (!(baseName == null))
        {
            varBase = this.Class(baseName);
        }

        bool b;
        b = false;

        bool ba;
        ba = (varBase == null);
        if (ba)
        {
            this.Error(this.ErrorKind.BaseUndefine, nodeClass, varClass.Index);
            b = true;
        }

        if (!ba)
        {
            if (!this.ValidBase(varBase))
            {
                this.Error(this.ErrorKind.BaseUndefine, nodeClass, varClass.Index);
                b = true;
            }
        }

        ClassClass a;
        a = varBase;

        if (b)
        {
            a = this.System.Any;
        }

        this.ListInfra.TableAdd(this.BaseTable, varClass, a);
        return true;
    }

    protected virtual bool ValidBase(ClassClass varClass)
    {
        System k;
        k = this.System;

        if (varClass == k.Bool | varClass == k.Int | varClass == k.String)
        {
            return false;
        }
        return true;
    }

    protected virtual bool AddBaseList()
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        Iter iter;
        iter = this.BaseTable.IterCreate();
        this.BaseTable.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Index as ClassClass;

            bool b;
            b = false;

            bool ba;
            ba = (varClass == anyClass);

            if (ba)
            {
                b = true;
            }

            if (!ba)
            {
                b = this.ValidClassDepend(varClass);
            }

            ClassClass a;
            a = null;

            if (!b)
            {
                NodeClass nodeClass;
                nodeClass = varClass.Any as NodeClass;

                this.Error(this.ErrorKind.BaseUndefine, nodeClass, varClass.Index);

                a = anyClass;
            }
            if (b)
            {
                a = iter.Value as ClassClass;
            }
            varClass.Base = a;
        }
        return true;
    }

    protected virtual bool ValidClassDepend(ClassClass varClass)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassModule module;
        module = this.Module;

        Table baseTable;
        baseTable = this.BaseTable;

        ClassClass anyClass;
        anyClass = this.System.Any;

        Table table;
        table = this.ClassInfra.TableCreateRefLess();

        ClassClass a;
        a = varClass;

        while (!(a == null))
        {
            if (!(a.Module == module))
            {
                return true;
            }

            if (table.Valid(a))
            {
                return false;
            }

            listInfra.TableAdd(table, a, a);

            ClassClass ka;
            ka = null;
            if (!(a == anyClass))
            {
                ka = baseTable.Get(a) as ClassClass;
            }
            a = ka;
        }
        return true;
    }

    protected virtual bool ExecuteComp()
    {
        this.ExecuteTravel(this.CompTravel);
        return true;
    }

    protected virtual bool ExecuteVirtual()
    {
        this.ClassVirtualSet();

        this.ClassRangeSet();
        return true;
    }

    protected virtual bool ClassVirtualSet()
    {
        Table table;
        table = this.Module.Class;

        this.ClassVirtualTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            this.ClassVirtualSetClass(a);
        }

        this.ClassVirtualTable = null;

        return true;
    }

    protected virtual bool ClassVirtualSetClass(ClassClass varClass)
    {
        Table k;
        k = this.ClassVirtualTable;

        if (k.Valid(varClass))
        {
            return true;
        }

        if (!(varClass.Module == this.Module))
        {
            return true;
        }

        bool b;
        b = (varClass == this.System.Any);

        if (b)
        {
            this.ClassVirtualSetClassComp(varClass);
        }
        if (!b)
        {
            ClassClass baseClass;
            baseClass = varClass.Base;

            this.ClassVirtualSetClass(baseClass);

            this.ClassVirtualSetClassComp(varClass);
        }

        this.ListInfra.TableAdd(k, varClass, varClass);

        return true;
    }

    protected virtual bool ClassVirtualSetClassComp(ClassClass varClass)
    {
        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringLess();

        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringLess();

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);
        while (iter.Next())
        {
            Field field;
            field = (Field)iter.Value;

            bool ba;
            ba = this.VirtualField(field);

            NodeField node;
            node = (NodeField)field.Any;

            if (!ba)
            {
                this.Error(this.ErrorKind.FieldUndefine, node, varClass.Index);
            }

            if (ba)
            {
                field.Index = fieldTable.Count;

                this.Info(node).Field = field;

                this.ListInfra.TableAdd(fieldTable, field.Name, field);
            }
        }

        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);
        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;

            bool bb;
            bb = this.VirtualMaide(maide);

            NodeMaide node;
            node = (NodeMaide)maide.Any;

            if (!bb)
            {
                this.Error(this.ErrorKind.MaideUndefine, node, varClass.Index);
            }

            if (bb)
            {
                maide.Index = maideTable.Count;

                this.Info(node).Maide = maide;

                this.ListInfra.TableAdd(maideTable, maide.Name, maide);
            }
        }

        varClass.Field = fieldTable;
        varClass.Maide = maideTable;
        return true;
    }

    public virtual Info Info(NodeNode node)
    {
        return node.NodeAny as Info;
    }

    protected virtual bool ClassRangeSet()
    {
        Table table;
        table = this.Module.Class;

        this.RangeTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = iter.Value as ClassClass;

            this.ClassRangeSetClass(a);
        }

        this.RangeTable = null;
        return true;
    }

    protected virtual bool ClassRangeSetClass(ClassClass varClass)
    {
        Table k;
        k = this.RangeTable;

        if (k.Valid(varClass))
        {
            return true;
        }

        if (!(varClass.Module == this.Module))
        {
            return true;
        }

        bool b;
        b = (varClass == this.System.Any);

        if (b)
        {
            varClass.FieldStart = 0;

            varClass.MaideStart = 0;
        }
        if (!b)
        {
            ClassClass baseClass;
            baseClass = varClass.Base;

            this.ClassRangeSetClass(baseClass);

            varClass.FieldStart = baseClass.FieldStart + baseClass.Field.Count;

            varClass.MaideStart = baseClass.MaideStart + baseClass.Maide.Count;
        }

        this.ListInfra.TableAdd(k, varClass, varClass);

        return true;
    }

    public virtual bool VirtualField(Field a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        if (varClass == this.System.Any)
        {
            return true;
        }

        object ka;
        ka = this.CompDefine(varClass.Base, a.Name);

        if (ka == null)
        {
            return true;
        }

        Maide kb;
        kb = ka as Maide;
        if (!(kb == null))
        {
            return false;
        }

        Field k;
        k = ka as Field;

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Field h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    public virtual bool VirtualMaide(Maide a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        if (varClass == this.System.Any)
        {
            return true;
        }

        object ka;
        ka = this.CompDefine(varClass.Base, a.Name);

        if (ka == null)
        {
            return true;
        }

        Field kb;
        kb = ka as Field;
        if (!(kb == null))
        {
            return false;
        }

        Maide k;
        k = ka as Maide;

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!this.VarSameClass(a.Param, k.Param))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Maide h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    protected virtual bool VarSameClass(Table varA, Table varB)
    {
        if (!(varA.Count == varB.Count))
        {
            return false;
        }

        Iter iterA;
        iterA = varA.IterCreate();
        varA.IterSet(iterA);

        Iter iterB;
        iterB = varB.IterCreate();
        varB.IterSet(iterB);

        long count;
        count = varA.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iterA.Next();
            iterB.Next();

            Var ka;
            Var kb;
            ka = iterA.Value as Var;
            kb = iterB.Value as Var;

            bool b;
            b = (ka.Class == kb.Class);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteState()
    {
        this.ExecuteTravel(this.StateTravel);
        return true;
    }

    protected virtual bool ExecuteExport()
    {
        List list;
        list = new List();
        list.Init();

        ClassModule module;
        module = this.Module;
        Table table;
        table = module.Export;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            String name;
            name = iter.Index as String;

            ClassClass varClass;
            varClass = this.ModuleClassGet(module, name);

            bool b;
            b = (varClass == null);
            if (b)
            {
                this.ErrorModule(this.ErrorKind.ExportUndefine, name);
            }
            if (!b)
            {
                this.ValidExport(varClass);

                list.Add(varClass);
            }
        }

        iter = list.IterCreate();
        list.IterSet(iter);
        while (iter.Next())
        {
            ClassClass d;
            d = iter.Value as ClassClass;
            table.Set(d.Name, d);
        }
        return true;
    }

    protected virtual bool ValidExport(ClassClass varClass)
    {
        if (!this.ValidIsExport(varClass.Base))
        {
            NodeClass aa;
            aa = varClass.Any as NodeClass;
            this.Error(this.ErrorKind.ClassUnexport, aa, varClass.Index);
        }

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);
        while (iter.Next())
        {
            Field field;
            field = iter.Value as Field;
            if (this.CountExport(field.Count))
            {
                if (!this.ValidIsExport(field.Class))
                {
                    NodeField ab;
                    ab = field.Any as NodeField;
                    this.Error(this.ErrorKind.FieldUnexport, ab, varClass.Index);
                }
            }
        }

        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);
        while (iter.Next())
        {
            Maide maide;
            maide = iter.Value as Maide;
            if (this.CountExport(maide.Count))
            {
                bool b;
                b = false;
                if (!this.ValidIsExport(maide.Class))
                {
                    b = true;
                }
                if (!b)
                {
                    Iter iterA;
                    iterA = maide.Param.IterCreate();
                    maide.Param.IterSet(iterA);
                    while (!b & iterA.Next())
                    {
                        Var varVar;
                        varVar = iterA.Value as Var;
                        if (!this.ValidIsExport(varVar.Class))
                        {
                            b = true;
                        }
                    }
                }
                if (b)
                {
                    NodeMaide ac;
                    ac = maide.Any as NodeMaide;
                    this.Error(this.ErrorKind.MaideUnexport, ac, varClass.Index);
                }
            }
        }
        return true;
    }

    protected virtual bool CountExport(Count count)
    {
        if (count == this.Count.Prusate | count == this.Count.Precate)
        {
            return true;
        }
        return false;
    }

    protected virtual bool ValidIsExport(ClassClass varClass)
    {
        ClassModule module;
        module = this.Module;

        if (!(varClass.Module == module))
        {
            return true;
        }

        bool a;
        a = module.Export.Valid(varClass.Name);
        return a;
    }

    protected virtual bool ExecuteEntry()
    {
        ClassModule module;
        module = this.Module;

        String entry;
        entry = module.Entry;
        if (entry == null)
        {
            return true;
        }

        ClassClass varClass;
        varClass = this.ModuleClassGet(module, entry);
        if (varClass == null)
        {
            this.ErrorModule(this.ErrorKind.EntryUndefine, null);
            return true;
        }


        bool b;
        b = false;

        ClassModule h;
        h = null;
        ClassClass entryClass;
        entryClass = null;

        if (!b)
        {
            h = this.ModuleGet(this.S("System.Entry"));

            if (h == null)
            {
                b = true;
            }            
        }

        if (!b)
        {
            entryClass = this.ModuleClassGet(h, this.S("Entry"));

            if (entryClass == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(this.ClassInfra.ValidClass(varClass, entryClass, this.System.Any, this.NullClass)))
            {
                b = true;
            }
        }

        if (b)
        {
            NodeClass k;
            k = varClass.Any as NodeClass;
            this.Error(this.ErrorKind.EntryUnachieve, k, varClass.Index);
        }
        return true;
    }

    protected virtual bool ExecuteTravel(Travel travel)
    {
        long count;
        count = this.Source.Count;
        long i;
        i = 0;
        while (i < count)
        {
            NodeNode root;
            root = this.RootNode.GetAt(i) as NodeNode;

            NodeClass nodeClass;
            nodeClass = root as NodeClass;

            this.SourceIndex = i;

            travel.ExecuteClass(nodeClass);

            i = i + 1;
        }
        return true;
    }

    public virtual ClassClass Class(String name)
    {
        ClassClass a;
        a = this.ImportClass.Get(name) as ClassClass;
        if (!(a == null))
        {
            return a;
        }
        
        a = this.Module.Class.Get(name) as ClassClass;
        return a;
    }

    public virtual bool MemberNameDefine(ClassClass varClass, String name)
    {
        bool ba;
        ba = varClass.Field.Valid(name);
        bool bb;
        bb = varClass.Maide.Valid(name);

        bool a;
        a = ba | bb;
        return a;
    }

    protected virtual object CompDefine(ClassClass varClass, String name)
    {
        return this.ClassInfra.CompDefine(varClass, name, this.Module, this.System.Any);
    }

    public virtual bool Error(ErrorKind kind, NodeNode node, long source)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Stage = this.Stage;
        a.Kind = kind;
        a.Range = node.Range;
        a.Source = source;

        this.ErrorList.Add(a);
        return true;
    }

    public virtual bool ErrorModule(ErrorKind kind, String name)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Stage = this.Stage;
        a.Kind = kind;
        a.Name = name;
        a.Source = -1;

        this.ErrorList.Add(a);
        return true;
    }
}