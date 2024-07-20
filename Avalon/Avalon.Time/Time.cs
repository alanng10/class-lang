namespace Avalon.Time;

public class Time : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        this.TimeInfra = Infra.This;

        this.Intern = new InternTime();
        this.Intern.Init();
        return true;
    }

    private InternInfra InternInfra { get; set; }
    private Infra TimeInfra { get; set; }
    private InternTime Intern { get; set; }
    private int OffsetUtc { get; set; }

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
            return this.Intern.Min;
        }
        set
        {
        }
    }

    public virtual int Sec
    {
        get
        {
            return this.Intern.Sec;
        }
        set
        {
        }
    }

    public virtual int Millisec
    {
        get
        {
            return this.Intern.Millisec;
        }
        set
        {
        }
    }

    public virtual int Pos
    {
        get
        {
            return this.OffsetUtc;
        }
        set
        {
        }
    }

    public virtual int YearDay
    {
        get
        {
            return this.Intern.YearDay;
        }
        set
        {
        }
    }

    public virtual int WeekDay
    {
        get
        {
            return this.Intern.WeekDay;
        }
        set
        {
        }
    }

    public virtual long Tick
    {
        get
        {
            long a;
            a = this.InternInfra.SystemTickToTick(this.Intern.Tick);
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

        return this.Intern.LeapYear(year);
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

        return this.Intern.MonthDayCount(year, month);
    }

    public virtual bool Current()
    {
        this.Intern.Current();
        
        this.OffsetUtc = 0;
        return true;
    }

    public virtual bool ToPos(int pos)
    {
        if (!this.CheckPos(pos))
        {
            return false;
        }

        int k;
        k = pos - this.OffsetUtc; 

        this.AddSec(k);

        this.OffsetUtc = pos;
        return true;
    }

    public virtual bool AddTick(long value)
    {
        long ka;
        ka = this.InternInfra.TickToSystemTick(value);

        long k;
        k = this.Intern.Tick;
        k = k + ka;

        if (!this.CheckSystemTick(k))
        {
            return false;
        }

        this.Intern = this.GetDateTime(k);
        return true;
    }

    public virtual bool AddDay(long value)
    {
        return this.AddValue(value, this.TimeInfra.DaySystemTickCount);
    }

    public virtual bool AddHour(long value)
    {
        return this.AddValue(value, this.TimeInfra.HourSystemTickCount);
    }

    public virtual bool AddMin(long value)
    {
        return this.AddValue(value, this.TimeInfra.MinSystemTickCount);
    }

    public virtual bool AddSec(long value)
    {
        return this.AddValue(value, this.TimeInfra.SecSystemTickCount);
    }

    public virtual bool AddMillisec(long value)
    {
        return this.AddValue(value, this.TimeInfra.MillisecSystemTickCount);
    }

    public virtual long MillisecTo(Time other)
    {
        long k;
        k = this.SystemTickTo(other);

        k = k / this.TimeInfra.MillisecSystemTickCount;
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

    public virtual bool ValidTime(int hour, int min, int sec, int millisec)
    {
        if (!this.CheckHour(hour))
        {
            return false;
        }

        if (!this.CheckMin(min))
        {
            return false;
        }

        if (!this.CheckSec(sec))
        {
            return false;
        }

        if (!this.CheckMillisec(millisec))
        {
            return false;
        }
        
        return true;
    }

    public virtual bool Set(int year, int month, int day, int hour, int min, int sec, int millisec, int pos)
    {
        if (!this.ValidDate(year, month, day))
        {
            return false;
        }

        if (!this.ValidTime(hour, min, sec, millisec))
        {
            return false;
        }

        if (!this.CheckPos(pos))
        {
            return false;
        }

        this.Intern = new DateTime(year, month, day, hour, min, sec, millisec, DateTimeKind.Local);

        this.OffsetUtc = pos;
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

    protected virtual bool CheckMin(int value)
    {
        return this.CheckTimeCount(60, value);
    }

    protected virtual bool CheckSec(int value)
    {
        return this.CheckTimeCount(60, value);
    }

    protected virtual bool CheckMillisec(int value)
    {
        return this.CheckTimeCount(1000, value);
    }

    protected virtual bool CheckPos(int value)
    {
        int k;
        k = this.TimeInfra.DaySecCount;
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
        ka = this.Intern.Tick;
        long kb;
        kb = other.Intern.Tick;

        long k;
        k = kb - ka;
        return k;
    }

    private bool AddValue(long value, long valueScale)
    {
        long o;
        o = value * valueScale;

        long k;
        k = this.Intern.Tick;
        k = k + o;

        if (!this.CheckSystemTick(k))
        {
            return false;
        }

        this.Intern.Set(k);
        return true;
    }

    private bool CheckSystemTick(long value)
    {
        InternInfra infra;
        infra = this.InternInfra;

        return !(value < infra.SystemTickMin | infra.SystemTickMax < value);
    }
}