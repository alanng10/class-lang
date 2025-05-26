namespace Saber.Console;

public class ModuleHeaderGen : TextAdd
{
    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual Array ClassCompArray { get; set; }
    public virtual String Result { get; set; }

    public virtual bool Execute()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Arg = new GenArg();
        gen.Arg.Init();

        gen.Operate = gen.CountOperate;

        gen.ResetStage();
        this.ExecuteStage();

        long nn;
        nn = gen.Arg.Index;
        nn = nn * sizeof(uint);
        Data data;
        data = new Data();
        data.Count = nn;
        data.Init();
        gen.Arg.Data = data;

        gen.Operate = gen.SetOperate;

        gen.ResetStage();
        this.ExecuteStage();

        gen.Operate = null;
        gen.Arg = null;

        String o;
        o = this.StringComp.CreateData(data, null);

        this.Result = o;
        return true;
    }


}