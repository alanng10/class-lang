class List : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.NodeRef : new ListNodeRef;
        this.NodeRef.Init();
        return true;
    }

    field prusate Int Count { get { return data; } set { data : value; } }
    field prusate Any Start
    {
        get
        {
            return this.FirstNode;
        }
        set
        {
        }
    }
    field prusate Any End
    {
        get
        {
            return this.LastNode;
        }
        set
        {
        }
    }
    field private ListNode FirstNode { get { return data; } set { data : value; } }
    field private ListNode LastNode { get { return data; } set { data : value; } }
    field private ListNodeRef NodeRef { get { return data; } set { data : value; } }

    maide prusate Any Add(var Any item)
    {
        var ListNode node;
        node : new ListNode;
        node.Init();
        node.Ref : this.NodeRef;
        node.Value : item;

        inf (~(this.LastNode = null))
        {
            node.Prev : this.LastNode;
            this.LastNode.Next : node;
        }

        inf (this.FirstNode = null)
        {
            this.FirstNode : node;
        }

        this.LastNode : node;

        this.Count : this.Count + 1;

        var Any a;
        a : node;
        return a;
    }

    maide prusate Any Ins(var Any index, var Any item)
    {
        inf (index = null)
        {
            return null;
        }

        var ListNode t;
        t : this.Node(index);
        inf (t = null)
        {
            return null;
        }

        var ListNode node;
        node : new ListNode;
        node.Init();
        node.Ref : this.NodeRef;
        node.Value : item;

        inf (this.FirstNode = t)
        {
            this.FirstNode : node;
        }

        inf (~(t.Prev = null))
        {
            t.Prev.Next : node;
            node.Prev : t.Prev;
        }

        node.Next : t;
        t.Prev : node;

        this.Count : this.Count + 1;

        var Any a;
        a : node;
        return a;
    }

    maide prusate Bool Rem(var Any index)
    {
        inf (index = null)
        {
            return false;
        }
        var ListNode node;
        node : this.Node(index);
        inf (node = null)
        {
            return false;
        }

        inf (this.FirstNode = node)
        {
            this.FirstNode : node.Next;
        }

        inf (this.LastNode = node)
        {
            this.LastNode : node.Prev;
        }

        inf (~(node.Next = null))
        {
            node.Next.Prev : node.Prev;
        }

        inf (~(node.Prev = null))
        {
            node.Prev.Next : node.Next;
        }

        node.Ref : null;

        this.Count : this.Count - 1;
        return true;
    }

    maide prusate Bool Clear()
    {
        this.FirstNode : null;
        this.LastNode : null;

        this.Count : 0;

        this.NodeRef : new ListNodeRef;
        this.NodeRef.Init();
        return true;
    }

    maide prusate Bool Valid(var Any index)
    {
        inf (index = null)
        {
            return false;
        }
        var ListNode node;
        node : this.Node(index);
        inf (node = null)
        {
            return false;
        }
        return true;
    }

    maide prusate Any Get(var Any index)
    {
        inf (index = null)
        {
            return null;
        }
        var ListNode node;
        node : this.Node(index);
        inf (node = null)
        {
            return null;
        }

        var Any a;
        a : node.Value;
        return a;
    }

    maide prusate Bool Set(var Any index, var Any value)
    {
        inf (index = null)
        {
            return false;
        }
        var ListNode node;
        node : this.Node(index);
        inf (node = null)
        {
            return false;
        }
        node.Value : value;
        return true;
    }

    maide prusate Iter IterCreate()
    {
        var Iter a;
        a : new Iter;
        a.Init();
        return a;
    }

    maide prusate Bool IterSet(var Iter iter)
    {
        iter.CurrentNode : null;
        iter.Node : this.FirstNode;
        return true;
    }

    maide private ListNode Node(var Any index)
    {
        var ListNode node;
        node : cast ListNode(index);

        inf (node = null)
        {
            return null;
        }

        var Bool b;
        b : (node.Ref = this.NodeRef);
        inf (~b)
        {
            return null;
        }

        var ListNode a;
        a : node;
        return a;
    }
}