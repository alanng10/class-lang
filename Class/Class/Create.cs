namespace Class;




public class Create : Any
{
    public Class Class { get; set; }
        
        


    public Result Result { get; set; }




    public Source Source { get; set; }




    public TokenCreate Token { get; set; }




    public NodeCreate Node { get; set; }




    public CheckCreate Check { get; set; }




    public ModuleCreate Module { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Token = this.CreateToken();







        this.Node = this.CreateNode();







        this.Check = this.CreateCheck();







        this.Module = this.CreateModule();





        return true;
    }




    protected virtual TokenCreate CreateToken()
    {
        TokenCreate create;




        create = new TokenCreate();




        create.Init();





        TokenCreate ret;


        ret = create;



        return ret;
    }





    protected virtual NodeCreate CreateNode()
    {
        NodeCreate create;




        create = new NodeCreate();




        create.Init();





        NodeCreate ret;


        ret = create;



        return ret;
    }





    protected virtual CheckCreate CreateCheck()
    {
        CheckCreate create;




        create = new CheckCreate();




        create.Init();





        CheckCreate ret;


        ret = create;



        return ret;
    }





    protected virtual ModuleCreate CreateModule()
    {
        ModuleCreate create;




        create = new ModuleCreate();




        create.Init();





        ModuleCreate ret;


        ret = create;



        return ret;
    }






    public bool Execute()
    {
        this.Result = new Result();


        this.Result.Init();
        



        this.Source = this.Class.Source;




        TaskKind kind;


        kind = this.Class.Task.Kind;



        TaskKindList kindList;


        kindList = this.Class.TaskKind;

        


        if (kind == kindList.Module |
            kind == kindList.Check |
            kind == kindList.Node |
            kind == kindList.Token
        )
        {
            this.ExecuteToken();
        }




        if (kind == kindList.Module |
            kind == kindList.Check |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kindList.Module |
            kind == kindList.Check
        )
        {
            this.ExecuteCheck();
        }




        if (kind == kindList.Module)
        {
            this.ExecuteModule();
        }



        return true;
    }




    public virtual bool ExecuteToken()
    {
        this.Token.Source = this.Source;

        

        this.Token.Execute();



        this.Result.Token = this.Token.Result;



        return true;
    }




    public virtual bool ExecuteNode()
    {
        this.Node.Source = this.Source;



        this.Node.Task = this.Class.Task.Node;



        this.Node.CodeArray = this.Result.Token.Code;



        this.Node.Execute();



        this.Result.Node = this.Node.Result;



        return true;
    }




    public virtual bool ExecuteCheck()
    {
        this.Check.Source = this.Source;



        this.Check.TaskModule = this.Class.ModuleName;





        this.Check.Execute();



        this.Result.Check = this.Check.Result;



        return true;
    }





    public virtual bool ExecuteModule()
    {
        return true;
    }
}