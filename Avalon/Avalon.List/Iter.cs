namespace Avalon.List;

public class Iter : Any
{
    internal virtual ListNode CurrentNode { get; set; }
    internal virtual ListNode Node { get; set; }

    public virtual bool Next()
    {
        if (this.Node == null)
        {
            return false;
        }
        this.CurrentNode = this.Node;
        this.Node = this.Node.Next;
        return true;
    }

    public virtual object Index
    {
        get
        {
            return this.CurrentNode;
        }
        set
        {
        }
    }
    protected object __D_Index;

    public virtual object Value
    {
        get
        {
            return this.CurrentNode.Value;
        }
        set
        {
        }
    }
    protected object __D_Value;
}