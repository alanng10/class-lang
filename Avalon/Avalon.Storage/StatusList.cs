namespace Avalon.Storage;

public class StatusList : Any
{
    public static StatusList This { get; } = ShareCreate();

    private static StatusList ShareCreate()
    {
        StatusList share;
        share = new StatusList();
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

        this.NoError = this.AddItem();
        this.ReadError = this.AddItem();
        this.WriteError = this.AddItem();
        this.FatalError = this.AddItem();
        this.ResourceError = this.AddItem();
        this.OpenError = this.AddItem();
        this.AbortError = this.AddItem();
        this.TimeOutError = this.AddItem();
        this.UnspecifiedError = this.AddItem();
        this.RemoveError = this.AddItem();
        this.RenameError = this.AddItem();
        this.PositionError = this.AddItem();
        this.ResizeError = this.AddItem();
        this.PermissionsError = this.AddItem();
        this.CopyError = this.AddItem();
        return true;
    }

    public virtual Status NoError { get; set; }
    public virtual Status ReadError { get; set; }
    public virtual Status WriteError { get; set; }
    public virtual Status FatalError { get; set; }
    public virtual Status ResourceError { get; set; }
    public virtual Status OpenError { get; set; }
    public virtual Status AbortError { get; set; }
    public virtual Status TimeOutError { get; set; }
    public virtual Status UnspecifiedError { get; set; }
    public virtual Status RemoveError { get; set; }
    public virtual Status RenameError { get; set; }
    public virtual Status PositionError { get; set; }
    public virtual Status ResizeError { get; set; }
    public virtual Status PermissionsError { get; set; }
    public virtual Status CopyError { get; set; }

    protected virtual Status AddItem()
    {
        int index;
        index = this.Index;

        Status item;
        item = new Status();
        item.Init();
        item.Index = index;
        this.Array.SetAt(index, item);
        this.Index = index + 1;
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

    protected virtual int ArrayCount { get { return 15; } set { } }

    public virtual int Count { get; set; }
    
    protected virtual int Index { get; set; }

    public virtual Status Get(int index)
    {
        return (Status)this.Array.GetAt(index);
    }
}