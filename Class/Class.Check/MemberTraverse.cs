namespace Class.Check;




class MemberTraverse : Traverse
{
    private InfraClass CurrentClass { get; set; }





    private Table ParamVars { get; set; }





    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (nodeClass == null)
        {
            return true;
        }




        this.CurrentClass = this.Check(nodeClass).Class;




        if (this.CurrentClass == null)
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




        NodeAccess nodeAccess;

        nodeAccess = nodeField.Access;




        State nodeGet;

        nodeGet = nodeField.Get;




        State nodeSet;

        nodeSet = nodeField.Set;






        string fieldName;


        fieldName = name.Value;





        string className;

        
        className = nodeClass.Value;
               






        if (this.IsMemberNameDefined(fieldName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeField);


            return true;
        }






        InfraClass varClass;



        
        varClass = this.Class(className);
        




        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeField);


            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);







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


        field.Access = access;


        field.Get = varGet;


        field.Set = varSet;


        field.Parent = this.CurrentClass;


        field.Node = nodeField;




        field.Index = this.CurrentClass.Field.Count;





        TableEntry oo;


        oo = new TableEntry();


        oo.Init();


        oo.Index = fieldName;


        oo.Value = field;



        this.CurrentClass.Field.Add(oo);





        this.Check(nodeField).Field = field;




        return true;
    }





    public override bool ExecuteMield(NodeMield nodeMield)
    {
        if (nodeMield == null)
        {
            return true;
        }





        MieldName name;

        name = nodeMield.Name;




        ClassName nodeClass;

        nodeClass = nodeMield.Class;




        NodeAccess nodeAccess;

        nodeAccess = nodeMield.Access;




        Param param;

        param = nodeMield.Param;




        State call;

        call = nodeMield.Call;






        string methodName;



        methodName = name.Value;





        string className;


        
        className = nodeClass.Value;
        




        
        if (this.IsMemberNameDefined(methodName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMield);



            return true;
        }





        InfraClass varClass;



        
        varClass = this.Class(className);
        




        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeMield);



            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);






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






        Mield method;


        method = new Mield();


        method.Init();


        method.Name = methodName;


        method.Class = varClass;


        method.Access = access;


        method.Param = this.ParamVars;


        method.Call = u;


        method.Parent = this.CurrentClass;


        method.Node = nodeMield;



        method.Index = this.CurrentClass.Maide.Count;
        





        TableEntry oo;


        oo = new TableEntry();


        oo.Init();


        oo.Index = methodName;


        oo.Value = method;




        this.CurrentClass.Maide.Add(oo);




        this.Check(nodeMield).Method = method;




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





        InfraClass varClass;


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


        varVar.Node = nodeVar;





        this.VarMapAdd(this.ParamVars, varVar);
        




        this.Check(nodeVar).Var = varVar;




        return true;
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








    private bool IsMemberNameDefined(string name)
    {
        bool ba;


        ba = this.CurrentClass.Field.Contain(name);




        bool bb;

        bb = this.CurrentClass.Maide.Contain(name);




        bool t;


        t = ba | bb;




        bool ret;


        ret = t;


        return ret;
    }
}