namespace Class.Module;

public class MemberTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual ClassClass ThisClass { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Table ParamVar { get; set; }

    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (nodeClass == null)
        {
            return true;
        }

        this.ThisClass = this.Info(nodeClass).Class;

        base.ExecuteClass(nodeClass);
        return true;
    }

    public override bool ExecuteField(NodeField nodeField)
    {
        if (nodeField == null)
        {
            return true;
        }

        FieldName name;
        name = nodeField.Name;
        ClassName nodeClass;
        nodeClass = nodeField.Class;
        NodeCount nodeCount;
        nodeCount = nodeField.Count;
        State nodeGet;
        nodeGet = nodeField.Get;
        State nodeSet;
        nodeSet = nodeField.Set;

        string fieldName;
        fieldName = null;
        if (!(name == null))
        {
            fieldName = name.Value;
        }

        string className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(fieldName == null))
        {
            if (this.Create.MemberNameDefined(this.ThisClass, fieldName))
            {
                this.Error(this.ErrorKind.NameUnavailable, nodeField);
                return true;
            }
        }

        ClassClass varClass;
        varClass = null;

        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefined, nodeField);
                return true;
            }
        }

        Count count;
        count = this.GetCount(nodeCount);

        Table varGet;
        varGet = this.ClassInfra.TableCreateStringCompare();

        Table varSet;
        varSet = this.ClassInfra.TableCreateStringCompare();

        SystemInfo e;
        e = new SystemInfo();
        e.Init();

        Field a;
        a = new Field();
        a.Init();
        a.Name = fieldName;
        a.Class = varClass;
        a.Count = count;
        a.Get = varGet;
        a.Set = varSet;
        a.Parent = this.ThisClass;
        a.Index = this.ThisClass.Field.Count;
        a.Any = nodeField;
        a.SystemInfo = e;

        this.ListInfra.TableAdd(this.ThisClass.Field, a.Name, a);

        this.Info(nodeField).Field = a;
        return true;
    }

    public override bool ExecuteMaide(NodeMaide nodeMaide)
    {
        if (nodeMaide == null)
        {
            return true;
        }

        MaideName name;
        name = nodeMaide.Name;
        ClassName nodeClass;
        nodeClass = nodeMaide.Class;
        NodeCount nodeCount;
        nodeCount = nodeMaide.Count;
        Param param;
        param = nodeMaide.Param;
        State call;
        call = nodeMaide.Call;

        string maideName;
        maideName = null;
        if (!(name == null))
        {
            maideName = name.Value;
        }

        string className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(maideName == null))
        {
            if (this.Create.MemberNameDefined(this.ThisClass, maideName))
            {
                this.Error(this.ErrorKind.NameUnavailable, nodeMaide);
                return true;
            }
        }

        ClassClass varClass;
        varClass = null;

        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefined, nodeMaide);
                return true;
            }
        }

        Count count;
        count = this.GetCount(nodeCount);

        this.ParamVar = this.ClassInfra.TableCreateStringCompare();

        Table callVar;
        callVar = this.ClassInfra.TableCreateStringCompare();

        this.ExecuteParam(param);

        SystemInfo e;
        e = new SystemInfo();
        e.Init();

        Maide a;
        a = new Maide();
        a.Init();
        a.Name = maideName;
        a.Class = varClass;
        a.Count = count;
        a.Param = this.ParamVar;
        a.Call = callVar;
        a.Parent = this.ThisClass;
        a.Index = this.ThisClass.Maide.Count;
        a.Any = nodeMaide;
        a.SystemInfo = e;

        this.ParamVar = null;

        this.ListInfra.TableAdd(this.ThisClass.Maide, a.Name, a);

        this.Info(nodeMaide).Maide = a;
        return true;
    }

    public override bool ExecuteVar(NodeVar nodeVar)
    {
        if (nodeVar == null)
        {
            return true;
        }

        VarName name;
        name = nodeVar.Name;
        ClassName nodeClass;
        nodeClass = nodeVar.Class;

        string varName;
        varName = name.Value;

        string className;
        className = nodeClass.Value;

        if (this.ParamVar.Contain(varName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);
            return true;
        }

        ClassClass varClass;
        varClass = this.Class(className);
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);
            return true;
        }

        SystemInfo e;
        e = new SystemInfo();
        e.Init();

        Var a;
        a = new Var();
        a.Init();
        a.Name = varName;
        a.Class = varClass;
        a.Any = nodeVar;
        a.SystemInfo = e;

        this.ListInfra.TableAdd(this.ParamVar, a.Name, a);

        this.Info(nodeVar).Var = a;
        return true;
    }

    protected virtual Count GetCount(NodeCount nodeCount)
    {
        Count a;
        a = null;

        if ((a == null) & (nodeCount is PrudateAccess))
        {
            a = this.Count.Prudate;
        }
        if ((a == null) & (nodeCount is ProbateAccess))
        {
            a = this.Count.Probate;
        }
        if ((a == null) & (nodeCount is PrecateAccess))
        {
            a = this.Count.Precate;
        }
        if ((a == null) & (nodeCount is PrivateAccess))
        {
            a = this.Count.Private;
        }
        return a;
    }
}