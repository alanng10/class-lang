class Table : List
{
    maide prusate Bool Init()
    {
        this.Tree : new Tree;
        this.Tree.Less : this.Less;
        this.Tree.Init();
        this.List : new List;
        this.List.Init();

        this.Count : this.List.Count;
        return true;
    }

    field prusate Less Less { get { return data; } set { data : value; } }
    field prusate Any Start { get { } set { } }
    field prusate Any End { get { } set { } }
    field private Tree Tree { get { return data; } set { data : value; } }
    field private List List { get { return data; } set { data : value; } }

    maide prusate Any Get(var Any index)
    {
        var ListNode node;
        node : this.ListNode(index);
        inf (node = null)
        {
            return null;
        }

        var Entry entry;
        entry : cast Entry(node.Value);
        var Any a;
        a : entry.Value;
        return a;
    }

    maide prusate Bool Set(var Any index, var Any value)
    {
        var ListNode node;
        node : this.ListNode(index);
        inf (node = null)
        {
            return false;
        }

        var Entry entry;
        entry : cast Entry(node.Value);
        entry.Value : value;
        return true;
    }

    maide prusate Any Add(var Any item)
    {
        var Entry entry;
        entry : this.Entry(item);
        inf (entry = null)
        {
            return null;
        }

        inf (entry.Index = null)
        {
            return null;
        }

        var ListNode u;
        u : this.ListNode(entry.Index);
        inf (~(u = null))
        {
            return null;
        }

        var Any k;
        k : this.List.Add(entry);

        this.Tree.Ins(entry.Index, k);

        this.Count : this.List.Count;

        var Any a;
        a : entry.Index;
        return a;
    }

    maide prusate Any Ins(var Any index, var Any item)
    {
        var ListNode node;
        node : this.ListNode(index);
        inf (node = null)
        {
            return null;
        }

        var Entry entry;
        entry : this.Entry(item);
        inf (entry = null)
        {
            return null;
        }

        inf (entry.Index = null)
        {
            return null;
        }

        var ListNode u;
        u : this.ListNode(entry.Index);
        inf (~(u = null))
        {
            return null;
        }

        var Any k;
        k : this.List.Ins(node, entry);

        this.Tree.Ins(entry.Index, k);

        this.Count : this.List.Count;

        var Any a;
        a : entry.Index;
        return a;
    }

    maide prusate Bool Rem(var Any index)
    {
        var ListNode node;
        node : this.ListNode(index);
        inf (node = null)
        {
            return false;
        }

        this.List.Rem(node);

        this.Tree.Rem(index);

        this.Count : this.List.Count;
        return true;
    }

    maide prusate Bool Clear()
    {
        this.Tree.Clear();

        this.List.Clear();

        this.Count : this.List.Count;
        return true;
    }

    maide prusate Bool Valid(var Any index)
    {
        var ListNode node;
        node : this.ListNode(index);
        var Bool b;
        b : ~(node = null);

        var Bool a;
        a : b;
        return a;
    }

    maide prusate Iter IterCreate()
    {
        var TableIter k;
        k : new TableIter;
        k.Init();
        var Iter a;
        a : k;
        return a;
    }

    maide prusate Bool IterSet(var Iter iter)
    {
        var TableIter a;
        a : cast TableIter(iter);
        this.List.IterSet(a.ListIter);
        return true;
    }

    maide private ListNode ListNode(var Any index)
    {
        inf (index = null)
        {
            return null;
        }

        var TreeNodeResult k;
        k : this.Tree.Node(index);
        inf (~k.HasNode)
        {
            return null;
        }

        var ListNode listNode;
        listNode : cast ListNode(k.Node.Value);
        var ListNode a;
        a : listNode;
        return a;
    }

    maide private Entry Entry(var Any item)
    {
        inf (item = null)
        {
            return null;
        }

        var Entry entry;
        entry : cast Entry(item);

        var Entry a;
        a : entry;
        return a;
    }
}