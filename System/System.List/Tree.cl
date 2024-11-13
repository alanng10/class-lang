class Tree : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.NodeResult : new TreeNodeResult;
        this.NodeResult.Init();

        this.DirectValue : 1;
        return true;
    }

    field prusate Less Less { get { return data; } set { data : value; } }
    field private TreeNode Root { get { return data; } set { data : value; } }
    field private TreeNodeResult NodeResult { get { return data; } set { data : value; } }
    field private Int DirectValue { get { return data; } set { data : value; } }

    maide prusate Bool Ins(var Any index, var Any value)
    {
        inf (index = null)
        {
            return false;
        }

        var TreeNode node;
        node : this.TreeIns(index, value);
        inf (node = null)
        {
            return false;
        }

        this.InsRetrace(node);
        return true;
    }

    maide prusate Bool Rem(var Any index)
    {
        inf (index = null)
        {
            return false;
        }

        var TreeNodeResult k;
        k : this.Node(index);
        inf (~k.HasNode)
        {
            return false;
        }

        var TreeNode node;
        node : k.Node;

        this.TreeRem(node);

        this.RemRetrace(node);
        return true;
    }

    maide prusate Bool Clear()
    {
        this.Root : null;
        return true;
    }

    maide private Bool InsRetrace(var TreeNode z)
    {
        var TreeNode x;
        var TreeNode g;
        var TreeNode n;

        var Bool b;
        b : false;

        x : z.Parent;
        while (~b & ~(x = null))
        {
            var Int direct;

            var Bool bb;
            bb : (z = x.ChildRite);
            inf (bb)
            {
                direct : 0 - this.DirectValue;
            }
            inf (~bb)
            {
                direct : this.DirectValue;
            }

            var Bool bc;
            bc : (this.Sign(x.Balance) = 0 - direct);
            inf (bc)
            {
                g : x.Parent;

                var Bool baa;
                baa : (this.Sign(z.Balance) = direct);
                inf (baa)
                {
                    n : this.RotateDouble(x, z, direct);
                }
                inf (~baa)
                {
                    n : this.RotateSingle(x, z, direct);
                }

                n.Parent : g;

                var Bool bab;
                bab : (g = null);
                inf (~bab)
                {
                    var Bool bac;
                    bac : (x = g.ChildLite);
                    inf (bac)
                    {
                        g.ChildLite : n;
                    }
                    inf (~bac)
                    {
                        g.ChildRite : n;
                    }
                }
                inf (bab)
                {
                    this.Root : n;
                }

                b : true;
            }
            inf (~bc)
            {
                var Bool bak;
                bak : (this.Sign(x.Balance) = direct);
                inf (bak)
                {
                    x.Balance : 0;

                    b : true;
                }
                inf (~bak)
                {
                    x.Balance : 0 - direct;

                    z : x;
                    
                    x : z.Parent;
                }
            }
        }

        return true;
    }

    maide private Bool RemRetrace(var TreeNode n)
    {
        var TreeNode x;
        var TreeNode g;
        var TreeNode z;

        var Bool b;
        b : false;

        x : n.Parent;
        while (~b & ~(x = null))
        {
            var Int direct;

            g : x.Parent;

            var Bool bb;
            bb : (n = x.ChildLite);
            inf (bb)
            {
                direct : 0 - this.DirectValue;
            }
            inf (~bb)
            {
                direct : this.DirectValue;
            }

            var Bool bc;
            bc : (this.Sign(x.Balance) = 0 - direct);
            inf (bc)
            {
                var Bool baa;
                baa : (direct = 0 - this.DirectValue);
                inf (baa)
                {

                    z : x.ChildRite;
                }
                inf (~baa)
                {
                    z : x.ChildLite;
                }

                var Int bal;
                bal : z.Balance;

                var Bool bab;
                bab : (this.Sign(bal) = direct);
                inf (bab)
                {
                    n : this.RotateDouble(x, z, direct);
                }
                inf (~bab)
                {
                    n : this.RotateSingle(x, z, direct);
                }

                n.Parent : g;

                var Bool bac;
                bac : (g = null);
                inf (~bac)
                {
                    var Bool bak;
                    bak : (x = g.ChildLite);
                    inf (bak)
                    {
                        g.ChildLite : n;
                    }
                    inf (~bak)
                    {
                        g.ChildRite : n;
                    }
                }
                inf (bac)
                {
                    this.Root : n;
                }

                inf (bal = 0)
                {
                    b : true;
                }
            }
            inf (~bc)
            {
                var Bool bam;
                bam : (x.Balance = 0);
                inf (bam)
                {
                    x.Balance : 0 - direct;

                    b : true;
                }

                inf (~bam)
                {
                    n : x;

                    n.Balance : 0;

                    x : g;
                }
            }
        }

        return true;
    }

    maide private TreeNode TreeIns(var Any index, var Any value)
    {
        var TreeNodeResult k;
        k : this.Node(index);

        inf (k.HasNode)
        {
            return null;
        }

        var TreeNode node;
        node : new TreeNode;
        node.Init();
        node.Index : index;
        node.Value : value;
        node.Balance : 0;

        var Bool b;
        b : (k.ParentNode = null);

        inf (b)
        {
            this.Root : node;
        }

        inf (~b)
        {
            var Bool ba;
            ba : k.ParentLite;

            inf (ba)
            {
                k.ParentNode.ChildLite : node;
            }

            inf (~ba)
            {
                k.ParentNode.ChildRite : node;
            }

            node.Parent : k.ParentNode;
        }

        var TreeNode a;
        a : node;
        return a;
    }

    maide private TreeNode RotateSingle(var TreeNode x, var TreeNode z, var Int direct)
    {
        this.RotateTreeSingle(x, z, direct);

        var Bool b;
        b : (z.Balance = 0);
        inf (b)
        {
            x.Balance : 0 - direct;

            z.Balance : direct;
        }
        inf (~b)
        { 
            x.Balance : 0;

            z.Balance : 0;
        }
        return z;
    }

    maide private TreeNode RotateDouble(var TreeNode x, var TreeNode z, var Int direct)
    {
        var TreeNode y;
        y : this.RotateTreeDouble(x, z, direct);

        var Bool b;
        b : (y.Balance = 0);

        inf (b)
        {
            x.Balance : 0;
            z.Balance : 0;
        }

        inf (~b)
        {
            var Bool ba;
            ba : (this.Sign(y.Balance) = 0 - direct);

            inf (ba)
            {
                x.Balance : direct;
                z.Balance : 0;
            }
            inf (~ba)
            {
                x.Balance : 0;
                z.Balance : 0 - direct;
            }
        }

        y.Balance : 0;
        return y;
    }

    maide private Int Sign(var Int u)
    {
        inf (sign <(u, 0))
        {
            return 0 - this.DirectValue;
        }

        inf (sign <(0, u))
        {
            return this.DirectValue;
        }

        return 0;
    }

    maide private TreeNode RotateTreeDouble(var TreeNode x, var TreeNode z, var Int direct)
    {
        var TreeNode y;

        var Bool b;
        b : (direct = 0 - this.DirectValue);

        inf (b)
        {
            y : z.ChildLite;
        }

        inf (~b)
        {
            y : z.ChildRite;
        }

        this.RotateTreeSingle(z, y, 0 - direct);

        this.RotateTreeSingle(x, y, direct);

        var TreeNode a;
        a : y;
        return a;
    }

    maide private Bool RotateTreeSingle(var TreeNode x, var TreeNode z, var Int direct)
    {
        var Bool b;
        b : (direct = 0 - this.DirectValue);

        inf (b)
        {
            this.RotateTreeLite(x, z);
        }

        inf (~b)
        {
            this.RotateTreeRite(x, z);
        }

        return true;
    }

    maide private Bool RotateTreeLite(var TreeNode x, var TreeNode z)
    {
        var TreeNode t23;

        t23 : z.ChildLite;

        x.ChildRite : t23;

        inf (~(t23 = null))
        {
            t23.Parent : x;
        }
        
        z.ChildLite : x;

        x.Parent : z;
        return true;
    }

    maide private Bool RotateTreeRite(var TreeNode x, var TreeNode z)
    {
        var TreeNode t23;

        t23 : z.ChildRite;

        x.ChildLite : t23;

        inf (~(t23 = null))
        {
            t23.Parent : x;
        }
        
        z.ChildRite : x;

        x.Parent : z;
        return true;
    }

    maide private Bool TreeRem(var TreeNode z)
    {
        var Bool b;
        b : false;

        inf (~b)
        {
            inf (z.ChildLite = null)
            {
                this.SubtreeShift(z, z.ChildRite);

                b : true;
            }
        }
        
        inf (~b)
        {
            inf (z.ChildRite = null)
            {
                this.SubtreeShift(z, z.ChildLite);

                b : true;
            }
        }
        
        inf (~b)
        {
            var TreeNode y;

            y : this.Successor(z);

            inf (~(y.Parent = z))
            {
                this.SubtreeShift(y, y.ChildRite);

                y.ChildRite : z.ChildRite;

                y.ChildRite.Parent : y;
            }

            this.SubtreeShift(z, y);

            y.ChildLite : z.ChildLite;

            y.ChildLite.Parent : y;
        }

        return true;
    }

    maide private Bool SubtreeShift(var TreeNode u, var TreeNode v)
    {
        var Bool b;
        b : false;
        
        inf (~b)
        {
            inf (u.Parent = null)
            {
                this.Root : v;

                b : true;
            }
        }
        inf (~b)
        {
            inf (u = u.Parent.ChildLite)
            {
                u.Parent.ChildLite : v;
            
                b : true;
            }
        }
        inf (~b)
        {
            u.Parent.ChildRite : v;
        }

        inf (~(v = null))
        {
            v.Parent : u.Parent;
        }

        return true;
    }

    maide private TreeNode Successor(var TreeNode x)
    {
        inf (~(x.ChildRite = null))
        {
            return this.Minimum(x.ChildRite);
        }

        var TreeNode y;

        y : x.Parent;

        var Bool b;
        b : false;

        while (~b & ~(y = null))
        {
            inf (~(x = y.ChildRite))
            {
                b : true;
            }

            inf (~b)
            {
                x : y;

                y : y.Parent;
            }
        }

        return y;
    }

    maide private TreeNode Minimum(var TreeNode x)
    {
        var TreeNode k;

        k : x;

        while (~(k.ChildLite = null))
        {
            k : k.ChildLite;
        }

        return k;
    }

    maide prusate TreeNodeResult Node(var Any index)
    {
        var Less less;
        less : this.Less;

        var TreeNode node;

        var TreeNode parentNode;

        var Bool parentLite;
        parentLite : false;

        var Bool b;
        b : false;

        var TreeNode currentNode;

        currentNode : this.Root;

        while (~b & ~(currentNode = null))
        {
            var Any o;

            o : currentNode.Index;

            var Int k;

            k : less.Execute(index, o);

            inf (k = 0)
            {
                node : currentNode;

                b : true;
            }

            inf (sign <(k, 0))
            {
                parentNode : currentNode;

                parentLite : true;

                currentNode : currentNode.ChildLite;
            }

            inf (sign <(0, k))
            {
                parentNode : currentNode;

                parentLite : false;

                currentNode : currentNode.ChildRite;
            }
        }

        var TreeNodeResult u;

        u : this.NodeResult;

        u.HasNode : b;

        u.Node : node;

        u.ParentNode : parentNode;

        u.ParentLite : parentLite;

        var TreeNodeResult a;
        a : u;
        return a;
    }
}