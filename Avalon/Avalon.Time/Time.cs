namespace Avalon.Time;

public class Time : Any
{
    public override bool Init()
    {
        base.Init();
        this.TimeInfra = Infra.This;
        return true;
    }

    private Infra TimeInfra { get; set; }
    private DateTime Intern;
    private int Offset { get; set; }

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

    public virtual int Minute
    {
        get
        {
            return this.Intern.Minute;
        }
        set
        {
        }
    }

    public virtual int Second
    {
        get
        {
            return this.Intern.Second;
        }
        set
        {
        }
    }

    public virtual int Millisecond
    {
        get
        {
            return this.Intern.Millisecond;
        }
        set
        {
        }
    }

    public virtual int OffsetUtc
    {
        get
        {
            return this.Offset;
        }
        set
        {
        }
    }

    public virtual int YearDay
    {
        get
        {
            return this.Intern.DayOfYear;
        }
        set
        {
        }
    }

    public virtual int WeekDay
    {
        get
        {
            int a;
            a = (int)this.Intern.DayOfWeek;
            return a;
        }
        set
        {
        }
    }

    public virtual bool LeapYear(int year)
    {
        if (!this.CheckYear(year))
        {
            return false;
        }

        return DateTime.IsLeapYear(year);
    }

    public virtual int MonthDayCount(int year, int month)
    {
        if (!this.CheckYear(year))
        {
            return -1;
        }

        if (!this.CheckMonth(month))
        {
            return -1;
        }

        return DateTime.DaysInMonth(year, month);
    }

    public virtual bool Current()
    {
        this.Intern = DateTime.Now;
        return true;
    }

    public virtual bool ToOffsetUtc(int offset)
    {
        if (!this.CheckOffsetUtc(offset))
        {
            return false;
        }

        int k;
        k = offset - this.Offset; 

        this.AddSecond(k);

        this.Offset = offset;
        return true;
    }

    public virtual bool AddTick(long offset)
    {
        double ka;
        ka = offset;
        ka = ka * this.TimeInfra.SystemTickPerTick;

        double k;
        k = this.Intern.Ticks;
        k = k + ka;

        long aa;
        aa = (long)k;

        if (!this.CheckSystemTick(aa))
        {
            return false;
        }

        this.Intern = this.GetDateTime(aa);
        return true;
    }

    public virtual bool AddDay(long offset)
    {
        return this.AddOffset(offset, this.TimeInfra.DaySystemTickCount);
    }

    public virtual bool AddHour(long offset)
    {
        return this.AddOffset(offset, this.TimeInfra.HourSystemTickCount);
    }

    public virtual bool AddMinute(long offset)
    {
        return this.AddOffset(offset, this.TimeInfra.MinuteSystemTickCount);
    }

    public virtual bool AddSecond(long offset)
    {
        return this.AddOffset(offset, this.TimeInfra.SecondSystemTickCount);
    }

    public virtual bool AddMillisecond(long offset)
    {
        return this.AddOffset(offset, this.TimeInfra.MillisecondSystemTickCount);
    }

    public virtual long MillisecondTo(Time other)
    {
        long k;
        k = this.SystemTickTo(other);

        k = k / this.TimeInfra.MillisecondSystemTickCount;
        return k;
    }

    public virtual long DayTo(Time other)
    {
        long k;
        k = this.SystemTickTo(other);
        
        k = k / this.TimeInfra.DaySystemTickCount;
        return k;
    }

    public virtual long TickTo(Time other)
    {
        long ka;
        ka = this.SystemTickTo(other);

        double k;
        k = ka;
        k = k / this.TimeInfra.SystemTickPerTick;

        long a;
        a = (long)k;
        return a;
    }

    public virtual bool ValidDate(int year, int month, int day)
    {
        if (!this.CheckYear(year))
        {
            return false;
        }

        if (!this.CheckMonth(month))
        {
            return false;
        }

        if (!this.CheckDay(year, month, day))
        {
            return false;
        }

        return true;
    }

    public virtual bool ValidTime(int hour, int minute, int second, int millisecond)
    {
        if (!this.CheckHour(hour))
        {
            return false;
        }

        if (!this.CheckMinute(minute))
        {
            return false;
        }

        if (!this.CheckSecond(second))
        {
            return false;
        }

        if (!this.CheckMillisecond(millisecond))
        {
            return false;
        }
        
        return true;
    }

    public virtual bool Set(int year, int month, int day, int hour, int minute, int second, int millisecond, int offsetUtc)
    {
        if (!this.ValidDate(year, month, day))
        {
            return false;
        }

        if (!this.ValidTime(hour, minute, second, millisecond))
        {
            return false;
        }

        if (!this.CheckOffsetUtc(offsetUtc))
        {
            return false;
        }

        this.Intern = new DateTime(year, month, day, hour, minute, second, millisecond, DateTimeKind.Local);

        this.Offset = offsetUtc;
        return true;
    }

    protected virtual bool CheckYear(int value)
    {
        return !(value < 1 | 9999 < value);
    }

    protected virtual bool CheckMonth(int value)
    {
        return !(value < 1 | 12 < value);
    }

    protected virtual bool CheckDay(int year, int month, int value)
    {
        int k;
        k = this.MonthDayCount(year, month);

        return !(value < 1 | k < value);
    }

    protected virtual bool CheckHour(int value)
    {
        return this.CheckTimeCount(24, value);
    }

    protected virtual bool CheckMinute(int value)
    {
        return this.CheckTimeCount(60, value);
    }

    protected virtual bool CheckSecond(int value)
    {
        return this.CheckTimeCount(60, value);
    }

    protected virtual bool CheckMillisecond(int value)
    {
        return this.CheckTimeCount(1000, value);
    }

    protected virtual bool CheckOffsetUtc(int value)
    {
        int k;
        k = this.TimeInfra.DaySecondCount;
        k = k / 2;

        return !(value < -k | k < value);
    }

    private bool CheckTimeCount(int count, int value)
    {
        return !(value < 0) & (value < count);
    }

    private long SystemTickTo(Time other)
    {
        long ka;
        ka = this.Intern.Ticks;
        long kb;
        kb = other.Intern.Ticks;

        long k;
        k = kb - ka;
        return k;
    }

    private DateTime GetDateTime(long tick)
    {
        return new DateTime(tick, DateTimeKind.Local);
    }

    private bool AddOffset(long offset, long offsetScale)
    {
        long o;
        o = offset * offsetScale;

        long k;
        k = this.Intern.Ticks;
        k = k + o;

        if (!this.CheckSystemTick(k))
        {
            return false;
        }

        this.Intern = this.GetDateTime(k);
        return true;
    }

    private bool CheckSystemTick(long value)
    {
        Infra infra;
        infra = this.TimeInfra;

        return !(value < infra.SystemTickMin | infra.SystemTickMax < value);
    }
}