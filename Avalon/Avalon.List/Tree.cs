namespace Avalon.List;

class Tree : Any
{
    public override bool Init()
    {
        base.Init();
        this.NodeResult = new TreeNodeResult();
        this.NodeResult.Init();

        this.DirectValue = 1;
        return true;
    }

    public virtual Less Less { get; set; }
    private TreeNode Root { get; set; }
    private TreeNodeResult NodeResult { get; set; }
    private long DirectValue { get; set; }

    public virtual bool Ins(object index, object value)
    {
        if (index == null)
        {
            return false;
        }

        TreeNode node;
        node = this.TreeIns(index, value);
        if (node == null)
        {
            return false;
        }

        this.InsRetrace(node);
        return true;
    }

    public virtual bool Rem(object index)
    {
        if (index == null)
        {
            return false;
        }

        TreeNodeResult k;
        k = this.Node(index);
        if (!k.HasNode)
        {
            return false;
        }

        TreeNode node;
        node = k.Node;

        this.TreeRem(node);

        this.RemRetrace(node);
        return true;
    }

    public virtual bool Clear()
    {
        this.Root = null;
        return true;
    }

    private bool InsRetrace(TreeNode z)
    {
        TreeNode x;
        TreeNode g;
        TreeNode n;
        x = null;
        g = null;
        n = null;

        bool b;
        b = false;

        x = z.Parent;
        while (!b & !(x == null))
        {
            long direct;
            direct = 0;

            bool bb;
            bb = (z == x.ChildRite);
            if (bb)
            {
                direct = -this.DirectValue;
            }
            if (!bb)
            {
                direct = this.DirectValue;
            }

            bool bc;
            bc = (this.Sign(x.Balance) == -direct);
            if (bc)
            {
                g = x.Parent;

                bool baa;
                baa = (this.Sign(z.Balance) == direct);
                if (baa)
                {
                    n = this.RotateDouble(x, z, direct);
                }
                if (!baa)
                {
                    n = this.RotateSingle(x, z, direct);
                }

                n.Parent = g;

                bool bab;
                bab = (g == null);
                if (!bab)
                {
                    bool bac;
                    bac = (x == g.ChildLite);
                    if (bac)
                    {
                        g.ChildLite = n;
                    }
                    if (!bac)
                    {
                        g.ChildRite = n;
                    }
                }
                if (bab)
                {
                    this.Root = n;
                }

                b = true;
            }
            if (!bc)
            {
                bool bak;
                bak = (this.Sign(x.Balance) == direct);
                if (bak)
                {
                    x.Balance = 0;

                    b = true;
                }
                if (!bak)
                {
                    x.Balance = - direct;

                    z = x;
                    
                    x = z.Parent;
                }
            }
        }

        return true;
    }

    private bool RemRetrace(TreeNode n)
    {
        TreeNode x;
        TreeNode g;
        TreeNode z;
        x = null;
        g = null;
        z = null;

        bool b;
        b = false;

        x = n.Parent;
        while (!b & !(x == null))
        {
            long direct;
            direct = 0;

            g = x.Parent;

            bool bb;
            bb = (n == x.ChildLite);
            if (bb)
            {
                direct = - this.DirectValue;
            }
            if (!bb)
            {
                direct = this.DirectValue;
            }

            bool bc;
            bc = (this.Sign(x.Balance) == -direct);
            if (bc)
            {
                bool baa;
                baa = (direct == -this.DirectValue);
                if (baa)
                {

                    z = x.ChildRite;
                }
                if (!baa)
                {
                    z = x.ChildLite;
                }

                long bal;
                bal = z.Balance;

                bool bab;
                bab = (this.Sign(bal) == direct);
                if (bab)
                {
                    n = this.RotateDouble(x, z, direct);
                }
                if (!bab)
                {
                    n = this.RotateSingle(x, z, direct);
                }

                n.Parent = g;

                bool bac;
                bac = (g == null);
                if (!bac)
                {
                    bool bak;
                    bak = (x == g.ChildLite);
                    if (bak)
                    {
                        g.ChildLite = n;
                    }
                    if (!bak)
                    {
                        g.ChildRite = n;
                    }
                }
                if (bac)
                {
                    this.Root = n;
                }

                if (bal == 0)
                {
                    b = true;
                }
            }
            if (!bc)
            {
                bool bam;
                bam = (x.Balance == 0);
                if (bam)
                {
                    x.Balance = - direct;

                    b = true;
                }

                if (!bam)
                {
                    n = x;

                    n.Balance = 0;

                    x = g;
                }
            }
        }

        return true;
    }

    private TreeNode TreeIns(object index, object value)
    {
        TreeNodeResult k;
        k = this.Node(index);

        if (k.HasNode)
        {
            return null;
        }

        TreeNode node;
        node = new TreeNode();
        node.Init();
        node.Index = index;
        node.Value = value;
        node.Balance = 0;

        bool b;
        b = (k.ParentNode == null);

        if (b)
        {
            this.Root = node;
        }

        if (!b)
        {
            bool ba;
            ba = k.ParentLite;

            if (ba)
            {
                k.ParentNode.ChildLite = node;
            }

            if (!ba)
            {
                k.ParentNode.ChildRite = node;
            }

            node.Parent = k.ParentNode;
        }

        TreeNode a;
        a = node;
        return a;
    }

    private TreeNode RotateSingle(TreeNode x, TreeNode z, long direct)
    {
        this.RotateTreeSingle(x, z, direct);

        bool b;
        b = (z.Balance == 0);
        if (b)
        {
            x.Balance = - direct;

            z.Balance = direct;
        }
        if (!b)
        { 
            x.Balance = 0;

            z.Balance = 0;
        }
        return z;
    }

