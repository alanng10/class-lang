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

    public virtual long Yea
    {
        get
        {
            ulong u;
            u = Extern.Time_YearGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Mon
    {
        get
        {
            ulong u;
            u = Extern.Time_MonthGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Day
    {
        get
        {
            ulong u;
            u = Extern.Time_DayGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Our
    {
        get
        {
            ulong u;
            u = Extern.Time_HourGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Min
    {
        get
        {
            ulong u;
            u = Extern.Time_MinGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Sec
    {
        get
        {
            ulong u;
            u = Extern.Time_SecGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Millisec
    {
        get
        {
            ulong u;
            u = Extern.Time_MillisecGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Pos
    {
        get
        {
            ulong u;
            u = Extern.Time_PosGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long YearDay
    {
        get
        {
            ulong u;
            u = Extern.Time_YearDayGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long WeekDay
    {
        get
        {
            ulong u;
            u = Extern.Time_WeekDayGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long YearDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_YearDayCountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long MonthDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_MonthDayCountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long TotalMillisec
    {
        get
        {
            ulong u;
            u = Extern.Time_TotalMillisecGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual bool This()
    {
        Extern.Time_This(this.Intern);
        return true;
    }

    public virtual bool ToPos(long pos)
    {
        ulong u;
        u = (ulong)pos;
        Extern.Time_ToPos(this.Intern, u);
        return true;
    }

    public virtual bool AddYear(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddYear(this.Intern, u);
        return true;
    }

    public virtual bool AddMonth(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddMonth(this.Intern, u);
        return true;
    }

    public virtual bool AddDay(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddDay(this.Intern, u);
        return true;
    }

    public virtual bool AddMillisec(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddMillisec(this.Intern, u);
        return true;
    }

    public virtual bool LeapYear(long year)
    {
        ulong ua;
        ua = (ulong)year;
        ulong u;
        u = Extern.Time_LeapYear(ua);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool ValidDate(long year, long month, long day)
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

    public virtual bool ValidTime(long hour, long min, long sec, long millisec)
    {
        ulong hourU;
        ulong minU;
        ulong secU;
        ulong millisecU;
        hourU = (ulong)hour;
        minU = (ulong)min;
        secU = (ulong)sec;
        millisecU = (ulong)millisec;
        ulong u;
        u = Extern.Time_ValidTime(hourU, minU, secU, millisecU);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool Set(long year, long month, long day, long hour, long min, long sec, long millisec, long pos)
    {
        ulong yearU;
        ulong monthU;
        ulong dayU;
        ulong hourU;
        ulong minU;
        ulong secU;
        ulong millisecU;
        ulong posU;
        yearU = (ulong)year;
        monthU = (ulong)month;
        dayU = (ulong)day;
        hourU = (ulong)hour;
        minU = (ulong)min;
        secU = (ulong)sec;
        millisecU = (ulong)millisec;
        posU = (ulong)pos;

        Extern.Time_Set(this.Intern, yearU, monthU, dayU, hourU, minU, secU, millisecU, posU);
        return true;
    }
}