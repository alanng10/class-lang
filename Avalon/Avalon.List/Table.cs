namespace Avalon.List;

public class Table : List
{
    public override bool Init()
    {
        this.Tree = new Tree();
        this.Tree.Less = this.Less;
        this.Tree.Init();
        this.List = new List();
        this.List.Init();
        return true;
    }

    public virtual Less Less { get; set; }
    public override object Start
    { 
        get
        {
            object value;
            value = this.List.Get(this.List.Start);

            Entry entry;
            entry = this.Entry(value);

            if (entry == null)
            {
                return null;
            }

            object a;
            a = entry.Index;
            return a;
        }
        set
        {
        }
    }
    public override object End
    {
        get
        {
            object value;
            value = this.List.Get(this.List.End);

            Entry entry;
            entry = this.Entry(value);

            if (entry == null)
            {
                return null;
            }

            object a;
            a = entry.Index;
            return a;
        }
        set
        {
        }
    }
    private Tree Tree { get; set; }
    private List List { get; set; }

    public override object Get(object index)
    {
        ListNode node;
        node = this.ListNode(index);
        if (node == null)
        {
            return null;
        }

        Entry entry;
        entry = (Entry)node.Value;
        object a;
        a = entry.Value;
        return a;
    }

    public override bool Set(object index, object value)
    {
        ListNode node;
        node = this.ListNode(index);
        if (node == null)
        {
            return false;
        }

        Entry entry;
        entry = (Entry)node.Value;
        entry.Value = value;
        return true;
    }

    public override object Add(object item)
    {
        Entry entry;
        entry = this.Entry(item);
        if (entry == null)
        {
            return null;
        }

        if (entry.Index == null)
        {
            return null;
        }

        ListNode u;
        u = this.ListNode(entry.Index);
        if (!(u == null))
        {
            return null;
        }

        object k;
        k = this.List.Add(entry);

        this.Tree.Ins(entry.Index, k);

        this.Count = this.List.Count;

        object a;
        a = entry.Index;
        return a;
    }

    public override object Ins(object index, object item)
    {
        ListNode node;
        node = this.ListNode(index);
        if (node == null)
        {
            return null;
        }

        Entry entry;
        entry = this.Entry(item);
        if (entry == null)
        {
            return null;
        }

        if (entry.Index == null)
        {
            return null;
        }

        ListNode u;
        u = this.ListNode(entry.Index);
        if (!(u == null))
        {
            return null;
        }

        object k;
        k = this.List.Ins(node, entry);

        this.Tree.Ins(entry.Index, k);

        this.Count = this.List.Count;

        object a;
        a = entry.Index;
        return a;
    }

    public override bool Rem(object index)
    {
        ListNode node;
        node = this.ListNode(index);
        if (node == null)
        {
            return false;
        }

        this.List.Rem(node);

        this.Tree.Rem(index);

        this.Count = this.List.Count;
        return true;
    }

    public override bool Clear()
    {
        this.Tree.Clear();

        this.List.Clear();

        this.Count = this.List.Count;
        return true;
    }

    public override bool Valid(object index)
    {
        ListNode node;
        node = this.ListNode(index);
        bool b;
        b = !(node == null);

        bool a;
        a = b;
        return a;
    }

    public override Iter IterCreate()
    {
        TableIter k;
        k = new TableIter();
        k.Init();
        Iter a;
        a = k;
        return a;
    }

    public override bool IterSet(Iter iter)
    {
        TableIter a;
        a = (TableIter)iter;
        this.List.IterSet(a.ListIter);
        return true;
    }

    private ListNode ListNode(object index)
    {
        if (index == null)
        {
            return null;
        }

        TreeNodeResult k;
        k = this.Tree.Node(index);
        if (!k.HasNode)
        {
            return null;
        }

        ListNode listNode;
        listNode = k.Node.Value as ListNode;
        ListNode a;
        a = listNode;
        return a;
    }

    private Entry Entry(object item)
    {
        if (item == null)
        {
            return null;
        }

        Entry entry;
        entry = item as Entry;

        Entry a;
        a = entry;
        return a;
    }
}