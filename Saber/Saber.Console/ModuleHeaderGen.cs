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

        this.ExecuteExternClassList();

        gen.Text(gen.NewLine);

        this.ExecuteExternClassCompList();

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

    public virtual bool ExecuteExternClassCompList()
    {
        ClassGen gen;
        gen = this.Gen;

        long count;
        count = this.ClassCompArray.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ClassComp a;
            a = (ClassComp)this.ClassCompArray.GetAt(i);

            gen.ExecuteExternCompList(a.Field, true, gen.StateGet);
            gen.Text(gen.NewLine);

            gen.ExecuteExternCompList(a.Field, true, gen.StateSet);
            gen.Text(gen.NewLine);

            gen.ExecuteExternCompList(a.Maide, false, gen.StateCall);
            gen.Text(gen.NewLine);

            i = i + 1;
        }

        return true;
    }
}