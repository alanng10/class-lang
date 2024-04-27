namespace Class.Module;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;

        this.ErrorKind = this.CreateErrorKindList();
        this.Count = this.CreateCountList();

        this.SystemClass = new SystemClass();
        this.SystemClass.Init();
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Array RootNode { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Result Result { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual ErrorKindList ErrorKind { get; set; }
    public virtual CountList Count { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual Table BaseTable { get; set; }

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
        
        this.AddBases();

        return true;
    }

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
            ClassClass varClass;



            varClass = (ClassClass)this.Module.Class.Get(i);






            this.BaseMapAdd(varClass);
        }




        return true;
    }








    private bool BaseMapAdd(ClassClass varClass)
    {
        NodeClass nodeClass;



        nodeClass = null;





        ClassName nodeBase;



        nodeBase = nodeClass.Base;






        string baseName;


        

        baseName = nodeBase.Value;





        ClassClass varBase;


        

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







        ClassClass t;



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






    protected virtual bool CheckBase(ClassClass varClass)
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
            ClassClass varClass;


            varClass = (ClassClass)iter.Index;




            bool b;


            b = this.CheckClassDependency(varClass);



            if (!b)
            {
                this.Error(this.ErrorKind.BaseUndefined, null, this.SourceItemGet(varClass.Index));
            }




            ClassClass t;



            t = this.SystemClass.Any;




            if (b)
            {
                t = (ClassClass)iter.Value;
            }




            varClass.Base = t;
        }




        return true;
    }






    private bool CheckClassDependency(ClassClass varClass)
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






        ClassClass currentClass;




        currentClass = (ClassClass)this.BaseTable.Get(varClass);





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





            currentClass = (ClassClass)this.BaseTable.Get(currentClass);
        }




        return true;
    }





    private bool ThisModule(ClassClass varClass)
    {
        return true;
    }





    private bool SystemAny(ClassClass varClass)
    {
        return (varClass == this.SystemClass.Any);
    }


    protected virtual Source SourceItemGet(int index)
    {
        return (Source)this.Source.Get(index);
    }




    public virtual bool Error(ErrorKind kind, NodeNode node, Source sourceItem)
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






    public virtual ClassClass Class(string name)
    {
        ClassClass varClass;


        
        varClass = (ClassClass)this.Module.Class.Get(name);




        ClassClass ret;


        ret = varClass;


        return ret;
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

        traverse.SourceItem = source;
        traverse.ExecuteClass(nodeClass);
        return true;
    }
}