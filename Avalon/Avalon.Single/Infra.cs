namespace Avalon.Single;

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
        this.ProgramFinishMaideAddress = new MaideAddress();
        this.ProgramFinishMaideAddress.Delegate = maideB;
        this.ProgramFinishMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress ProgramStartMaideAddress { get; set; }
    public virtual MaideAddress ProgramFinishMaideAddress { get; set; }
}