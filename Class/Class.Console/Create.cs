namespace Class.Console;




public class Create : Any
{
    public virtual Console Class { get; set; }




    public virtual Result Result { get; set; }




    public virtual Source Source { get; set; }




    public virtual TokenCreate Token { get; set; }




    public virtual NodeCreate Node { get; set; }




    public virtual ReferCreate Refer { get; set; }




    public virtual ModuleCreate Module { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Token = this.CreateToken();







        this.Node = this.CreateNode();







        this.Refer = this.CreateCheck();







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





    protected virtual ReferCreate CreateCheck()
    {
        ReferCreate a;
        a = new ReferCreate();
        a.Init();
        return a;
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






    public virtual bool Execute()
    {
        this.Result = new Result();


        this.Result.Init();
        



        this.Source = this.Class.Source;




        TaskKind kind;


        kind = this.Class.Task.Kind;



        TaskKindList kindList;


        kindList = this.Class.TaskKind;

        


        if (kind == kindList.Module |
            kind == kindList.Refer |
            kind == kindList.Node |
            kind == kindList.Token
        )
        {
            this.ExecuteToken();
        }




        if (kind == kindList.Module |
            kind == kindList.Refer |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kindList.Module |
            kind == kindList.Refer
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
        this.Refer.Source = this.Source;



        this.Refer.TaskModule = this.Class.ModuleName;





        this.Refer.Execute();



        this.Result.Refer = this.Refer.Result;



        return true;
    }





    public virtual bool ExecuteModule()
    {
        return true;
    }
}