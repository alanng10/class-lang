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

    public virtual Status NoError { get { return __D_NoError; } set { __D_NoError = value; } }
    protected Status __D_NoError;
    public virtual Status ReadError { get { return __D_ReadError; } set { __D_ReadError = value; } }
    protected Status __D_ReadError;
    public virtual Status WriteError { get { return __D_WriteError; } set { __D_WriteError = value; } }
    protected Status __D_WriteError;
    public virtual Status FatalError { get { return __D_FatalError; } set { __D_FatalError = value; } }
    protected Status __D_FatalError;
    public virtual Status ResourceError { get { return __D_ResourceError; } set { __D_ResourceError = value; } }
    protected Status __D_ResourceError;
    public virtual Status OpenError { get { return __D_OpenError; } set { __D_OpenError = value; } }
    protected Status __D_OpenError;
    public virtual Status AbortError { get { return __D_AbortError; } set { __D_AbortError = value; } }
    protected Status __D_AbortError;
    public virtual Status TimeOutError { get { return __D_TimeOutError; } set { __D_TimeOutError = value; } }
    protected Status __D_TimeOutError;
    public virtual Status UnspecifiedError { get { return __D_UnspecifiedError; } set { __D_UnspecifiedError = value; } }
    protected Status __D_UnspecifiedError;
    public virtual Status RemoveError { get { return __D_RemoveError; } set { __D_RemoveError = value; } }
    protected Status __D_RemoveError;
    public virtual Status RenameError { get { return __D_RenameError; } set { __D_RenameError = value; } }
    protected Status __D_RenameError;
    public virtual Status PositionError { get { return __D_PositionError; } set { __D_PositionError = value; } }
    protected Status __D_PositionError;
    public virtual Status ResizeError { get { return __D_ResizeError; } set { __D_ResizeError = value; } }
    protected Status __D_ResizeError;
    public virtual Status PermissionsError { get { return __D_PermissionsError; } set { __D_PermissionsError = value; } }
    protected Status __D_PermissionsError;
    public virtual Status CopyError { get { return __D_CopyError; } set { __D_CopyError = value; } }
    protected Status __D_CopyError;

    protected virtual Status AddItem()
    {
        Status item;
        item = new Status();
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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 15; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Status Get(int index)
    {
        return (Status)this.Array.GetAt(index);
    }
}