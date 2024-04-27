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

    private Table ParamVars { get; set; }

    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (nodeClass == null)
        {
            return true;
        }

        this.ThisClass = this.Info(nodeClass).Class;

        if (this.ThisClass == null)
        {
            return true;
        }

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
            if (this.MemberNameDefined(fieldName))
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

        Field field;
        field = new Field();
        field.Init();
        field.Name = fieldName;
        field.Class = varClass;
        field.Count = count;
        field.Get = varGet;
        field.Set = varSet;
        field.Parent = this.ThisClass;
        field.Index = this.ThisClass.Field.Count;
        field.Any = nodeField;

        this.ListInfra.TableAdd(this.ThisClass.Field, field.Name, field);

        this.Info(nodeField).Field = field;
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




        NodeCount nodeAccess;

        nodeAccess = nodeMaide.Count;




        Param param;

        param = nodeMaide.Param;




        State call;

        call = nodeMaide.Call;






        string methodName;



        methodName = name.Value;





        string className;


        
        className = nodeClass.Value;
        




        
        if (this.MemberNameDefined(methodName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMaide);



            return true;
        }





        ClassClass varClass;



        
        varClass = this.Class(className);
        




        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeMaide);



            return true;
        }





        Count access;



        access = this.GetCount(nodeAccess);






        Table o;


        o = new Table();


        o.Compare = new StringCompare();


        o.Compare.Init();


        o.Init();





        Table u;


        u = new Table();


        u.Compare = new StringCompare();


        u.Compare.Init();


        u.Init();






        this.ParamVars = o;





        this.ExecuteParam(param);






        Maide method;


        method = new Maide();


        method.Init();


        method.Name = methodName;


        method.Class = varClass;


        method.Count = access;


        method.Param = this.ParamVars;


        method.Call = u;


        method.Parent = this.ThisClass;


        method.Any = nodeMaide;



        method.Index = this.ThisClass.Maide.Count;
        





        TableEntry oo;


        oo = new TableEntry();


        oo.Init();


        oo.Index = methodName;


        oo.Value = method;




        this.ThisClass.Maide.Add(oo);




        this.Info(nodeMaide).Maide = method;




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


        className = null;



        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }






        if (!(this.ParamVars.Get(varName) == null))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        ClassClass varClass;


        varClass = null;




        if (!(className == null))
        {
            varClass = this.Class(className);
        }

        


        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Name = varName;


        varVar.Class = varClass;


        varVar.Any = nodeVar;





        this.VarMapAdd(this.ParamVars, varVar);
        




        this.Info(nodeVar).Var = varVar;




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




    private bool VarMapAdd(Table map, Var varVar)
    {
        TableEntry o;


        o = new TableEntry();


        o.Init();


        o.Index = varVar.Name;


        o.Value = varVar;




        map.Add(o);



        return true;
    }








    protected virtual bool MemberNameDefined(string name)
    {
        bool ba;
        ba = this.ThisClass.Field.Contain(name);
        bool bb;
        bb = this.ThisClass.Maide.Contain(name);

        bool a;
        a = ba | bb;
        return a;
    }
}