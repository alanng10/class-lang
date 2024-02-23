namespace Avalon.List;

public class ListNode : Any
{
    public ListNode Previous { get; set; }
    public ListNode Next { get; set; }
    public ListNodeRef Ref { get; set; }
    public object Value { get; set; }
}