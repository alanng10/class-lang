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
        if (this.Count == 0)
        {
            return true;
        }



        object index;

        index = this.Last;


        this.Remove(index);



        return true;
    }
    



    public virtual object Top
    {
        get
        {
            if (this.Count == 0)
            {
                return null;
            }


            return this.Last.Value;
        }
        set
        {

        }
    }
}