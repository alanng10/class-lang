namespace Avalon.List;

public class Entry : Any
{
    public virtual object Index { get { return __D_Index; } set { __D_Index = value; } }
    protected object __D_Index;
    public virtual object Value { get { return __D_Value; } set { __D_Value = value; } }
    protected object __D_Value;
}