namespace Avalon.Intern;




public class Stream : object
{
    public virtual bool Init()
    {
        this.InternIntern = Avalon.Intern.Intern.This;




        this.InternData = Extern.Data_New();


        Extern.Data_Init(this.InternData);




        this.InternRange = Extern.Range_New();


        Extern.Range_Init(this.InternRange);





        bool b;


        b = (this.SetIntern == 0);


        if (b)
        {
            this.Intern = Extern.Stream_New();


            Extern.Stream_Init(this.Intern);
        }



        if (!b)
        {
            this.Intern = this.SetIntern;
        }




        this.Ident = this.Intern;



        return true;
    }





    public virtual bool Final()
    {
        if (this.SetIntern == 0)
        {
            Extern.Stream_Final(this.Intern);


            Extern.Stream_Delete(this.Intern);
        }
        



        Extern.Range_Final(this.InternRange);


        Extern.Range_Delete(this.InternRange);



        Extern.Data_Final(this.InternData);


        Extern.Data_Delete(this.InternData);




        return true;
    }







    public virtual ulong SetIntern { get; set; }




    private Intern InternIntern { get; set; }





    public virtual ulong Ident { get; set; }




    private ulong Intern { get; set; }



    private ulong InternRange { get; set; }



    private ulong InternData { get; set; }






    public virtual bool HasCount
    {
        get
        {
            ulong u;

            u = Extern.Stream_HasCount(this.Intern);


            bool b;

            b = (!(u == 0));


            return b;
        }
        set
        {
        }
    }




    public virtual bool HasPos
    {
        get
        {
            ulong u;

            u = Extern.Stream_HasPos(this.Intern);


            bool b;

            b = (!(u == 0));


            return b;
        }
        set
        {
        }
    }





    public virtual bool CanRead
    {
        get
        {
            ulong u;

            u = Extern.Stream_CanRead(this.Intern);


            bool b;

            b = (!(u == 0));


            return b;
        }
        set
        {
        }
    }





    public virtual bool CanWrite
    {
        get
        {
            ulong u;

            u = Extern.Stream_CanWrite(this.Intern);


            bool b;

            b = (!(u == 0));


            return b;
        }
        set
        {
        }
    }






    public virtual long Count
    {
        get
        {
            ulong ou;
            
            ou = Extern.Stream_GetCount(this.Intern);



            long o;

            o = (long)ou;



            return o;
        }
        set
        {
        }
    }




    public virtual bool SetCount(long value)
    {
        ulong u;

        u = (ulong)value;



        Extern.Stream_SetCount(this.Intern, u);
    


        return true;
    }





    public virtual long Pos
    {
        get
        {
            ulong ou;

            ou = Extern.Stream_GetPos(this.Intern);



            long o;

            o = (long)ou;



            return o;
        }
        set
        {
        }
    }




    public virtual bool SetPos(long value)
    {
        ulong u;

        u = (ulong)value;



        Extern.Stream_SetPos(this.Intern, u);



        return true;
    }





    public virtual int Status
    {
        get
        {
            ulong u;

            u = Extern.Stream_GetStatus(this.Intern);


            int o;

            o = (int)u;


            return o;
        }
        set
        {
        }
    }






    public virtual bool Read(byte[] data, long dataCount, long start, long end)
    {
        if (!this.CanRead)
        {
            return true;
        }




        this.SetInternDataCount(dataCount);


        this.SetInternRange(start, end);



        this.InternIntern.StreamRead(this.Intern, data, this.InternData, this.InternRange);



        return true;
    }

    



    public virtual bool Write(byte[] data, long dataCount, long start, long end)
    {
        if (!this.CanWrite)
        {
            return true;
        }




        this.SetInternDataCount(dataCount);


        this.SetInternRange(start, end);



        this.InternIntern.StreamWrite(this.Intern, data, this.InternData, this.InternRange);



        return true;
    }





    private bool SetInternDataCount(long count)
    {
        ulong countU;

        countU = (ulong)count;



        Extern.Data_SetCount(this.InternData, countU);



        return true;
    }





    private bool SetInternRange(long start, long end)
    {
        ulong startU;

        ulong endU;


        startU = (ulong)start;

        endU = (ulong)end;



        Extern.Range_SetStart(this.InternRange, startU);


        Extern.Range_SetEnd(this.InternRange, endU);




        return true;
    }
}