    private TreeNode RotateDouble(TreeNode x, TreeNode z, long direct)
    {
        TreeNode y;
        y = this.RotateTreeDouble(x, z, direct);

        bool b;
        b = (y.Balance == 0);

        if (b)
        {
            x.Balance = 0;
            z.Balance = 0;
        }

        if (!b)
        {
            bool ba;
            ba = (this.Sign(y.Balance) == -direct);

            if (ba)
            {
                x.Balance = direct;
                z.Balance = 0;
            }
            if (!ba)
            {
                x.Balance = 0;
                z.Balance = - direct;
            }
        }

        y.Balance = 0;
        return y;
    }

    private long Sign(long u)
    {
        if (u < 0)
        {
            return -this.DirectValue;
        }

        if (0 < u)
        {
            return this.DirectValue;
        }

        return 0;
    }

    private TreeNode RotateTreeDouble(TreeNode x, TreeNode z, long direct)
    {
        TreeNode y;
        y = null;

        bool b;
        b = (direct == -this.DirectValue);

        if (b)
        {
            y = z.ChildLite;
        }

        if (!b)
        {
            y = z.ChildRite;
        }

        this.RotateTreeSingle(z, y, -direct);

        this.RotateTreeSingle(x, y, direct);

        TreeNode a;
        a = y;
        return a;
    }

    private bool RotateTreeSingle(TreeNode x, TreeNode z, long direct)
    {
        bool b;
        b = (direct == -this.DirectValue);

        if (b)
        {
            this.RotateTreeLite(x, z);
        }

        if (!b)
        {
            this.RotateTreeRite(x, z);
        }

        return true;
    }

    private bool RotateTreeLite(TreeNode x, TreeNode z)
    {
        TreeNode t23;

        t23 = z.ChildLite;

        x.ChildRite = t23;

        if (!(t23 == null))
        {
            t23.Parent = x;
        }
        
        z.ChildLite = x;

        x.Parent = z;
        return true;
    }

    private bool RotateTreeRite(TreeNode x, TreeNode z)
    {
        TreeNode t23;

        t23 = z.ChildRite;

        x.ChildLite = t23;

        if (!(t23 == null))
        {
            t23.Parent = x;
        }
        
        z.ChildRite = x;

        x.Parent = z;
        return true;
    }

    private bool TreeRem(TreeNode z)
    {
        bool b;
        b = false;

        if (!b)
        {
            if (z.ChildLite == null)
            {
                this.SubtreeShift(z, z.ChildRite);

                b = true;
            }
        }
        
        if (!b)
        {
            if (z.ChildRite == null)
            {
                this.SubtreeShift(z, z.ChildLite);

                b = true;
            }
        }
        
        if (!b)
        {
            TreeNode y;

            y = this.Successor(z);

            if (!(y.Parent == z))
            {
                this.SubtreeShift(y, y.ChildRite);

                y.ChildRite = z.ChildRite;

                y.ChildRite.Parent = y;
            }

            this.SubtreeShift(z, y);

            y.ChildLite = z.ChildLite;

            y.ChildLite.Parent = y;
        }

        return true;
    }

    private bool SubtreeShift(TreeNode u, TreeNode v)
    {
        bool b;
        b = false;
        
        if (!b)
        {
            if (u.Parent == null)
            {
                this.Root = v;

                b = true;
            }
        }
        if (!b)
        {
            if (u == u.Parent.ChildLite)
            {
                u.Parent.ChildLite = v;
            
                b = true;
            }
        }
        if (!b)
        {
            u.Parent.ChildRite = v;
        }

        if (!(v == null))
        {
            v.Parent = u.Parent;
        }

        return true;
    }

    private TreeNode Successor(TreeNode x)
    {
        if (!(x.ChildRite == null))
        {
            return this.Minimum(x.ChildRite);
        }

        TreeNode y;

        y = x.Parent;

        bool b;
        b = false;

        while (!b & !(y == null))
        {
            if (!(x == y.ChildRite))
            {
                b = true;
            }

            if (!b)
            {
                x = y;

                y = y.Parent;
            }
        }

        return y;
    }

    private TreeNode Minimum(TreeNode x)
    {
        TreeNode k;

        k = x;

        while (!(k.ChildLite == null))
        {
            k = k.ChildLite;
        }

        return k;
    }

    public virtual TreeNodeResult Node(object index)
    {
        Less less;
        less = this.Less;

        TreeNode node;
        node = null;

        TreeNode parentNode;
        parentNode = null;

        bool parentLite;
        parentLite = false;

        bool b;
        b = false;

        TreeNode currentNode;

        currentNode = this.Root;

        while (!b & !(currentNode == null))
        {
            object o;

            o = currentNode.Index;

            long k;

            k = less.Execute(index, o);

            if (k == 0)
            {
                node = currentNode;

                b = true;
            }

            if (k < 0)
            {
                parentNode = currentNode;

                parentLite = true;

                currentNode = currentNode.ChildLite;
            }

            if (0 < k)
            {
                parentNode = currentNode;

                parentLite = false;

                currentNode = currentNode.ChildRite;
            }
        }

        TreeNodeResult u;

        u = this.NodeResult;

        u.HasNode = b;

        u.Node = node;

        u.ParentNode = parentNode;

        u.ParentLite = parentLite;

        TreeNodeResult a;
        a = u;
        return a;
    }
}
