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

    private SystemTime Intern;
}