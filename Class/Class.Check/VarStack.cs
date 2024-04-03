namespace Class.Check;




public class VarStack : Stack
{
    public virtual bool Push(Table item)
    {
        return base.Push(item);
    }



    public new virtual Table Top
    {
        get
        {
            return (Table)base.Top;
        }
        set
        {
        }
    }
}