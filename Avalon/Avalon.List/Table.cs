namespace Avalon.List;

public class Table : List
{
    public override bool Init()
    {
        this.Tree = new Tree();
        this.Tree.Compare = this.Compare;
        this.Tree.Init();
        this.List = new List();
        this.List.Init();
        return true;
    }

    public virtual Compare Compare { get { return __D_Compare; } set { __D_Compare = value; } }
    protected Compare __D_Compare;
    public override object FirstIndex { get { return null; } set { } }
    public override object LastIndex { get { return null; } set { } }

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
        object ret;
        ret = entry.Value;
        return ret;
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

        ListNode u;
        u = this.ListNode(entry.Index);
        if (!(u == null))
        {
            return null;
        }

        object o;
        o = this.List.Add(entry);
        ListNode node;
        node = (ListNode)o;

        this.Tree.Insert(entry.Index, node);

        this.Count = this.List.Count;

        object ret;
        ret = entry.Index;
        return ret;
    }

    public override object Insert(object index, object item)
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

        ListNode u;
        u = this.ListNode(entry.Index);
        if (!(u == null))
        {
            return null;
        }
        if (entry.Index == null)
        {
            return null;
        }

        object o;
        o = this.List.Insert(node, entry);
        ListNode oo;
        oo = (ListNode)o;

        this.Tree.Insert(entry.Index, oo);

        this.Count = this.List.Count;

        object ret;
        ret = entry.Index;
        return ret;
    }

    public override bool Remove(object index)
    {
        ListNode node;
        node = this.ListNode(index);
        if (node == null)
        {
            return false;
        }

        this.List.Remove(node);

        this.Tree.Remove(index);

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

    public override bool Contain(object index)
    {
        ListNode node;
        node = this.ListNode(index);
        bool b;
        b = !(node == null);

        bool ret;
        ret = b;
        return ret;
    }

    public override Iter IterCreate()
    {
        TableIter aa;
        aa = new TableIter();
        aa.Init();
        aa.ListIter = this.List.IterCreate();
        Iter a;
        a = aa;
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

        TreeNodeResult t;
        t = this.Tree.Node(index);
        if (!t.HasNode)
        {
            return null;
        }

        ListNode listNode;
        listNode = (ListNode)t.Node.Value;
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
        
        bool b;
        b = item is Entry;
        if (!b)
        {
            return null;
        }

        Entry entry;
        entry = (Entry)item;

        Entry a;
        a = entry;
        return a;
    }
}