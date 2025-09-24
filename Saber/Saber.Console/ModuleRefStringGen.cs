namespace Saber.Console;

public class ModuleRefStringGen : TextAdd
{
    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual String Result { get; set; }

    public virtual bool Execute()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Arg = new ClassGenArg();
        gen.Arg.Init();

        gen.Operate = gen.CountOperate;

        gen.ResetStage();
        this.ExecuteStage();

        long count;
        count = gen.Arg.Index;
        count = count * sizeof(int);
        gen.Arg.Data = new Data();
        gen.Arg.Data.Count = count;
        gen.Arg.Data.Init();

        gen.Operate = gen.SetOperate;

        gen.ResetStage();
        this.ExecuteStage();

        String k;
        k = this.StringComp.CreateData(gen.Arg.Data, null);
        this.Result = k;

        gen.Operate = null;
        gen.Arg = null;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.ModuleStructName(this.Module.Ref);
        return true;
    }
}