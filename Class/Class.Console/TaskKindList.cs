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
        return true;
    }

    public virtual TaskKind Port { get; set; }
    public virtual TaskKind Token { get; set; }
    public virtual TaskKind Node { get; set; }
    public virtual TaskKind Module { get; set; }

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

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 4;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual TaskKind Get(int index)
    {
        return (TaskKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}