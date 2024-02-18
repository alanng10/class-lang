namespace Avalon.Infra;



public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();




    private static Infra ShareCreate()
    {
        Infra share;


        share = new Infra();



        Any a;


        a = share;


        a.Init();



        return share;
    }






    public override bool Init()
    {
        base.Init();




        this.ULongByteCount = sizeof(ulong);



        this.ByteBitCount = 8;



        this.IntByteCount = sizeof(int);




        long o;

        o = 1;

        o = o << 60;



        this.IntCapValue = o;




        this.NewLine = '\n';




        this.PathCombine = '/';




        return true;
    }





    public virtual int ULongByteCount { get; set; }



    public virtual int ByteBitCount { get; set; }



    public virtual int IntByteCount { get; set; }




    public virtual long IntCapValue { get; set; }




    public virtual char NewLine { get; set; }




    public virtual char PathCombine { get; set; }







    public virtual bool IndexRange(Range range, int index)
    {
        range.Start = index;
        
        
        range.End = index + 1;



        return true;
    }






    public virtual int Count(Range range)
    {
        return range.End - range.Start;
    }





    public virtual long LongCount(DataRange range)
    {
        return range.End - range.Start;
    }






    public virtual bool CheckRange(int count, Range range)
    {
        int start;

        int end;


        start = range.Start;

        end = range.End;



        if (start < 0)
        {
            return false;
        }


        if (end < start)
        {
            return false;
        }


        if (count < end)
        {
            return false;
        }



        return true;
    }






    public virtual bool CheckLongRange(long count, DataRange range)
    {
        long start;

        long end;


        start = range.Start;

        end = range.End;



        if (start < 0)
        {
            return false;
        }


        if (end < start)
        {
            return false;
        }


        if (count < end)
        {
            return false;
        }



        return true;
    }







    public virtual ulong ByteListULong(byte[] u, int start)
    {
        int m;

        m = this.ByteBitCount;



        int ua;

        ua = this.ULongByteCount;




        byte ob;



        int index;




        ulong k;



        ulong h;

        h = 0;



        int shiftCount;




        int count;

        count = ua;



        int i;

        i = 0;


        while (i < count)
        {
            shiftCount = i * m;




            index = start + i;



            ob = u[index];



            k = ob;


            k = k << shiftCount;



            h = h | k;



            i = i + 1;
        }



        ulong ret;

        ret = h;


        return ret;
    }
}