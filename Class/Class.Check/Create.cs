namespace Class.Check;






public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;



        this.ErrorKind = this.CreateErrorKindList();




        this.Access = this.CreateAccessList();





        this.SystemClass = new SystemClass();



        this.SystemClass.Init();




        return true;
    }





    public virtual Source Source { get; set; }




    public virtual string TaskModule { get; set; }




    public virtual Array RootArray { get; set; }





    public virtual Table SystemModule { get; set; }




    public virtual Table Check { get; set; }




    public virtual Refer Refer { get; set; }




    public virtual Module Module { get; set; }




    public virtual Result Result { get; set; }





    public virtual SystemClass SystemClass { get; set; }





    public virtual ErrorKindList ErrorKind { get; set; }




    public virtual CountList Access { get; set; }




    protected virtual List ErrorList { get; set; }




    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }







    public override bool Execute()
    {
        this.ExecuteInit();



        this.ExecuteClass();



        this.ExecuteMember();



        this.ExecuteState();




        this.Result.Error = this.ListInfra.ArrayCreateList(this.ErrorList);



        return true;
    }






    private bool ExecuteInit()
    {
        this.Result = new Result();


        this.Result.Init();





        RefCompare compare;

        compare = new RefCompare();

        compare.Init();



        this.Check = new Table();

        this.Check.Compare = compare;

        this.Check.Init();




        this.Check.Init();






        this.Refer = new Refer();



        this.Refer.Init();





        List error;


        error = new List();


        error.Init();


        this.ErrorList = error;





        this.Result.Check = this.Check;




        this.Result.Refer = this.Refer;








        Traverse traverse;




        traverse = this.InitTraverse();




        this.Traverse(traverse);







        this.Module = new Module();
        this.Module.Init();
        this.Module.Ref = new ModuleRef();
        this.Module.Ref.Init();
        this.Module.Ref.Name = this.TaskModule;


        Table classTable;
        classTable = new Table();
        classTable.Compare = new StringCompare();
        classTable.Compare.Init();
        classTable.Init();

        this.Module.Class = classTable;







        this.InitRefer();





        return true;
    }





    protected virtual ErrorKindList CreateErrorKindList()
    {
        return ErrorKindList.This;
    }




    protected virtual CountList CreateAccessList()
    {
        return CountList.This;
    }





    public virtual Check CreateCheck()
    {
        Check check;



        check = new Check();



        check.Init();




        Check ret;

        ret = check;


        return ret;
    }





    protected virtual Traverse InitTraverse()
    {
        InitTraverse traverse;




        traverse = new InitTraverse();





        traverse.Create = this;





        traverse.Init();





        return traverse;
    }







    private bool InitRefer()
    {
        





        return true;
    }











    private bool AddSystemClass(InfraClass varClass)
    {
        



        return true;
    }







    protected virtual InfraClass CreateAnyClass()
    {
        InfraClass varClass;



        varClass = new InfraClass();



        varClass.Name = "Any";



        varClass.Base = varClass;



        StringCompare compareA;

        compareA = new StringCompare();

        compareA.Init();



        varClass.Field = new Table();


        varClass.Field.Compare = compareA;


        varClass.Field.Init();



        StringCompare compareB;

        compareB = new StringCompare();

        compareB.Init();



        varClass.Maide = new Table();


        varClass.Maide.Compare = compareB;


        varClass.Maide.Init();





        InfraClass ret;


        ret = varClass;


        return ret;
    }





    protected virtual Maide CreateMethod(InfraClass varClass, string name, Count access)
    {
        Maide method;


        method = new Maide();


        method.Init();


        method.Class = varClass;


        method.Name = name;


        method.Count = access;






        StringCompare compareA;

        compareA = new StringCompare();

        compareA.Init();




        Table param;


        param = new Table();


        param.Compare = compareA;


        param.Init();




        method.Param = param;




        StringCompare compareB;

        compareB = new StringCompare();

        compareB.Init();



        Table call;


        call = new Table();


        call.Compare = compareB;


        call.Init();



        method.Call = call;
        




        Maide ret;


        ret = method;


        return ret;
    }








    private bool ExecuteClass()
    {
        Traverse traverse;




        traverse = this.ClassTraverse();




        this.Traverse(traverse);






        this.SetSystemModule();





        this.SetAnyClass();






        this.ExecuteClassBases();
        





        return true;
    }





    protected virtual bool SetAnyClass()
    {
        this.AddAnyClassMethod("Init");




        return true;
    }





    protected virtual bool AddAnyClassMethod(string name)
    {
        Maide method;


        method = this.CreateMethod(this.SystemClass.Bool, name, this.Access.Prudate);


        method.Parent = this.SystemClass.Any;


        method.Index = this.SystemClass.Any.Maide.Count;





        TableEntry entry;


        entry = new TableEntry();


        entry.Init();


        entry.Index = method.Name;


        entry.Value = method;





        this.SystemClass.Any.Maide.Add(entry);




        return true;
    }






    protected virtual bool ExecuteClassBases()
    {
        this.SetBaseTable();




        
        this.AddBases();





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








    private Table BaseTable { get; set; }





    private bool SetBaseTable()
    {
        RefCompare compare;


        compare = new RefCompare();


        compare.Init();




        this.BaseTable = new Table();



        this.BaseTable.Compare = compare;



        this.BaseTable.Init();






        int count;

        count = this.Module.Class.Count;


        int i;

        i = 0;



        while (i < count)
        {
            InfraClass varClass;



            varClass = (InfraClass)this.Module.Class.Get(i);






            this.BaseMapAdd(varClass);
        }




        return true;
    }








    private bool BaseMapAdd(InfraClass varClass)
    {
        NodeClass nodeClass;



        nodeClass = null;





        ClassName nodeBase;



        nodeBase = nodeClass.Base;






        string baseName;


        

        baseName = nodeBase.Value;





        InfraClass varBase;


        

        varBase = this.Class(baseName);
        




        bool b;


        b = false;




        if (varBase == null)
        {
            this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceItemGet(varClass.Index));


            b = true;
        }




        if (!(varBase == null))
        {
            if (!this.CheckBase(varBase))
            {
                this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceItemGet(varClass.Index));


                b = true;
            }
        }







        InfraClass t;



        t = varBase;




        if (b)
        {
            t = this.SystemClass.Any;
        }
        




        TableEntry o;


        o = new TableEntry();


        o.Init();


        o.Index = varClass;


        o.Value = t;




        this.BaseTable.Add(o);



        return true;
    }






    protected virtual bool CheckBase(InfraClass varClass)
    {
        return true;
    }







    private bool AddBases()
    {
        Iter iter;

        iter = this.BaseTable.IterCreate();


        this.BaseTable.IterSet(iter);



        while (iter.Next())
        {
            InfraClass varClass;


            varClass = (InfraClass)iter.Index;




            bool b;


            b = this.CheckClassDependency(varClass);



            if (!b)
            {
                this.Error(this.ErrorKind.BaseUndefined, null, this.SourceItemGet(varClass.Index));
            }




            InfraClass t;



            t = this.SystemClass.Any;




            if (b)
            {
                t = (InfraClass)iter.Value;
            }




            varClass.Base = t;
        }




        return true;
    }






    private bool CheckClassDependency(InfraClass varClass)
    {
        Table table;



        table = new Table();



        table.Compare = new RefCompare();



        table.Compare.Init();



        table.Init();






        TableEntry t;



        t = new TableEntry();


        t.Init();


        t.Index = varClass;



        t.Value = varClass;





        table.Add(t);






        InfraClass currentClass;




        currentClass = (InfraClass)this.BaseTable.Get(varClass);





        while (this.ThisModule(currentClass))
        {
            if (this.SystemAny(currentClass))
            {
                return true;
            }






            if (table.Contain(currentClass))
            {
                return false;
            }






            TableEntry oo;



            oo = new TableEntry();



            oo.Init();



            oo.Index = currentClass;



            oo.Value = currentClass;





            table.Add(oo);





            currentClass = (InfraClass)this.BaseTable.Get(currentClass);
        }




        return true;
    }





    private bool ThisModule(InfraClass varClass)
    {
        return true;
    }





    private bool SystemAny(InfraClass varClass)
    {
        return (varClass == this.SystemClass.Any);
    }


    protected virtual SourceItem SourceItemGet(int index)
    {
        return (SourceItem)this.Source.Item.Get(index);
    }




    public virtual bool Error(ErrorKind kind, NodeNode node, SourceItem sourceItem)
    {
        Error error;




        error = new Error();



        
        error.Init();




        error.Stage = this.Stage;




        error.Kind = kind;




        error.Range = node.Range;




        error.Source = sourceItem;




        this.ErrorList.Add(error);




        return true;
    }






    public virtual InfraClass Class(string name)
    {
        InfraClass varClass;


        
        varClass = (InfraClass)this.Refer.Class.Get(name);




        InfraClass ret;


        ret = varClass;


        return ret;
    }





    protected virtual bool ExecuteMember()
    {
        Traverse traverse;




        traverse = this.MemberTraverse();




        this.Traverse(traverse);




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







    private bool ExecuteState()
    {
        Traverse traverse;



        traverse = this.StateTraverse();




        this.Traverse(traverse);




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






    private bool SetSystemModule()
    {


        return true;
    }





    private bool Traverse(Traverse traverse)
    {
        Iter rootIter;

        rootIter = this.RootArray.IterCreate();


        this.RootArray.IterSet(rootIter);




        Iter sourceItemIter;

        sourceItemIter = this.Source.Item.IterCreate();



        this.Source.Item.IterSet(sourceItemIter);




        
        while (rootIter.Next() & sourceItemIter.Next())
        {
            NodeNode root;


            root = (NodeNode)rootIter.Value;




            SourceItem sourceItem;


            sourceItem = (SourceItem)sourceItemIter.Value;




            
            this.TreeTraverse(traverse, root, sourceItem);
        }




        return true;
    }





    private bool TreeTraverse(Traverse traverse, NodeNode root, SourceItem sourceItem)
    {
        if (root == null)
        {
            return true;
        }




        NodeClass nodeClass;



        nodeClass = (NodeClass)root;



        traverse.SourceItem = sourceItem;



        traverse.ExecuteClass(nodeClass);




        return true;
    }
}