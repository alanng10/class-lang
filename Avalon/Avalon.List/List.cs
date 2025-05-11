namespace Avalon.List;

public class List : Any
{
    public override bool Init()
    {
        base.Init();
        this.NodeRef = new ListNodeRef();
        this.NodeRef.Init();
        return true;
    }

    public virtual long Count { get; set; }

    public virtual object Start
    {
        get
        {
            return this.FirstNode;
        }
        set
        {
        }
    }

    public virtual object End
    {
        get
        {
            return this.LastNode;
        }
        set
        {
        }
    }
    private ListNode FirstNode { get; set; }
    private ListNode LastNode { get; set; }
    private ListNodeRef NodeRef { get; set; }

    public virtual object Add(object item)
    {
        ListNode node;
        node = new ListNode();
        node.Init();
        node.Ref = this.NodeRef;
        node.Value = item;

        if (!(this.LastNode == null))
        {
            node.Prev = this.LastNode;
            this.LastNode.Next = node;
        }

        if (this.FirstNode == null)
        {
            this.FirstNode = node;
        }

        this.LastNode = node;

        this.Count = this.Count + 1;

        object a;
        a = node;
        return a;
    }

    public virtual object Ins(object index, object item)
    {
        if (index == null)
        {
            return null;
        }

        ListNode t;
        t = this.Node(index);
        if (t == null)
        {
            return null;
        }

        ListNode node;
        node = new ListNode();
        node.Init();
        node.Ref = this.NodeRef;
        node.Value = item;

        if (this.FirstNode == t)
        {
            this.FirstNode = node;
        }

        if (!(t.Prev == null))
        {
            t.Prev.Next = node;
            node.Prev = t.Prev;
        }

        node.Next = t;
        t.Prev = node;

        this.Count = this.Count + 1;

        object a;
        a = node;
        return a;
    }

    public virtual bool Rem(object index)
    {
        if (index == null)
        {
            return false;
        }
        ListNode node;
        node = this.Node(index);
        if (node == null)
        {
            return false;
        }

        if (this.FirstNode == node)
        {
            this.FirstNode = node.Next;
        }

        if (this.LastNode == node)
        {
            this.LastNode = node.Prev;
        }

        if (!(node.Next == null))
        {
            node.Next.Prev = node.Prev;
        }

        if (!(node.Prev == null))
        {
            node.Prev.Next = node.Next;
        }

        node.Ref = null;

        this.Count = this.Count - 1;
        return true;
    }

    public virtual bool Clear()
    {
        this.FirstNode = null;
        this.LastNode = null;

        this.Count = 0;

        this.NodeRef = new ListNodeRef();
        this.NodeRef.Init();
        return true;
    }

    public virtual bool Valid(object index)
    {
        if (index == null)
        {
            return false;
        }
        ListNode node;
        node = this.Node(index);
        if (node == null)
        {
            return false;
        }
        return true;
    }

    public virtual object Get(object index)
    {
        if (index == null)
        {
            return null;
        }
        ListNode node;
        node = this.Node(index);
        if (node == null)
        {
            return null;
        }

        object a;
        a = node.Value;
        return a;
    }

    public virtual bool Set(object index, object value)
    {
        if (index == null)
        {
            return false;
        }
        ListNode node;
        node = this.Node(index);
        if (node == null)
        {
            return false;
        }
        node.Value = value;
        return true;
    }

    public virtual Iter IterCreate()
    {
        Iter a;
        a = new Iter();
        a.Init();
        return a;
    }

    public virtual bool IterSet(Iter iter)
    {
        iter.CurrentNode = null;
        iter.Node = this.FirstNode;
        return true;
    }

    private ListNode Node(object index)
    {
        ListNode node;
        node = index as ListNode;

        if (node == null)
        {
            return null;
        }

        bool b;
        b = (node.Ref == this.NodeRef);
        if (!b)
        {
            return null;
        }

        ListNode a;
        a = node;
        return a;
    }
}