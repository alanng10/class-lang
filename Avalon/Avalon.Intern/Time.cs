namespace Avalon.Intern;

public class Time : object
{
    public virtual bool Init()
    {
        this.Intern = DateTime.MinValue;
        return true;
    }

    private DateTime Intern;

    public virtual int Year
    {
        get
        {
            return this.Intern.Year;
        }
        set
        {
        }
    }

    public virtual int Month
    {
        get
        {
            return this.Intern.Month;
        }
        set
        {
        }
    }

    public virtual int Day
    {
        get
        {
            return this.Intern.Day;
        }
        set
        {
        }
    }

    public virtual int Hour
    {
        get
        {
            return this.Intern.Hour;
        }
        set
        {
        }
    }

    public virtual int Min
    {
        get
        {
            return this.Intern.Minute;
        }
        set
        {
        }
    }

    public virtual int Sec
    {
        get
        {
            return this.Intern.Second;
        }
        set
        {
        }
    }

    public virtual int Millisec
    {
        get
        {
            return this.Intern.Millisecond;
        }
        set
        {
        }
    }

    public virtual long Tick
    {
        get
        {
            return this.Intern.Ticks;
        }
        set
        {
        }
    }

    public virtual bool SetDate(int year, int month, int day, int hour, int min, int sec, int millisec)
    {
        this.Intern = new DateTime(year, month, day, hour, min, sec, millisec, DateTimeKind.Local);
        return true;
    }

    public bool Set(long tick)
    {
        this.Intern = new DateTime(tick, DateTimeKind.Local);
        return true;
    }
}