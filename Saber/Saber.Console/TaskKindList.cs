namespace Saber.Console;

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

        this.Token = this.AddItem();
        this.Node = this.AddItem();
        this.Module = this.AddItem();
        this.Console = this.AddItem();
        this.Library = this.AddItem();
        return true;
    }

    public virtual TaskKind Token { get; set; }
    public virtual TaskKind Node { get; set; }
    public virtual TaskKind Module { get; set; }
    public virtual TaskKind Console { get; set; }
    public virtual TaskKind Library { get; set; }

    protected virtual TaskKind AddItem()
    {
        TaskKind item;
        item = new TaskKind();
        item.Init();
        item.Index = this.Index;
        this.Array.SetAt(item.Index, item);
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

    protected virtual long ArrayCount { get { return 5; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual TaskKind Get(long index)
    {
        return this.Array.GetAt(index) as TaskKind;
    }
}