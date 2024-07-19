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
        this.Intern = DateTime.UtcNow;
        return true;
    }

    public virtual bool ToOffsetUtc(int offset)
    {

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

    public virtual bool Set(int year, int month, int day, int hour, int minute, int second, int millisecond, int offsetUtc)
    {
        ulong yearU;
        ulong monthU;
        ulong dayU;
        ulong hourU;
        ulong minuteU;
        ulong secondU;
        ulong millisecondU;
        ulong isLocalTimeU;
        ulong offsetUtcU;
        yearU = (ulong)year;
        monthU = (ulong)month;
        dayU = (ulong)day;
        hourU = (ulong)hour;
        minuteU = (ulong)minute;
        secondU = (ulong)second;
        millisecondU = (ulong)millisecond;
        isLocalTimeU = 0;
        offsetUtcU = (ulong)offsetUtc;

        Extern.Time_Set(this.Intern, yearU, monthU, dayU, hourU, minuteU, secondU, millisecondU, isLocalTimeU, offsetUtcU);
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
        return new DateTime(tick, DateTimeKind.Utc);
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