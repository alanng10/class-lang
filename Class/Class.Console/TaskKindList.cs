namespace Class.Console;

public class TaskKindList : Any
{
    public static TaskKindList This { get; } = ShareCreate();

    private static TaskKindList ShareCreate()
    {
        TaskKindList share;
        share = new TaskKindList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.Port = this.AddItem();
        this.Token = this.AddItem();
        this.Node = this.AddItem();
        this.Module = this.AddItem();
        this.Console = this.AddItem();
        return true;
    }

    public virtual TaskKind Port { get { return __D_Port; } set { __D_Port = value; } }
    protected TaskKind __D_Port;
    public virtual TaskKind Token { get { return __D_Token; } set { __D_Token = value; } }
    protected TaskKind __D_Token;
    public virtual TaskKind Node { get { return __D_Node; } set { __D_Node = value; } }
    protected TaskKind __D_Node;
    public virtual TaskKind Module { get { return __D_Module; } set { __D_Module = value; } }
    protected TaskKind __D_Module;
    public virtual TaskKind Console { get { return __D_Console; } set { __D_Console = value; } }
    protected TaskKind __D_Console;

    protected virtual TaskKind AddItem()
    {
        TaskKind item;
        item = new TaskKind();
        item.Init();
        item.Index = this.Index;
        this.Array.Set(item.Index, item);
        this.Index = this.Index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 5; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual TaskKind Get(int index)
    {
        return (TaskKind)this.Array.Get(index);
    }
}