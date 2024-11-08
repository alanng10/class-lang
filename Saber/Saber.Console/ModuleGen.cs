namespace Saber.Console;

public class ModuleGen : ClassBase
{
    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Array ClassInit { get; set; }
    public virtual Table ModuleTable { get; set; }
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
        gen.Text(gen.NewLine);

        this.ExecuteModuleInit();
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

    public virtual bool ExecuteModuleInit()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleInitName(this.Module);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        gen.TextIndent();
        gen.Text(gen.InternModuleStruct);
        gen.Text(gen.LimitAsterisk);
        gen.Text(gen.Space);
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.TextIndent();
        gen.Text(gen.VarOWord);
        gen.Text(gen.Space);
        gen.Text(gen.LimitAre);
        gen.Text(gen.Space);
        gen.Text(gen.LimitAnd);
        gen.ModuleVarName(this.Module);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.TextIndent();
        gen.Text(gen.IndexInf);
        gen.Text(gen.Space);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitDotPointer);
        gen.Text(gen.InitWord);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);
        
        gen.TextIndent();
        gen.Text(gen.LimitBraceLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        gen.TextIndent();
        gen.Text(gen.IndexReturn);
        gen.Text(gen.Space);
        gen.Text(gen.Zero);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount - 1;

        gen.TextIndent();
        gen.Text(gen.LimitBraceRite);
        gen.Text(gen.NewLine);

        gen.TextIndent();
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitDotPointer);
        gen.Text(gen.InitWord);
        gen.Text(gen.Space);
        gen.Text(gen.LimitAre);
        gen.Text(gen.Space);
        gen.Text(gen.One);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        this.ExecuteImportModuleInit();

        gen.TextIndent();
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitDotPointer);
        gen.Text(gen.ClassWord);
        gen.Text(gen.Space);
        gen.Text(gen.LimitAre);
        gen.Text(gen.Space);
        gen.Text(gen.ClassWord);
        gen.Text(gen.ListWord);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        this.ExecuteClassInit();

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceRite);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteImportModuleInit()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = iter.Index as ModuleRef;

            ClassModule module;
            module = this.ModuleTable.Get(moduleRef) as ClassModule;

            gen.TextIndent();
            gen.ModuleInitName(module);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteClassInit()
    {
        ClassGen gen;
        gen = this.Gen;

        long count;
        count = this.ClassInit.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = this.ClassInit.GetAt(i) as ClassClass;

            gen.ClassInitName(varClass);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);

            i = i + 1;
        }

        return true;
    }
}