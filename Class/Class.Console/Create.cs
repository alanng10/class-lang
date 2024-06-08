namespace Class.Console;

public class Create : Any
{
    public virtual Console Console { get; set; }
    public virtual Result Result { get; set; }
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
        TokenCreate a;
        a = new TokenCreate();
        a.Init();
        return a;
    }

    protected virtual NodeCreate CreateNode()
    {
        NodeCreate a;
        a = new NodeCreate();
        a.Init();
        return a;
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

        TaskKindList kindList;
        kindList = this.Console.TaskKind;
        TaskKind kind;
        kind = this.Console.Task.Kind;
    
        if (kind == kindList.Console | 
            kind == kindList.Module |
            kind == kindList.Node |
            kind == kindList.Token
        )
        {
            this.ExecuteToken();
        }

        if (kind == kindList.Console |
            kind == kindList.Module |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        if (kind == kindList.Console |
            kind == kindList.Module)
        {
            this.ExecuteModule();
        }

        return true;
    }

    public virtual bool ExecuteToken()
    {
        this.Token.Source = this.Console.Source;
        this.Token.Execute();
        this.Result.Token = this.Token.Result;

        this.Token.Source = null;
        this.Token.Result = null;
        return true;
    }

    public virtual bool ExecuteNode()
    {
        this.Node.Source = this.Console.Source;
        this.Node.Task = this.Console.Task.Node;
        this.Node.Code = this.Result.Token.Code;
        this.Node.Execute();
        this.Result.Node = this.Node.Result;

        this.Node.Source = null;
        this.Node.Task = null;
        this.Node.Code = null;
        this.Node.Result = null;
        return true;
    }

    public virtual bool ExecuteModule()
    {
        this.Module.Source = this.Console.Source;
        this.Module.RootNode = this.Result.Node.Root;
        this.Module.Execute();
        this.Result.Module = this.Module.Result;

        this.Module.Source = null;
        this.Module.RootNode = null;
        this.Module.Result = null;
        return true;
    }
}