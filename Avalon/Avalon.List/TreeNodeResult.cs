namespace Avalon.List;

class TreeNodeResult : Any
{
    public virtual bool HasNode { get; set; }
    public virtual TreeNode Node { get; set; }
    public virtual TreeNode ParentNode { get; set; }
    public virtual bool ParentLeft { get; set; }
}