namespace Class.Check;




public class VarStack : Stack
{
    public bool Push(Table item)
    {
        return base.Push(item);
    }



    public new Table Top
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