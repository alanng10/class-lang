namespace Avalon.Time;

public class Time : Any
{
    public override bool Init()
    {
        base.Init();
        return true;
    }

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

    protected virtual bool CheckYear(int value)
    {
        return !(value < 1 | 9999 < value);
    }

    protected virtual bool CheckMonth(int value)
    {
        return !(value < 1 | 12 < value);
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
        Extern.Time_Current(this.Intern);
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
}