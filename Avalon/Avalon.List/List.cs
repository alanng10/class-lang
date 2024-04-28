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

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    public virtual object FirstIndex
    {
        get
        {
            return this.First;
        }
        set
        {
        }
    }
    public virtual object LastIndex
    {
        get
        {
            return this.Last;
        }
        set
        {
        }
    }
    private ListNode First { get; set; }
    private ListNode Last { get; set; }
    private ListNodeRef NodeRef { get; set; }

    public virtual object Add(object item)
    {
        ListNode node;
        node = new ListNode();
        node.Init();
        node.Ref = this.NodeRef;
        node.Value = item;

        if (!(this.Last == null))
        {
            node.Previous = this.Last;
            this.Last.Next = node;
        }

        if (this.First == null)
        {
            this.First = node;
        }
        
        this.Last = node;

        this.Count = this.Count + 1;

        object ret;
        ret = node;
        return ret;
    }

    public virtual object Insert(object index, object item)
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

        if (this.First == t)
        {
            this.First = node;
        }

        if (!(t.Previous == null))
        {
            t.Previous.Next = node;
            node.Previous = t.Previous;
        }

        node.Next = t;
        t.Previous = node;

        this.Count = this.Count + 1;

        object ret;
        ret = node;
        return ret;
    }

    public virtual bool Remove(object index)
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

        if (this.First == node)
        {
            this.First = node.Next;
        }

        if (this.Last == node)
        {
            this.Last = node.Previous;
        }

        if (!(node.Next == null))
        {
            node.Next.Previous = node.Previous;
        }

        if (!(node.Previous == null))
        {
            node.Previous.Next = node.Next;
        }

        node.Ref = null;

        this.Count = this.Count - 1;
        return true;
    }

    public virtual bool Clear()
    {
        this.First = null;
        this.Last = null;

        this.Count = 0;

        this.NodeRef = new ListNodeRef();
        this.NodeRef.Init();
        return true;
    }

    public virtual bool Contain(object index)
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

        object t;
        t = node.Value;
        object ret;
        ret = t;
        return ret;
    }

    public virtual bool Set(object index, object value)
    {
        if (index == null)
        {
            return true;
        }
        ListNode node;
        node = this.Node(index);
        if (node == null)
        {
            return true;
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
        iter.Node = this.First;
        return true;
    }

    private ListNode Node(object index)
    {
        bool b;
        b = (index is ListNode);
        if (!b)
        {
            return null;
        }

        ListNode node;
        node = (ListNode)index;

        bool bb;
        bb = (node.Ref == this.NodeRef);
        if (!bb)
        {
            return null;
        }

        ListNode ret;
        ret = node;
        return ret;
    }
}