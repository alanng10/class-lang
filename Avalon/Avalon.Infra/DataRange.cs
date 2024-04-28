namespace Avalon.Infra;

public class DataRange : Any
{
    public virtual long Index { get { return __D_Index; } set { __D_Index = value; } }
    protected long __D_Index;
    public virtual long Count { get { return __D_Count; } set { __D_Count = value; } }
    protected long __D_Count;
}