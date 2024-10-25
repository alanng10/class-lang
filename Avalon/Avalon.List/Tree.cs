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

        this.InsertRetrace(node);
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

    private bool InsertRetrace(TreeNode Z)
    {
        TreeNode X;
        TreeNode G;
        TreeNode N;
        X = null;
        G = null;
        N = null;

        long direction;
        direction = 0;

        bool b;
        b = false;

        X = Z.Parent;
        while (!b & !(X == null))
        {
            bool ba;
            ba = false;

            bool bb;
            bb = (Z == X.ChildRite);
            if (bb)
            {
                direction = -this.DirectionValue;
            }
            if (!bb)
            {
                direction = this.DirectionValue;
            }

            if (this.Sign(X.Balance) == - direction)
            {
                G = X.Parent;

                if (this.Sign(Z.Balance) == direction)
                {
                    N = this.RotateDouble(X, Z, direction);
                }
                else
                {
                    N = this.RotateSingle(X, Z, direction);
                }
            }
            else
            {
                if (this.Sign(X.Balance) == direction)
                {
                    X.Balance = 0;

                    b = true;
                }

                if (!b)
                {
                    X.Balance = - direction;

                    Z = X;
                    
                    X = Z.Parent;

                    ba = true;
                }
            }

            if (!ba)
            {
                if (!b)
                {
                    N.Parent = G;

                    if (G != null)
                    {
                        if (X == G.ChildLite)
                        {
                            G.ChildLite = N;
                        }
                        else
                        {
                            G.ChildRite = N;
                        }
                    }
                    else
                    {
                        this.Root = N;
                    }
                }

                b = true;
            }
        }

        return true;
    }

    private bool RemoveRetrace(TreeNode N)
    {
        TreeNode X;
        TreeNode G;
        TreeNode Z;
        long direction;
        long b;

        for (X = N.Parent; X != null; X = G)
        { 
            // Loop (possibly up to the root)
            G = X.Parent; // Save parent of X around rotations
                           // BF(X) has not yet been updated!
            if (N == X.ChildLite)
            {
                direction = - DirectionValue;
            }
            else
            {
                direction = + DirectionValue;
            }

            // the left subtree decreases

            if (this.Sign(X.Balance) == -direction)
            {
                // X is right-heavy
                // ==> the temporary BF(X) == +2
                // ==> rebalancing is required.

                if (direction == -DirectionValue)
                {

                    Z = X.ChildRite; // Sibling of N (higher by 2)
                }
                else
                {
                    Z = X.ChildLite; // Sibling of N (higher by 2)
                }

                b = Z.Balance;

                if (this.Sign(b) == direction)                  // Right Left Case  (see figure 3)
                {
                    N = this.RotateDouble(X, Z, direction);     // Double rotation: Right(Z) then Left(X)
                }
                else
                {
                    // Right Right Case (see figure 2)

                    N = this.RotateSingle(X, Z, direction);     // Single rotation Left(X)
                }

                // After rotation adapt parent link
            }
            else
            {
                if (X.Balance == 0)
                {
                    X.Balance = - direction; // N’s height decrease is absorbed at X.
                    break; // Leave the loop
                }

                N = X;

                N.Balance = 0; // Height(N) decreases by 1
                continue;
            }

            // After a rotation adapt parent link:
            // N is the new root of the rotated subtree
            
            N.Parent = G;

            if (G != null)
            {
                if (X == G.ChildLite)
                {
                    G.ChildLite = N;
                }
                else
                {
                    G.ChildRite = N;
                }
            }
            else
            {
                this.Root = N; // N is the new root of the total tree
            }

            if (b == 0)
            {
                break; // Height does not change: Leave the loop
            }

            // Height(N) decreases by 1 (== old Height(X)-1)
        }

        // If (b != 0) the height of the total tree decreases by 1.
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
