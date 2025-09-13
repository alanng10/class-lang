namespace Avalon.Time;

public class Time : Any
{
    public override bool Init()
    {
        base.Init();

        bool b;
        b = (this.InitIdent == 0);

        if (!b)
        {
            this.Intern = (ulong)this.InitIdent;
        }

        if (b)
        {
            this.Intern = Extern.Time_New();
            Extern.Time_Init(this.Intern);
        }
        return true;
    }

    public virtual bool Final()
    {
        Extern.Time_Final(this.Intern);
        Extern.Time_Delete(this.Intern);
        return true;
    }

    public virtual long InitIdent { get; set; }

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
            u = Extern.Time_TickGet(this.Intern);
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
            u = Extern.Time_TotalTickGet(this.Intern);
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
        ulong k;
        k = Extern.Time_This(this.Intern);

        bool a;
        a = !(k == 0);
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
        ulong k;
        k = Extern.Time_AddYea(this.Intern, valueU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool AddMon(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong k;
        k = Extern.Time_AddMon(this.Intern, valueU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool AddDay(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong k;
        k = Extern.Time_AddDay(this.Intern, valueU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool AddTick(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        ulong k;
        k = Extern.Time_AddTick(this.Intern, valueU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool LeapYea(long yea)
    {
        ulong ua;
        ua = (ulong)yea;
        ulong k;
        k = Extern.Time_LeapYea(ua);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool ValidDate(long yea, long mon, long day)
    {
        ulong yeaU;
        ulong monU;
        ulong dayU;
        yeaU = (ulong)yea;
        monU = (ulong)mon;
        dayU = (ulong)day;
        ulong k;
        k = Extern.Time_ValidDate(yeaU, monU, dayU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool ValidTime(long our, long min, long sec, long tick)
    {
        ulong ourU;
        ulong minU;
        ulong secU;
        ulong tickU;
        ourU = (ulong)our;
        minU = (ulong)min;
        secU = (ulong)sec;
        tickU = (ulong)tick;
        ulong k;
        k = Extern.Time_ValidTime(ourU, minU, secU, tickU);

        bool a;
        a = (!(k == 0));
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

        ulong k;
        k = Extern.Time_Set(this.Intern, yeaU, monU, dayU, ourU, minU, secU, tickU, posU);
        
        bool a;
        a = !(k == 0);
        return a;
    }
}