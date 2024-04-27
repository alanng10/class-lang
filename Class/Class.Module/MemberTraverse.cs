namespace Class.Module;

public class MemberTraverse : Traverse
{
    public virtual ClassClass ThisClass { get; set; }

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



        
        varClass = this.Class(className);
        




        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeField);


            return true;
        }





        Count count;



        count = this.GetCount(nodeCount);







        Table varGet;


        varGet = new Table();


        varGet.Compare = new StringCompare();


        varGet.Compare.Init();


        varGet.Init();
        





        Table varSet;


        varSet = new Table();


        varSet.Compare = new StringCompare();


        varSet.Compare.Init();


        varSet.Init();







        Field field;
            

        field = new Field();


        field.Init();
            

        field.Name = fieldName;
            

        field.Class = varClass;


        field.Count = count;


        field.Get = varGet;


        field.Set = varSet;


        field.Parent = this.ThisClass;


        field.Any = nodeField;




        field.Index = this.ThisClass.Field.Count;





        TableEntry oo;


        oo = new TableEntry();


        oo.Init();


        oo.Index = fieldName;


        oo.Value = field;



        this.ThisClass.Field.Add(oo);





        this.Info(nodeField).Field = field;




        return true;
    }





    public override bool ExecuteMaide(NodeMaide nodeMield)
    {
        if (nodeMield == null)
        {
            return true;
        }





        MaideName name;

        name = nodeMield.Name;




        ClassName nodeClass;

        nodeClass = nodeMield.Class;




        NodeCount nodeAccess;

        nodeAccess = nodeMield.Count;




        Param param;

        param = nodeMield.Param;




        State call;

        call = nodeMield.Call;






        string methodName;



        methodName = name.Value;





        string className;


        
        className = nodeClass.Value;
        




        
        if (this.MemberNameDefined(methodName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMield);



            return true;
        }





        ClassClass varClass;



        
        varClass = this.Class(className);
        




        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeMield);



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


        method.Any = nodeMield;



        method.Index = this.ThisClass.Maide.Count;
        





        TableEntry oo;


        oo = new TableEntry();


        oo.Init();


        oo.Index = methodName;


        oo.Value = method;




        this.ThisClass.Maide.Add(oo);




        this.Info(nodeMield).Maide = method;




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