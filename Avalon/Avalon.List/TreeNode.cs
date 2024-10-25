namespace Avalon.List;

class TreeNode : Any
{
    public virtual TreeNode Parent { get; set; }
    public virtual TreeNode ChildLite { get; set; }
    public virtual TreeNode ChildRite { get; set; }
    public virtual long BalanceFactor { get; set; }
    public virtual object Index { get; set; }
    public virtual object Value { get; set; }
}