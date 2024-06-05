namespace Avalon.Console;

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
        ProcessStartMaide maideA;
        maideA = new ProcessStartMaide(Process.InternStart);
        this.ProcessStartMaideAddress = new MaideAddress();
        this.ProcessStartMaideAddress.Delegate = maideA;
        this.ProcessStartMaideAddress.Init();

        ProcessFinishMaide maideB;
        maideB = new ProcessFinishMaide(Process.InternFinish);
        this.ProcessFinishMaideAddress = new MaideAddress();
        this.ProcessFinishMaideAddress.Delegate = maideB;
        this.ProcessFinishMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress ProcessStartMaideAddress { get; set; }
    public virtual MaideAddress ProcessFinishMaideAddress { get; set; }
}