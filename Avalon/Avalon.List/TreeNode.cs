namespace Avalon.List;

class TreeNode : Any
{
    public virtual TreeNode Parent { get; set; }
    public virtual TreeNode LeftChild { get; set; }
    public virtual TreeNode RightChild { get; set; }
    public virtual int BalanceFactor { get; set; }
    public virtual object Index { get; set; }
    public virtual object Value { get; set; }
}