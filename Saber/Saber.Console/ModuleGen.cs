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
        gen.Text(gen.NewLine);

        this.ExecuteClassList();
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

    public virtual bool ExecuteClassList()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.IndexStatic);
        gen.Text(gen.Space);

        gen.Text(gen.InternClassStruct);
        gen.Text(gen.Space);

        gen.Text(gen.ClassWord);
        gen.Text(gen.ListWord);
        gen.Text(gen.LimitBraceSquareLite);
        gen.TextInt(this.Module.Class.Count);
        gen.Text(gen.LimitBraceSquareRite);

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }
}