namespace Saber.Module;

public class CompTravel : Travel
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

        this.ThisClass = null;
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

        String fieldName;
        fieldName = null;
        if (!(name == null))
        {
            fieldName = name.Value;
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(fieldName == null))
        {
            if (this.Create.MemberNameDefine(this.ThisClass, fieldName))
            {
                this.Error(this.ErrorKind.NameUnavail, nodeField);
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
                this.Error(this.ErrorKind.ClassUndefine, nodeField);
                return true;
            }
        }

        Count count;
        count = this.GetCount(nodeCount);

        Table varGet;
        varGet = this.ClassInfra.TableCreateStringLess();

        Table varSet;
        varSet = this.ClassInfra.TableCreateStringLess();

        Field a;
        a = new Field();
        a.Init();
        a.Name = fieldName;
        a.Class = varClass;
        a.Count = count;
        a.Get = varGet;
        a.Set = varSet;
        a.Parent = this.ThisClass;
        a.Any = nodeField;

        this.ListInfra.TableAdd(this.ThisClass.Field, a.Name, a);
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

        String maideName;
        maideName = null;
        if (!(name == null))
        {
            maideName = name.Value;
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(maideName == null))
        {
            if (this.Create.MemberNameDefine(this.ThisClass, maideName))
            {
                this.Error(this.ErrorKind.NameUnavail, nodeMaide);
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
                this.Error(this.ErrorKind.ClassUndefine, nodeMaide);
                return true;
            }
        }

        Count count;
        count = this.GetCount(nodeCount);

        this.ParamVar = this.ClassInfra.TableCreateStringLess();

        Table callVar;
        callVar = this.ClassInfra.TableCreateStringLess();

        this.ExecuteParam(param);

        Maide a;
        a = new Maide();
        a.Init();
        a.Name = maideName;
        a.Class = varClass;
        a.Count = count;
        a.Param = this.ParamVar;
        a.Call = callVar;
        a.Parent = this.ThisClass;
        a.Any = nodeMaide;

        this.ParamVar = null;

        this.ListInfra.TableAdd(this.ThisClass.Maide, a.Name, a);
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

        String varName;
        varName = null;
        if (!(name == null))
        {
            varName = name.Value;
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(varName == null))
        {
            if (this.ParamVar.Valid(varName))
            {
                this.Error(this.ErrorKind.NameUnavail, nodeVar);
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
                this.Error(this.ErrorKind.ClassUndefine, nodeVar);
                return true;
            }
        }

        Var a;
        a = new Var();
        a.Init();
        a.Name = varName;
        a.Class = varClass;
        a.Index =  this.ParamVar.Count;
        a.Any = nodeVar;

        this.ListInfra.TableAdd(this.ParamVar, a.Name, a);

        this.Info(nodeVar).Var = a;
        return true;
    }

    protected virtual Count GetCount(NodeCount nodeCount)
    {
        Count a;
        a = null;

        NodeCount k;
        k = null;

        if (a == null)
        {
            k = nodeCount as PrusateCount;
            if (!(k == null))
            {
                a = this.Count.Prusate;
            }
        }
        if (a == null)
        {
            k = nodeCount as PrecateCount;
            if (!(k == null))
            {
                a = this.Count.Precate;
            }
        }
        if (a == null)
        {
            k = nodeCount as PronateCount;
            if (!(k == null))
            {
                a = this.Count.Pronate;
            }
        }
        if (a == null)
        {
            k = nodeCount as PrivateCount;
            if (!(k == null))
            {
                a = this.Count.Private;
            }
        }
        return a;
    }
}