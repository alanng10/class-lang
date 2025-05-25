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

        this.SourceIndex = -1;

        this.SSystemInfra = this.S("System.Infra");
        this.SAny = this.S("Any");
        this.SBool = this.S("Bool");
        this.SInt = this.S("Int");
        this.SString = this.S("String");
        this.SSystemEntry = this.S("System.Entry");
        this.SEntry = this.S("Entry");
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
    protected virtual String SSystemEntry { get; set; }
    protected virtual String SEntry { get; set; }

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
        this.BaseTableSet();

        this.BaseClassSet();

        this.BaseTable = null;

        this.BaseCountSet();
        return true;
    }

    protected virtual bool BaseTableSet()
    {
        this.BaseTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;
            this.BaseTableAdd(varClass);
        }
        return true;
    }

    protected virtual bool BaseTableAdd(ClassClass varClass)
    {
        NodeClass nodeClass;
        nodeClass = varClass.Any as NodeClass;

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
            if (!this.BaseValidClass(varBase))
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

    protected virtual bool BaseValidClass(ClassClass varClass)
    {
        System k;
        k = this.System;

        if (varClass == k.Bool | varClass == k.Int | varClass == k.String)
        {
            return false;
        }
        return true;
    }

    protected virtual bool BaseClassSet()
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
                b = this.ValidBaseDepend(varClass);
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

    protected virtual bool ValidBaseDepend(ClassClass varClass)
    {
        Table table;
        table = this.ClassInfra.TableCreateRefLess();

        ClassClass a;
        a = varClass;

        while (!(a == null))
        {
            if (!(a.Module == this.Module))
            {
                return true;
            }

            if (table.Valid(a))
            {
                return false;
            }

            this.ListInfra.TableAdd(table, a, a);

            ClassClass ka;
            ka = null;
            if (!(a == this.System.Any))
            {
                ka = this.BaseTable.Get(a) as ClassClass;
            }
            a = ka;
        }

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
            a = iter.Value as ClassClass;

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

        if (!b)
        {
            ClassClass baseClass;
            baseClass = varClass.Base;

            this.ClassVirtualSetClass(baseClass);
        }

        this.ClassVirtualSetClassComp(varClass);

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
            field = iter.Value as Field;

            bool ba;
            ba = this.ClassInfra.VirtualField(field, this.System.Any);

            NodeField node;
            node = field.Any as NodeField;

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

        Iter iterA;
        iterA = new TableIter();
        iterA.Init();

        Iter iterB;
        iterB = new TableIter();
        iterB.Init();

        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);
        while (iter.Next())
        {
            Maide maide;
            maide = iter.Value as Maide;

            bool bb;
            bb = this.ClassInfra.VirtualMaide(maide, this.System.Any, iterA, iterB);

            NodeMaide node;
            node = maide.Any as NodeMaide;

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
        if (this.RangeTable.Valid(varClass))
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

        this.ListInfra.TableAdd(this.RangeTable, varClass, varClass);

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

        Table table;
        table = this.Module.Export;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            String name;
            name = iter.Index as String;

            ClassClass varClass;
            varClass = this.ModuleClassGet(this.Module, name);

            bool b;
            b = (varClass == null);
            if (b)
            {
                this.ErrorModule(this.ErrorKind.ExportUndefine, name);
            }
            if (!b)
            {
                this.ExportValidSet(varClass);

                list.Add(varClass);
            }
        }

        iter = list.IterCreate();
        list.IterSet(iter);
        while (iter.Next())
        {
            ClassClass kk;
            kk = iter.Value as ClassClass;

            table.Set(kk.Name, kk);
        }
        return true;
    }

    protected virtual bool ExportValidSet(ClassClass varClass)
    {
        if (!this.ExportValidClass(varClass.Base))
        {
            NodeClass ka;
            ka = varClass.Any as NodeClass;
            this.Error(this.ErrorKind.ClassUnexport, ka, varClass.Index);
        }

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);
        while (iter.Next())
        {
            Field field;
            field = iter.Value as Field;
            if (this.ExportValidCount(field.Count))
            {
                if (!this.ExportValidClass(field.Class))
                {
                    NodeField kb;
                    kb = field.Any as NodeField;
                    this.Error(this.ErrorKind.FieldUnexport, kb, varClass.Index);
                }
            }
        }

        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);
        while (iter.Next())
        {
            Maide maide;
            maide = iter.Value as Maide;
            if (this.ExportValidCount(maide.Count))
            {
                bool b;
                b = false;
                if (!this.ExportValidClass(maide.Class))
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
                        if (!this.ExportValidClass(varVar.Class))
                        {
                            b = true;
                        }
                    }
                }
                if (b)
                {
                    NodeMaide kc;
                    kc = maide.Any as NodeMaide;
                    this.Error(this.ErrorKind.MaideUnexport, kc, varClass.Index);
                }
            }
        }
        return true;
    }

    protected virtual bool ExportValidCount(Count count)
    {
        if (count == this.Count.Prusate | count == this.Count.Precate)
        {
            return true;
        }
        return false;
    }

    protected virtual bool ExportValidClass(ClassClass varClass)
    {
        if (!(varClass.Module == this.Module))
        {
            return true;
        }

        bool a;
        a = this.Module.Export.Valid(varClass.Name);
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

        ClassModule ka;
        ka = null;

        ClassClass entryClass;
        entryClass = null;

        if (!b)
        {
            ka = this.ModuleGet(this.SSystemEntry);

            if (ka == null)
            {
                b = true;
            }            
        }

        if (!b)
        {
            entryClass = this.ModuleClassGet(ka, this.SEntry);

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

            this.SourceIndex = -1;

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