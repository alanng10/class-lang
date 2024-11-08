namespace Saber.Console;

public class ModuleGen : ClassBase
{
    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual String Result { get; set; }

    public virtual bool Execute()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Arg = new GenArg();
        gen.Arg.Init();

        gen.Operate = gen.CountOperate;

        gen.ResetStageIndex();
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

        gen.ResetStageIndex();
        this.ExecuteStage();

        gen.Operate = null;
        gen.Arg = null;

        String o;
        o = this.StringComp.CreateData(data, null);

        this.Result = o;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Include(gen.IncludeValueModule);
        gen.Text(gen.NewLine);

        this.ExecuteModuleVar();
        return true;
    }

    public virtual bool ExecuteModuleVar()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.InternModuleStruct);
        gen.Text(gen.Space);

        gen.ModuleVarName(this.Module);

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

}