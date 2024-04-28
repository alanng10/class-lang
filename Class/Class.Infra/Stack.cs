namespace Class.Infra;

public class Stack : List
{
    public virtual bool Push(object item)
    {
        this.Add(item);
        return true;
    }

    public virtual bool Pop()
    {
        object e;
        e = this.LastIndex;
        if (e == null)
        {
            return false;
        }
        this.Remove(e);
        return true;
    }
    
    public virtual object Top
    {
        get
        {
            object e;
            e = this.LastIndex;
            if (e == null)
            {
                return null;
            }
            return this.Get(e);
        }
        set
        {
        }
    }
}