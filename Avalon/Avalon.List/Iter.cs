namespace Avalon.List;

public class Iter : Any
{
    internal virtual ListNode CurrentNode { get; set; }
    internal virtual ListNode Node { get; set; }

    public virtual bool Next()
    {
        ListNode node;
        node = this.Node;
        if (node == null)
        {
            return false;
        }
        this.CurrentNode = node;
        this.Node = node.Next;
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
}