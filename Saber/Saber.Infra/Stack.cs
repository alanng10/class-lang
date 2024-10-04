namespace Saber.Infra;

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
        e = this.End;
        if (e == null)
        {
            return false;
        }
        this.Rem(e);
        return true;
    }
    
    public virtual object Top
    {
        get
        {
            object e;
            e = this.End;
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