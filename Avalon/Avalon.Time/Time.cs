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
            u = Extern.Time_YeaGet(this.Intern);
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
            u = Extern.Time_MonGet(this.Intern);
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
            u = Extern.Time_OurGet(this.Intern);
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

    public virtual long Tick
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

    public virtual long YeaDay
    {
        get
        {
            ulong u;
            u = Extern.Time_YeaDayGet(this.Intern);
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

    public virtual long YeaDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_YeaDayCountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long MonDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_MonDayCountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long TotalTick
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
        ulong u;
        u = Extern.Time_This(this.Intern);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool ToPos(long pos)
    {
        ulong u;
        u = (ulong)pos;
        Extern.Time_ToPos(this.Intern, u);
        return true;
    }

    public virtual bool AddYea(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong u;
        u = Extern.Time_AddYea(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool AddMon(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong u;
        u = Extern.Time_AddMon(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool AddDay(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong u;
        u = Extern.Time_AddDay(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool AddTick(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong u;
        u = Extern.Time_AddMillisec(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool LeapYea(long yea)
    {
        ulong ua;
        ua = (ulong)yea;
        ulong u;
        u = Extern.Time_LeapYea(ua);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool ValidDate(long yea, long mon, long day)
    {
        ulong yearU;
        ulong monthU;
        ulong dayU;
        yearU = (ulong)yea;
        monthU = (ulong)mon;
        dayU = (ulong)day;
        ulong u;
        u = Extern.Time_ValidDate(yearU, monthU, dayU);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool ValidTime(long our, long min, long sec, long tick)
    {
        ulong hourU;
        ulong minU;
        ulong secU;
        ulong tickU;
        hourU = (ulong)our;
        minU = (ulong)min;
        secU = (ulong)sec;
        tickU = (ulong)tick;
        ulong u;
        u = Extern.Time_ValidTime(hourU, minU, secU, tickU);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool Set(long yea, long mon, long day, long our, long min, long sec, long tick, long pos)
    {
        ulong yeaU;
        ulong monU;
        ulong dayU;
        ulong ourU;
        ulong minU;
        ulong secU;
        ulong tickU;
        ulong posU;
        yeaU = (ulong)yea;
        monU = (ulong)mon;
        dayU = (ulong)day;
        ourU = (ulong)our;
        minU = (ulong)min;
        secU = (ulong)sec;
        tickU = (ulong)tick;
        posU = (ulong)pos;

        ulong u;
        u = Extern.Time_Set(this.Intern, yeaU, monU, dayU, ourU, minU, secU, tickU, posU);
        
        bool a;
        a = !(u == 0);
        return a;
    }
}