namespace Avalon.Time;

class InternTime : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = SystemTime.MinValue;
        return true;
    }

    public virtual long Yea
    {
        get
        {
            return this.Intern.Year;
        }
        set
        {
        }
    }

    public virtual long Mon
    {
        get
        {
            return this.Intern.Month;
        }
        set
        {
        }
    }

    public virtual long Day
    {
        get
        {
            return this.Intern.Day;
        }
        set
        {
        }
    }

    public virtual long Our
    {
        get
        {
            return this.Intern.Hour;
        }
        set
        {
        }
    }

    public virtual long Min
    {
        get
        {
            return this.Intern.Minute;
        }
        set
        {
        }
    }

    public virtual long Sec
    {
        get
        {
            return this.Intern.Second;
        }
        set
        {
        }
    }

    public virtual long Tick
    {
        get
        {
            return this.Intern.Millisecond;
        }
        set
        {
        }
    }

    public virtual long YeaDay
    {
        get
        {
            return this.Intern.DayOfYear;
        }
        set
        {
        }
    }

    public virtual long WeekDay
    {
        get
        {
            return (int)this.Intern.DayOfWeek;
        }
        set
        {
        }
    }

    public virtual long TotalTick
    {
        get
        {
            return this.Intern.Ticks / 10000;
        }
        set
        {
        }
    }

    public virtual bool This()
    {
        this.Intern = SystemTime.Now;
        return true;
    }

    public virtual bool AddYea(long value)
    {
        int k;
        k = (int)value;

        this.Intern = this.Intern.AddYears(k);
        return true;
    }

    public virtual bool AddMon(long value)
    {
        int k;
        k = (int)value;

        this.Intern = this.Intern.AddMonths(k);
        return true;
    }

    public virtual bool AddDay(long value)
    {
        double k;
        k = value;

        this.Intern = this.Intern.AddDays(k);
        return true;
    }

    public virtual bool AddTick(long value)
    {
        double k;
        k = value;

        this.Intern = this.Intern.AddMilliseconds(k);
        return true;
    }

    public virtual bool LeapYea(long yea)
    {
        int k;
        k = (int)yea;

        return SystemTime.IsLeapYear(k);
    }

    private SystemTime Intern;
}