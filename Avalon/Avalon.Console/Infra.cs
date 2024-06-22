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
        maideA = new ProcessStartMaide(Program.InternStart);
        this.ProgramStartMaideAddress = new MaideAddress();
        this.ProgramStartMaideAddress.Delegate = maideA;
        this.ProgramStartMaideAddress.Init();

        ProcessFinishMaide maideB;
        maideB = new ProcessFinishMaide(Program.InternFinish);
        this.ProcessFinishMaideAddress = new MaideAddress();
        this.ProcessFinishMaideAddress.Delegate = maideB;
        this.ProcessFinishMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress ProgramStartMaideAddress { get; set; }
    public virtual MaideAddress ProcessFinishMaideAddress { get; set; }
}