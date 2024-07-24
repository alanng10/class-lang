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
        ProgramStartMaide maideA;
        maideA = new ProgramStartMaide(Program.InternStart);
        this.ProgramStartMaideAddress = new MaideAddress();
        this.ProgramStartMaideAddress.Delegate = maideA;
        this.ProgramStartMaideAddress.Init();

        ProgramFinishMaide maideB;
        maideB = new ProgramFinishMaide(Program.InternFinish);
        this.ProgramFinishMaideAddress = new MaideAddress();
        this.ProgramFinishMaideAddress.Delegate = maideB;
        this.ProgramFinishMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress ProgramStartMaideAddress { get; set; }
    public virtual MaideAddress ProgramFinishMaideAddress { get; set; }
}