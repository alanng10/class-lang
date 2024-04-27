namespace Class.Console;




public class Create : Any
{
    public virtual Console Class { get; set; }




    public virtual Result Result { get; set; }




    public virtual Source Source { get; set; }




    public virtual TokenCreate Token { get; set; }




    public virtual NodeCreate Node { get; set; }




    public virtual ModuleCreate Module { get; set; }




    public override bool Init()
    {
        base.Init();





        this.Token = this.CreateToken();







        this.Node = this.CreateNode();







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





    protected virtual ModuleCreate CreateModule()
    {
        ModuleCreate a;
        a = new ModuleCreate();
        a.Init();
        return a;
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

        


        if (kind == kindList.Refer |
            kind == kindList.Node |
            kind == kindList.Token
        )
        {
            this.ExecuteToken();
        }




        if (kind == kindList.Refer |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kindList.Refer)
        {
            this.ExecuteRefer();
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




    public virtual bool ExecuteRefer()
    {
        this.Module.Source = this.Source;



        this.Module.TaskModule = this.Class.ModuleName;





        this.Module.Execute();



        this.Result.Module = this.Module.Result;



        return true;
    }
}