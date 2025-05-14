namespace Avalon.List;

public class Stack : List
{
    public virtual bool Push(object item)
    {
        this.Add(item);
        return true;
    }

    public virtual bool Pop()
    {
        object k;
        k = this.End;

        if (k == null)
        {
            return false;
        }

        this.Rem(k);

        return true;
    }

    public virtual object Top
    {
        get
        {
            object k;
            k = this.End;

            if (k == null)
            {
                return null;
            }

            return this.Get(k);
        }
        set
        {
        }
    }
}