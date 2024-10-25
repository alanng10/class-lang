namespace Avalon.List;

class Tree : Any
{
    public override bool Init()
    {
        base.Init();
        this.NodeResult = new TreeNodeResult();
        this.NodeResult.Init();

        this.DirectionValue = 1;
        return true;
    }

    public virtual Less Less { get; set; }
    private TreeNode Root { get; set; }
    private TreeNodeResult NodeResult { get; set; }
    private long DirectionValue { get; set; }

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

        TreeNodeResult t;
        t = this.Node(index);
        if (!t.HasNode)
        {
            return false;
        }

        TreeNode node;
        node = t.Node;

        this.TreeRem(node);

        this.RemoveRetrace(node);
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

        long direction;
        direction = 0;

        bool b;
        b = false;

        x = z.Parent;
        while (!b & !(x == null))
        {
            bool ba;
            ba = false;

            bool bb;
            bb = (z == x.ChildRite);
            if (bb)
            {
                direction = -this.DirectionValue;
            }
            if (!bb)
            {
                direction = this.DirectionValue;
            }

            bool bc;
            bc = (this.Sign(x.Balance) == -direction);
            if (bc)
            {
                g = x.Parent;

                bool baa;
                baa = (this.Sign(z.Balance) == direction);
                if (baa)
                {
                    n = this.RotateDouble(x, z, direction);
                }
                if (!baa)
                {
                    n = this.RotateSingle(x, z, direction);
                }
            }
            if (!bc)
            {
                if (this.Sign(x.Balance) == direction)
                {
                    x.Balance = 0;

                    b = true;
                }

                if (!b)
                {
                    x.Balance = - direction;

                    z = x;
                    
                    x = z.Parent;

                    ba = true;
                }
            }

            if (!ba)
            {
                if (!b)
                {
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
                }

                b = true;
            }
        }

        return true;
    }

    private bool RemoveRetrace(TreeNode n)
    {
        TreeNode x;
        TreeNode g;
        TreeNode Z;
        x = null;
        g = null;
        Z = null;
        
        long direction;
        direction = 0;
        long bal;
        bal = 0;

        bool b;
        b = false;

        x = n.Parent;
        while (!b & !(x == null))
        {
            bool ba;
            ba = false;

            g = x.Parent;

            bool bb;
            bb = (n == x.ChildLite);
            if (bb)
            {
                direction = - this.DirectionValue;
            }
            if (!bb)
            {
                direction = this.DirectionValue;
            }

            bool bc;
            bc = (this.Sign(x.Balance) == -direction);
            if (bc)
            {
                bool baa;
                baa = (direction == -this.DirectionValue);
                if (baa)
                {

                    Z = x.ChildRite;
                }
                if (!baa)
                {
                    Z = x.ChildLite;
                }

                bal = Z.Balance;

                bool bab;
                bab = (this.Sign(bal) == direction);
                if (bab)
                {
                    n = this.RotateDouble(x, Z, direction);
                }
                if (!bab)
                {
                    n = this.RotateSingle(x, Z, direction);
                }
            }
            if (!bc)
            {
                if (x.Balance == 0)
                {
                    x.Balance = - direction;

                    b = true;
                }

                if (!b)
                {
                    n = x;

                    n.Balance = 0;

                    x = g;

                    ba = true;
                }

            }
            
            if (!ba)
            {
                if (!b)
                {
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

    private TreeNode RotateSingle(TreeNode x, TreeNode z, long direction)
    {
        this.RotateTreeSingle(x, z, direction);

        bool b;
        b = (z.Balance == 0);
        if (b)
        {
            x.Balance = - direction;

            z.Balance = direction;
        }
        if (!b)
        { 
            x.Balance = 0;

            z.Balance = 0;
        }
        return z;
    }

    private TreeNode RotateDouble(TreeNode x, TreeNode z, long direction)
    {
        TreeNode y;
        y = this.RotateTreeDouble(x, z, direction);

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
            ba = (this.Sign(y.Balance) == -direction);

            if (ba)
            {
                x.Balance = direction;
                z.Balance = 0;
            }
            if (!ba)
            {
                x.Balance = 0;
                z.Balance = - direction;
            }
        }

        y.Balance = 0;
        return y;
    }

    private long Sign(long u)
    {
        if (u < 0)
        {
            return -this.DirectionValue;
        }

        if (0 < u)
        {
            return this.DirectionValue;
        }

        return 0;
    }

    private TreeNode RotateTreeDouble(TreeNode x, TreeNode z, long direction)
    {
        TreeNode y;
        y = null;

        bool b;
        b = (direction == -this.DirectionValue);

        if (b)
        {
            y = z.ChildLite;
        }

        if (! b)
        {
            y = z.ChildRite;
        }

        this.RotateTreeSingle(z, y, -direction);

        this.RotateTreeSingle(x, y, direction);

        TreeNode a;
        a = y;
        return a;
    }

    private bool RotateTreeSingle(TreeNode x, TreeNode z, long direction)
    {
        bool b;
        b = (direction == -this.DirectionValue);

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
        if (z.ChildLite == null)
        {
            this.SubtreeShift(z, z.ChildRite);
        }
        else if (z.ChildRite == null)
        {
            this.SubtreeShift(z, z.ChildLite);
        }
        else
        {
            TreeNode y;

            y = this.Successor(z);

            if (y.Parent != z)
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

        while ((!(y == null)) && x == y.ChildRite)
        {
            x = y;

            y = y.Parent;
        }

        return y;
    }

    private TreeNode Minimum(TreeNode x)
    {
        TreeNode t;

        t = x;

        while (!(t.ChildLite == null))
        {
            t = t.ChildLite;
        }

        return t;
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

        long t;

        object o;

        TreeNode currentNode;

        currentNode = this.Root;

        while (!b & !(currentNode == null))
        {
            o = currentNode.Index;

            t = less.Execute(index, o);

            if (t == 0)
            {
                node = currentNode;

                b = true;
            }

            if (t < 0)
            {
                parentNode = currentNode;

                parentLite = true;

                currentNode = currentNode.ChildLite;
            }

            if (0 < t)
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
