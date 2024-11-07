namespace Saber.Console;

public class ModuleHeaderGen : ClassBase
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

        gen.PragmaOnce();
        gen.Text(gen.NewLine);

        gen.Include(gen.IncludeValueInfra);
        gen.Include(gen.IncludeValueInfraIntern);
        gen.Text(gen.NewLine);

        this.ExecuteExternModule();
        gen.Text(gen.NewLine);

        this.ExecuteExternClassList();
        gen.Text(gen.NewLine);

        this.ExecuteExternClassCompList();

        this.ExecuteExternBaseItemList();

        return true;
    }

    public virtual bool ExecuteExternModule()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);

        gen.Text(gen.Space);

        gen.Text(gen.IndexExtern);
        gen.Text(gen.Space);

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleVarName(this.Module);
        gen.Text(gen.LimitBraceSquareLite);
        gen.TextInt(2);
        gen.Text(gen.LimitBraceSquareRite);
        
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternClassList()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            gen.Text(gen.ExportWord);
            gen.Text(gen.ApiWord);

            gen.Text(gen.Space);

            gen.Text(gen.IndexExtern);
            gen.Text(gen.Space);

            gen.Text(gen.ClassInt);
            gen.Text(gen.Space);

            gen.ClassVarName(varClass);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        this.ImportClass.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            gen.Text(gen.ImportWord);
            gen.Text(gen.ApiWord);

            gen.Text(gen.Space);

            gen.Text(gen.IndexExtern);
            gen.Text(gen.Space);

            gen.Text(gen.ClassInt);
            gen.Text(gen.Space);

            gen.ClassVarName(varClass);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteExternBaseItemList()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            gen.Text(gen.ExportWord);
            gen.Text(gen.ApiWord);

            gen.Text(gen.Space);

            gen.Text(gen.IndexExtern);

            gen.Text(gen.Space);

            gen.Text(gen.ClassInt);

            gen.Text(gen.Space);

            gen.BaseItemName(varClass);

            gen.Text(gen.LimitBraceSquareLite);
            gen.TextInt(4);
            gen.Text(gen.LimitBraceSquareRite);

            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }
}