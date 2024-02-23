namespace Avalon.List;

class Tree : Any
{
    public override bool Init()
    {
        base.Init();
        this.NodeResult = new TreeNodeResult();
        this.NodeResult.Init();
        return true;
    }

    private TreeNode Root { get; set; }
    private TreeNodeResult NodeResult { get; set; }

    public Compare Compare { get; set; }

    public bool Insert(object index, object value)
    {
        if (index == null)
        {
            return false;
        }

        TreeNode node;
        node = this.TreeInsert(index, value);
        if (node == null)
        {
            return false;
        }

        this.InsertRetrace(node);
        return true;
    }

    public bool Remove(object index)
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

        this.TreeRemove(node);

        this.RemoveRetrace(node);
        return true;
    }

    public bool Clear()
    {
        this.Root = null;
        return true;
    }

    private bool InsertRetrace(TreeNode Z)
    {
        TreeNode X;



        TreeNode G;



        TreeNode N;




        int direction;




        for (X = Z.Parent; X != null; X = Z.Parent)
        {
            // Loop (possibly up to the root)
            // BF(X) has to be updated:
            
            
            if (Z == X.RightChild)
            {
                // The right subtree increases


                direction = -DirectionValue;
            }
            else
            {
                direction = +DirectionValue;
            }




            if (this.Sign(X.BalanceFactor) == - direction)
            {
                // X is right-heavy
                // ==> the temporary BF(X) == +2
                // ==> rebalancing is required.


                G = X.Parent; // Save parent of X around rotations



                if (this.Sign(Z.BalanceFactor) == direction)    // Right Left Case  (see figure 3)
                {
                    N = this.RotateDouble(X, Z, direction);     // Double rotation: Right(Z) then Left(X)
                }
                else
                {                                               // Right Right Case (see figure 2)
                    N = this.RotateSingle(X, Z, direction);     // Single rotation Left(X)
                }
                // After rotation adapt parent link
            }
            else
            {
                if (this.Sign(X.BalanceFactor) == direction)
                {
                    X.BalanceFactor = 0; // Z’s height increase is absorbed at X.




                    break; // Leave the loop
                }




                X.BalanceFactor = - direction;



                Z = X; // Height(Z) increases by 1




                continue;
            }







            // After a rotation adapt parent link:
            // N is the new root of the rotated subtree
            // Height does not change: Height(N) == old Height(X)


            N.Parent = G;



            if (G != null)
            {
                if (X == G.LeftChild)
                {
                    G.LeftChild = N;
                }
                else
                {
                    G.RightChild = N;
                }
            }
            else
            {
                this.Root = N; // N is the new root of the total tree
            }



            break;


            // There is no fall thru, only break; or continue;
        
        }



        // Unless loop is left via break, the height of the total tree increases by 1.



        return true;
    }





    private bool RemoveRetrace(TreeNode N)
    {
        TreeNode X;



        TreeNode G;



        TreeNode Z;



        int direction;



        int b;



        for (X = N.Parent; X != null; X = G)
        { 
            // Loop (possibly up to the root)
            G = X.Parent; // Save parent of X around rotations
                           // BF(X) has not yet been updated!
            if (N == X.LeftChild)
            {
                direction = - DirectionValue;
            }
            else
            {
                direction = + DirectionValue;
            }




            // the left subtree decreases


            if (this.Sign(X.BalanceFactor) == -direction)
            {
                // X is right-heavy
                // ==> the temporary BF(X) == +2
                // ==> rebalancing is required.


                if (direction == -DirectionValue)
                {

                    Z = X.RightChild; // Sibling of N (higher by 2)
                }
                else
                {
                    Z = X.LeftChild; // Sibling of N (higher by 2)
                }



                b = Z.BalanceFactor;



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
                if (X.BalanceFactor == 0)
                {
                    X.BalanceFactor = - direction; // N’s height decrease is absorbed at X.
                    break; // Leave the loop
                }



                N = X;



                N.BalanceFactor = 0; // Height(N) decreases by 1



                continue;
            }





            // After a rotation adapt parent link:
            // N is the new root of the rotated subtree
            
            N.Parent = G;
            
            
            
            
            if (G != null)
            {
                if (X == G.LeftChild)
                {
                    G.LeftChild = N;
                }
                else
                {
                    G.RightChild = N;
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






    private TreeNode TreeInsert(object index, object value)
    {
        TreeNodeResult t;



        t = this.Node(index);




        if (t.HasNode)
        {
            return null;
        }




        TreeNode node;



        node = new TreeNode();



        node.Init();



        node.Index = index;



        node.Value = value;



        node.BalanceFactor = 0;




        if (t.ParentNode == null)
        {
            this.Root = node;
        }
        



        if (!(t.ParentNode == null))
        {
            if (t.ParentLeft)
            {
                t.ParentNode.LeftChild = node;
            }


            if (! t.ParentLeft)
            {
                t.ParentNode.RightChild = node;
            }



            node.Parent = t.ParentNode;
        }




        TreeNode ret;


        ret = node;



        return ret;
    }






    private TreeNode RotateSingle(TreeNode X, TreeNode Z, int direction)
    {
        this.RotateTreeSingle(X, Z, direction);




        // 1st case, BF(Z) == 0,
        //   only happens with deletion, not insertion:
        if (Z.BalanceFactor == 0)
        { 
            // t23 has been of same height as t4
            
            X.BalanceFactor = - direction;   // t23 now higher



            Z.BalanceFactor = direction;   // t4 now lower than X
        }
        else
        { 
            // 2nd case happens with insertion or deletion:
            
            X.BalanceFactor = 0;
            
            

            Z.BalanceFactor = 0;
        }



        return Z; // return new root of rotated subtree
    }






    private TreeNode RotateDouble(TreeNode X, TreeNode Z, int direction)
    {
        TreeNode Y;



        Y = this.RotateTreeDouble(X, Z, direction);





        // 1st case, BF(Y) == 0,
        //   only happens with deletion, not insertion:
        if (Y.BalanceFactor == 0)
        {
            X.BalanceFactor = 0;
            Z.BalanceFactor = 0;
        }
        else
        {
            // other cases happen with insertion or deletion:
            if (this.Sign(Y.BalanceFactor) == -direction)
            { // t3 was higher
                X.BalanceFactor = direction;  // t1 now higher
                Z.BalanceFactor = 0;
            }
            else
            {
                // t2 was higher
                X.BalanceFactor = 0;
                Z.BalanceFactor = - direction;  // t4 now higher
            }
        }


        Y.BalanceFactor = 0;



        return Y; // return new root of rotated subtree
    }




    private static readonly int DirectionValue = 1;





    private int Sign(int u)
    {
        if (u < 0)
        {
            return -DirectionValue;
        }



        if (0 < u)
        {
            return +DirectionValue;
        }



        return 0;
    }






    private TreeNode RotateTreeDouble(TreeNode X, TreeNode Z, int direction)
    {
        TreeNode Y;


        Y = null;



        // Z is by 2 higher than its sibling


        bool b;


        b = (direction == - DirectionValue);



        if (b)
        {
            Y = Z.LeftChild; // Inner child of Z
        }


        if (! b)
        {
            Y = Z.RightChild;
        }
        



        // Y is by 1 higher than sibling



        this.RotateTreeSingle(Z, Y, - direction);




        this.RotateTreeSingle(X, Y, direction);





        TreeNode ret;


        ret = Y;



        return ret;
    }




    private bool RotateTreeSingle(TreeNode X, TreeNode Z, int direction)
    {
        bool b;


        b = (direction ==  - DirectionValue);


        if (b)
        {
            this.RotateTreeLeft(X, Z);
        }


        if (! b)
        {
            this.RotateTreeRight(X, Z);
        }



        return true;
    }





    private bool RotateTreeLeft(TreeNode X, TreeNode Z)
    {
        TreeNode t23;



        // Z is by 2 higher than its sibling


        t23 = Z.LeftChild; // Inner child of Z


        X.RightChild = t23;



        if (t23 != null)
        {
            t23.Parent = X;
        }
        



        Z.LeftChild = X;




        X.Parent = Z;



        return true;
    }




    private bool RotateTreeRight(TreeNode X, TreeNode Z)
    {
        TreeNode t23;



        // Z is by 2 higher than its sibling


        t23 = Z.RightChild; // Inner child of Z


        X.LeftChild = t23;



        if (t23 != null)
        {
            t23.Parent = X;
        }
        



        Z.RightChild = X;




        X.Parent = Z;



        return true;
    }





    private bool TreeRemove(TreeNode z)
    {
        if (z.LeftChild == null)
        {
            this.SubtreeShift(z, z.RightChild);
        }
        else if (z.RightChild == null)
        {
            this.SubtreeShift(z, z.LeftChild);
        }
        else
        {
            TreeNode y;



            y = this.Successor(z);




            if (y.Parent != z)
            {
                this.SubtreeShift(y, y.RightChild);



                y.RightChild = z.RightChild;



                y.RightChild.Parent = y;
            }




            this.SubtreeShift(z, y);




            y.LeftChild = z.LeftChild;




            y.LeftChild.Parent = y;
        }




        return true;
    }






    private bool SubtreeShift(TreeNode u, TreeNode v)
    {
        if (u.Parent == null)
        {
            this.Root = v;
        }
        else if (u == u.Parent.LeftChild)
        {
            u.Parent.LeftChild = v;
        }
        else
        {
            u.Parent.RightChild = v;
        }



        if (v != null)
        {
            v.Parent = u.Parent;
        }



        return true;
    }




    private TreeNode Successor(TreeNode x)
    {
        if (x.RightChild != null)
        {
            return this.Minimum(x.RightChild);
        }




        TreeNode y;



        y = x.Parent;




        while (y != null && x == y.RightChild)
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



        while (t.LeftChild != null)
        {
            t = t.LeftChild;
        }



        return t;
    }





    public TreeNodeResult Node(object index)
    {
        TreeNode node;



        node = null;




        TreeNode parentNode;



        parentNode = null;




        bool parentLeft;



        parentLeft = false;





        bool b;



        b = false;





        int t;



        object o;





        TreeNode currentNode;



        currentNode = this.Root;




        while (!b & !(currentNode == null))
        {
            o = currentNode.Index;




            t = this.Compare.Execute(index, o);




            if (t == 0)
            {
                node = currentNode;


                b = true;
            }




            if (t < 0)
            {
                parentNode = currentNode;




                parentLeft = true;




                currentNode = currentNode.LeftChild;
            }




            if (0 < t)
            {
                parentNode = currentNode;




                parentLeft = false;




                currentNode = currentNode.RightChild;
            }
        }






        TreeNodeResult u;



        u = this.NodeResult;



        u.HasNode = b;



        u.Node = node;



        u.ParentNode = parentNode;



        u.ParentLeft = parentLeft;





        TreeNodeResult ret;


        ret = u;



        return ret;
    }










}
