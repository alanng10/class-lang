namespace Avalon.Time;

class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        IntervalElapseMaide maideA;
        maideA = new IntervalElapseMaide(Event.InternElapse);
        this.IntervalElapseMaideAddress = new MaideAddress();
        this.IntervalElapseMaideAddress.Delegate = maideA;
        this.IntervalElapseMaideAddress.Init();

        this.DaySystemTickCount = TimeSpan.TicksPerDay;

        this.HourSystemTickCount = TimeSpan.TicksPerHour;

        this.MinSystemTickCount = TimeSpan.TicksPerMinute;

        this.SecSystemTickCount = TimeSpan.TicksPerSecond;

        this.MillisecSystemTickCount = TimeSpan.TicksPerMillisecond;

        this.DaySecCount = 24 * 60 * 60;

        this.SystemTickMin = DateTime.MinValue.Ticks;
        this.SystemTickMax = DateTime.MaxValue.Ticks;

        double k;
        k = this.DaySystemTickCount;

        long ka;
        ka = 1 << 30;

        k = k / ka;

        this.SystemTickPerTick = k;
        return true;
    }

    public virtual MaideAddress IntervalElapseMaideAddress { get; set; }

    public virtual long DaySystemTickCount { get; set; }

    public virtual long HourSystemTickCount { get; set; }

    public virtual long MinSystemTickCount { get; set; }

    public virtual long SecSystemTickCount { get; set; }

    public virtual long MillisecSystemTickCount { get; set; }

    public virtual int DaySecCount { get; set; }

    public virtual long SystemTickMin { get; set; }

    public virtual long SystemTickMax { get; set; }

    public virtual double SystemTickPerTick { get; set; }
}