class Iter : Any
{
    field pronate ListNode CurrentNode { get { return data; } set { data : value; } }
    field pronate ListNode Node { get { return data; } set { data : value; } }

    maide prusate Bool Next()
    {
        var ListNode node;
        node : this.Node;
        inf (node = null)
        {
            return false;
        }
        this.CurrentNode : node;
        this.Node : node.Next;
        return true;
    }

    field prusate Any Index
    {
        get
        {
            return this.CurrentNode;
        }
        set
        {
        }
    }

    field prusate Any Value
    {
        get
        {
            return this.CurrentNode.Value;
        }
        set
        {
        }
    }

    maide prusate Bool Clear()
    {
        this.CurrentNode : null;
        this.Node : null;
        return true;
    }
}