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
    public virtual Result Result { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual ErrorKindList ErrorKind { get; set; }
    public virtual CountList Count { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual Table BaseTable { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }

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
        ClassTraverse traverse;
        traverse = new ClassTraverse();
        traverse.Create = this;
        traverse.Init();
        return traverse;
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

    public virtual ClassClass Class(string name)
    {
        ClassClass a;
        a = (ClassClass)this.Module.Class.Get(name);
        return a;
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
        MemberTraverse traverse;
        traverse = new MemberTraverse();
        traverse.Create = this;
        traverse.Init();
        return traverse;
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
        StateTraverse traverse;
        traverse = new StateTraverse();
        traverse.Create = this;
        traverse.Init();
        return traverse;
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
            source = (Source)this.Source.Get(i);
            
            this.TreeTraverse(traverse, root, source);
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
}