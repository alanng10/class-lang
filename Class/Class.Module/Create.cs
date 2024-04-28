namespace Class.Module;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.ErrorKind = this.CreateErrorKindList();
        this.Count = this.CreateCountList();

        this.SystemClass = new SystemClass();
        this.SystemClass.Init();

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Array RootNode { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ClassTable { get; set; }
    public virtual Result Result { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual ErrorKindList ErrorKind { get; set; }
    public virtual CountList Count { get; set; }
    public virtual ClassClass NullClass { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual Table BaseTable { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }

    protected virtual bool InitNullClass()
    {
        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Name = "_";
        this.NullClass = a;
        return true;
    }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.ErrorList = new List();
        this.ErrorList.Init();

        this.ExecuteInit();
        this.ExecuteClass();
        this.ExecuteBase();
        this.ExecuteMember();
        this.ExecuteVirtual();
        this.ExecuteState();

        this.Result.Module = this.Module;
        this.Result.Error = this.ListInfra.ArrayCreateList(this.ErrorList);
        this.ErrorList = null;
        return true;
    }

    protected virtual bool SystemClassSet()
    {
        ClassModule d;
        d = this.ModuleGet("System.Infra");

        this.SystemClass.Any = this.ModuleClassGet(d, "Any");
        this.SystemClass.Bool = this.ModuleClassGet(d, "Bool");
        this.SystemClass.Int = this.ModuleClassGet(d, "Int");
        this.SystemClass.String = this.ModuleClassGet(d, "String");
        this.SystemClass.ModuleInfo = this.ModuleClassGet(d, "ModuleInfo");
        return true;
    }

    protected virtual ClassModule ModuleGet(string moduleName)
    {
        this.ModuleRef.Name = moduleName;
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(this.ModuleRef);
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, string className)
    {
        return (ClassClass)module.Class.Get(className);
    }

    protected virtual ErrorKindList CreateErrorKindList()
    {
        return ErrorKindList.This;
    }

    protected virtual CountList CreateCountList()
    {
        return CountList.This;
    }

    public virtual Info CreateInfo()
    {
        Info a;
        a = new Info();
        a.Init();
        return a;
    }

    protected virtual bool ExecuteInit()
    {
        Traverse traverse;
        traverse = this.InitTraverse();
        this.ExecuteTraverse(traverse);
        return true;
    }

    protected virtual Traverse InitTraverse()
    {
        InitTraverse a;
        a = new InitTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteClass()
    {
        Traverse traverse;
        traverse = this.ClassTraverse();
        this.ExecuteTraverse(traverse);
        return true;
    }

    protected virtual Traverse ClassTraverse()
    {
        ClassTraverse a;
        a = new ClassTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteBase()
    {
        this.SetBaseTable();

        this.AddBaseList();

        this.BaseTable = null;
        return true;
    }

    protected virtual bool SetBaseTable()
    {
        RefCompare compare;
        compare = new RefCompare();
        compare.Init();
        this.BaseTable = new Table();
        this.BaseTable.Compare = compare;
        this.BaseTable.Init();

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;
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

        string baseName;
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
            this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));
            b = true;
        }

        if (!ba)
        {
            if (!this.CheckBase(varBase))
            {
                this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));
                b = true;
            }
        }

        ClassClass a;
        a = varBase;

        if (b)
        {
            a = this.SystemClass.Any;
        }

        this.ListInfra.TableAdd(this.BaseTable, varClass, a);
        return true;
    }

    protected virtual bool CheckBase(ClassClass varClass)
    {
        SystemClass d;
        d = this.SystemClass;

        if (varClass == d.Bool | varClass == d.Int | varClass == d.String | varClass == d.ModuleInfo)
        {
            return false;
        }
        return true;
    }

    protected virtual bool AddBaseList()
    {
        ClassClass anyClass;
        anyClass = this.SystemClass.Any;

        Iter iter;
        iter = this.BaseTable.IterCreate();
        this.BaseTable.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Index;

            bool b;
            b = this.CheckClassDependency(varClass);

            ClassClass a;
            a = null;

            if (!b)
            {
                NodeClass nodeClass;
                nodeClass = (NodeClass)varClass.Any;

                this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));

                a = anyClass;
            }
            if (b)
            {
                a = (ClassClass)iter.Value;
            }
            varClass.Base = a;
        }
        return true;
    }

    protected virtual bool CheckClassDependency(ClassClass varClass)
    {
        ClassModule module;
        module = this.Module;

        Table table;
        table = new Table();
        table.Compare = new RefCompare();
        table.Compare.Init();
        table.Init();

        this.ListInfra.TableAdd(table, varClass, varClass);

        ClassClass a;
        a = (ClassClass)this.BaseTable.Get(varClass);

        while (a.Module == module)
        {
            if (table.Contain(a))
            {
                return false;
            }

            this.ListInfra.TableAdd(table, a, a);

            a = (ClassClass)this.BaseTable.Get(a);
        }
        return true;
    }

    protected virtual bool ExecuteMember()
    {
        Traverse traverse;
        traverse = this.MemberTraverse();
        this.ExecuteTraverse(traverse);
        return true;
    }

    protected virtual Traverse MemberTraverse()
    {
        MemberTraverse a;
        a = new MemberTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteVirtual()
    {
        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;
            this.ExecuteVirtualClass(a);
        }
        return true;
    }

    protected virtual bool ExecuteVirtualClass(ClassClass varClass)
    {
        this.ExecuteVirtualField(varClass.Field);
        this.ExecuteVirtualMaide(varClass.Maide);
        return true;
    }

    protected virtual bool ExecuteVirtualField(Table field)
    {
        Iter iter;
        iter = field.IterCreate();
        field.IterSet(iter);
        while (iter.Next())
        {
            Field a;
            a = (Field)iter.Value;
            a.Virtual = this.VirtualField(a);

            if (!(a.Virtual == null))
            {
                this.ClassInfra.SystemInfoAssignValue(a.SystemInfo, a.Virtual.SystemInfo);
            }
        }
        return true;
    }

    protected virtual Field VirtualField(Field a)
    {
        if (a.Count == this.Count.Private)
        {
            return null;
        }

        bool ba;
        ba = (a.Count == this.Count.Probate);

        string name;
        name = a.Name;

        ClassClass anyClass;
        anyClass = this.SystemClass.Any;

        bool b;
        b = false;

        Field d;
        d = null;

        ClassClass varClass;
        varClass = a.Parent;

        ClassClass thisClass;
        thisClass = varClass.Base;
        while (!b & !(thisClass == null))
        {
            if (thisClass.Maide.Contain(name))
            {
                b = true;
            }

            if (!b)
            {
                Field o;
                o = (Field)thisClass.Field.Get(name);
                if (!(o == null))
                {
                    if ((a.Class == o.Class & a.Count == o.Count))
                    {
                        if (ba)
                        {
                            if (a.Parent.Module == o.Parent.Module)
                            {
                                d = o;
                            }
                        }
                        if (!ba)
                        {
                            d = o;
                        }
                    }
                    b = true;
                }
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        Field h;
        h = d;
        if (!(d.Virtual == null))
        {
            h = d.Virtual;
        }
        return h;
    }

    protected virtual bool ExecuteVirtualMaide(Table maide)
    {
        Iter iter;
        iter = maide.IterCreate();
        maide.IterSet(iter);
        while (iter.Next())
        {
            Maide a;
            a = (Maide)iter.Value;
            a.Virtual = this.VirtualMaide(a);

            if (!(a.Virtual == null))
            {
                this.ClassInfra.SystemInfoAssignValue(a.SystemInfo, a.Virtual.SystemInfo);

                this.VarSystemInfoAssignValue(a.Param, a.Virtual.Param);
            }
        }
        return true;
    }

    protected virtual Maide VirtualMaide(Maide a)
    {
        if (a.Count == this.Count.Private)
        {
            return null;
        }

        bool ba;
        ba = (a.Count == this.Count.Probate);

        string name;
        name = a.Name;

        ClassClass anyClass;
        anyClass = this.SystemClass.Any;

        bool b;
        b = false;

        Maide d;
        d = null;

        ClassClass varClass;
        varClass = a.Parent;

        ClassClass thisClass;
        thisClass = varClass.Base;
        while (!b & !(thisClass == null))
        {
            if (thisClass.Field.Contain(name))
            {
                b = true;
            }

            if (!b)
            {
                Maide o;
                o = (Maide)thisClass.Maide.Get(name);
                if (!(o == null))
                {
                    if ((a.Class == o.Class & a.Count == o.Count))
                    {
                        if (this.VarSameClass(a.Param, o.Param))
                        {
                            if (ba)
                            {
                                if (a.Parent.Module == o.Parent.Module)
                                {
                                    d = o;
                                }
                            }
                            if (!ba)
                            {
                                d = o;
                            }
                        }
                    }
                    b = true;
                }
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        Maide h;
        h = d;
        if (!(d.Virtual == null))
        {
            h = d.Virtual;
        }
        return h;
    }

    protected virtual bool VarSystemInfoAssignValue(Table varA, Table varB)
    {
        Iter iterA;
        iterA = varA.IterCreate();
        varA.IterSet(iterA);

        Iter iterB;
        iterB = varB.IterCreate();
        varB.IterSet(iterB);

        int count;
        count = varA.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iterA.Next();
            iterB.Next();

            Var aa;
            Var ab;
            aa = (Var)iterA.Value;
            ab = (Var)iterB.Value;

            this.ClassInfra.SystemInfoAssignValue(aa.SystemInfo, ab.SystemInfo);

            i = i + 1;
        }
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

        int count;
        count = varA.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iterA.Next();
            iterB.Next();

            Var aa;
            Var ab;
            aa = (Var)iterA.Value;
            ab = (Var)iterB.Value;

            bool b;
            b = (aa.Class == ab.Class);
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
        Traverse traverse;
        traverse = this.StateTraverse();
        this.ExecuteTraverse(traverse);
        return true;
    }

    protected virtual Traverse StateTraverse()
    {
        StateTraverse a;
        a = new StateTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteTraverse(Traverse traverse)
    {
        int count;
        count = this.Source.Count;
        int i;
        i = 0;
        while (i < count)
        {
            NodeNode root;
            root = (NodeNode)this.RootNode.Get(i);

            Source source;
            source = this.SourceGet(i);

            this.TreeTraverse(traverse, root, source);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool TreeTraverse(Traverse traverse, NodeNode root, Source source)
    {
        if (root == null)
        {
            return true;
        }

        NodeClass nodeClass;
        nodeClass = (NodeClass)root;

        traverse.Source = source;
        traverse.ExecuteClass(nodeClass);
        return true;
    }

    public virtual ClassClass Class(string name)
    {
        ClassClass a;
        a = (ClassClass)this.ClassTable.Get(name);
        return a;
    }

    public virtual bool MemberNameDefined(ClassClass varClass, string name)
    {
        bool ba;
        ba = varClass.Field.Contain(name);
        bool bb;
        bb = varClass.Maide.Contain(name);

        bool a;
        a = ba | bb;
        return a;
    }

    protected virtual Source SourceGet(int index)
    {
        return (Source)this.Source.Get(index);
    }

    public virtual bool Error(ErrorKind kind, NodeNode node, Source source)
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
}