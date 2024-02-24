namespace Class.Infra;




public class Stack : Array
{
    protected virtual int ItemCount { get; set; }

    public virtual bool Push(object item)
    {
        if (!(this.ItemCount < this.Count))
        {
            return true;
        }

        this.Set(this.ItemCount, item);

        this.ItemCount = this.ItemCount + 1;

        return true;
    }


    public virtual bool Pop()
    {
        if (this.ItemCount == 0)
        {
            return true;
        }

        this.ItemCount = this.ItemCount - 1;

        this.Set(this.ItemCount, null);

        return true;
    }
    
    public virtual object Top
    {
        get
        {
            if (this.ItemCount == 0)
            {
                return null;
            }


            return this.Get(this.ItemCount - 1);
        }
        set
        {

        }
    }
}