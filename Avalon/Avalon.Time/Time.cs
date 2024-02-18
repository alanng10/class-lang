namespace Avalon.Time;





public class Time : Any
{
    public override bool Init()
    {
        base.Init();




        this.Intern = Extern.Time_New();


        Extern.Time_Init(this.Intern);



        return true;
    }




    public virtual bool Final()
    {
        Extern.Time_Final(this.Intern);


        Extern.Time_Delete(this.Intern);




        return true;
    }





    private ulong Intern { get; set; }





    public virtual int Year
    {
        get
        {
            ulong u;

            u = Extern.Time_GetYear(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }




    public virtual int Month
    {
        get
        {
            ulong u;

            u = Extern.Time_GetMonth(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }




    public virtual int Day
    {
        get
        {
            ulong u;

            u = Extern.Time_GetDay(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual int Hour
    {
        get
        {
            ulong u;

            u = Extern.Time_GetHour(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }




    public virtual int Minute
    {
        get
        {
            ulong u;

            u = Extern.Time_GetMinute(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }




    public virtual int Second
    {
        get
        {
            ulong u;

            u = Extern.Time_GetSecond(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }




    public virtual int Millisecond
    {
        get
        {
            ulong u;

            u = Extern.Time_GetMillisecond(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual int OffsetUtc
    {
        get
        {
            ulong u;

            u = Extern.Time_GetOffsetUtc(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual bool LocalTime
    {
        get
        {
            ulong u;

            u = Extern.Time_GetLocalTime(this.Intern);



            bool a;

            a = (!(u == 0));


            return a;
        }
        set
        {
        }
    }






    public virtual int YearDay
    {
        get
        {
            ulong u;

            u = Extern.Time_GetYearDay(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual int WeekDay
    {
        get
        {
            ulong u;

            u = Extern.Time_GetWeekDay(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }






    public virtual int YearDayCount
    {
        get
        {
            ulong u;

            u = Extern.Time_GetYearDayCount(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual int MonthDayCount
    {
        get
        {
            ulong u;

            u = Extern.Time_GetMonthDayCount(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }







    public virtual bool Current()
    {
        Extern.Time_Current(this.Intern);



        return true;
    }




    
    public virtual bool ToLocalTime()
    {
        Extern.Time_ToLocalTime(this.Intern);

        

        return true;
    }




    public virtual bool ToOffsetUtc(int offset)
    {
        ulong u;
        
        u = (ulong)offset;



        Extern.Time_ToOffsetUtc(this.Intern, u);




        return true;
    }





    public virtual bool AddYear(int offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddYear(this.Intern, u);



        return true;
    }





    public virtual bool AddMonth(int offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddMonth(this.Intern, u);



        return true;
    }




    public virtual bool AddDay(long offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddDay(this.Intern, u);



        return true;
    }





    public virtual bool AddHour(long offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddHour(this.Intern, u);



        return true;
    }




    public virtual bool AddMinute(long offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddMinute(this.Intern, u);



        return true;
    }




    public virtual bool AddSecond(long offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddSecond(this.Intern, u);



        return true;
    }




    public virtual bool AddMillisecond(long offset)
    {
        ulong u;

        u = (ulong)offset;



        Extern.Time_AddMillisecond(this.Intern, u);



        return true;
    }






    public virtual long MillisecondTo(Time other)
    {
        ulong u;

        u = Extern.Time_MillisecondTo(this.Intern, other.Intern);



        long a;

        a = (long)u;


        return a;
    }





    public virtual long DayTo(Time other)
    {
        ulong u;

        u = Extern.Time_DayTo(this.Intern, other.Intern);



        long a;

        a = (long)u;


        return a;
    }





    public virtual bool LeapYear(int year)
    {
        ulong ua;

        ua = (ulong)year;




        ulong u;

        u = Extern.Time_LeapYear(ua);




        bool a;

        a = (!(u == 0));


        return a;
    }





    public virtual bool ValidDate(int year, int month, int day)
    {
        ulong yearU;

        ulong monthU;

        ulong dayU;



        yearU = (ulong)year;

        monthU = (ulong)month;

        dayU = (ulong)day;




        ulong u;

        u = Extern.Time_ValidDate(yearU, monthU, dayU);




        bool a;

        a = (!(u == 0));


        return a;
    }






    public virtual bool ValidTime(int hour, int minute, int second, int millisecond)
    {
        ulong hourU;

        ulong minuteU;

        ulong secondU;

        ulong millisecondU;



        hourU = (ulong)hour;

        minuteU = (ulong)minute;

        secondU = (ulong)second;

        millisecondU = (ulong)millisecond;




        ulong u;

        u = Extern.Time_ValidTime(hourU, minuteU, secondU, millisecondU);




        bool a;

        a = (!(u == 0));


        return a;
    }







    public virtual bool Set(int year, int month, int day, int hour, int minute, int second, int millisecond, bool hasOffset, int offsetUtc)
    {
        ulong yearU;

        ulong monthU;

        ulong dayU;

        ulong hourU;

        ulong minuteU;

        ulong secondU;

        ulong millisecondU;

        ulong hasOffsetU;

        ulong offsetUtcU;


        yearU = (ulong)year;

        monthU = (ulong)month;

        dayU = (ulong)day;

        hourU = (ulong)hour;

        minuteU = (ulong)minute;

        secondU = (ulong)second;

        millisecondU = (ulong)millisecond;


        hasOffsetU = (ulong)(hasOffset ? 1 : 0);

        offsetUtcU = (ulong)offsetUtc;




        Extern.Time_Set(this.Intern, yearU, monthU, dayU, hourU, minuteU, secondU, millisecondU, hasOffsetU, offsetUtcU);




        return true;
    }
}