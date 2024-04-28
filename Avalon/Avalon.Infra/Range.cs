namespace Avalon.Infra;

public class Range : Any
{
    public virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;
    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
}