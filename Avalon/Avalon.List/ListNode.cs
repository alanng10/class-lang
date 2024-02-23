namespace Avalon.List;

class ListNode : Any
{
    public virtual ListNode Previous { get; set; }
    public virtual ListNode Next { get; set; }
    public virtual ListNodeRef Ref { get; set; }
    public virtual object Value { get; set; }
}