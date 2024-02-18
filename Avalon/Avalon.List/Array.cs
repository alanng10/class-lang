namespace Avalon.List;




public class Array : List
{



    public override bool Init()
    {
        this.InfraInfra = InfraInfra.This;



        this.Comparer = new Comparer();

        this.Comparer.Init();



        this.Value = new object[this.Count];



        return true;
    }




    protected virtual InfraInfra InfraInfra { get; set; }



    private object[] Value { get; set; }


    private Comparer Comparer { get; set; }





    public override object Add(object item)
    {
        return null;
    }





    public override object Insert(object index, object item)
    {
        return null;
    }





    public override bool Remove(object index)
    {
        return false;
    }







    public override bool Clear()
    {
        return false;
    }







    public override bool Contain(object index)
    {
        int u;


        u = this.IntIndex(index);



        if (u == -1)
        {
            return false;
        }




        int intIndex;


        intIndex = u;



        return this.Contain(intIndex);
    }






    public virtual bool Contain(int index)
    {
        return !(index < 0) & (index < this.Count);
    }






    public override object Get(object index)
    {
        int u;


        u = this.IntIndex(index);



        if (u == -1)
        {
            return null;
        }




        int intIndex;


        intIndex = u;



        return this.Get(intIndex);
    }






    public virtual object Get(int index)
    {
        if (!this.Contain(index))
        {
            return null;
        }



        return this.Value[index];
    }






    public override bool Set(object index, object value)
    {
        int u;


        u = this.IntIndex(index);



        if (u == -1)
        {
            return false;
        }




        int intIndex;


        intIndex = u;



        return this.Set(intIndex, value);
    }






    public virtual bool Set(int index, object value)
    {
        if (!this.Contain(index))
        {
            return false;
        }



        this.Value[index] = value;




        return true;
    }






    public virtual bool Sort(Range range, Compare compare)
    {
        int index;

        index = range.Start;


        int count;

        count = this.InfraInfra.Count(range);



        this.Comparer.CompareAny = compare;



        SystemArray.Sort<object>(this.Value, index, count, this.Comparer);
        


        this.Comparer.CompareAny = null;




        return true;
    }







    public override Iter CreateIter()
    {
        Iter a;


        a = new ArrayIter();


        a.Init();



        return a;
    }





    public override bool SetIter(Iter iter)
    {
        ArrayIter a;

        a = (ArrayIter)iter;



        a.Array = this;


        a.IntIndex = 0;


        a.CurrentIndex = -1;



        return true;
    }







    private int IntIndex(object index)
    {
        if (!(index is int))
        {
            return -1;
        }



        int t;

        t = (int)index;



        int ret;

        ret = t;

        return ret;
    }
}