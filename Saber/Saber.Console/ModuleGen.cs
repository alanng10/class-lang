namespace Saber.Console;

public class ModuleGen : TextAdd
{
    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual long ModuleTableCount { get; set; }
    public virtual Array ClassInit { get; set; }
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

    public virtual bool ExecuteStage()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Include(gen.IncludeValueModule);
        gen.Text(gen.NewLine);

        this.ExecuteModuleStruct();
        gen.Text(gen.NewLine);

        this.ExecuteModuleVar();
        gen.Text(gen.NewLine);

        this.ExecuteModuleEntry();
        gen.Text(gen.NewLine);

        this.ExecuteModuleCount();
        gen.Text(gen.NewLine);

        this.ExecuteClassList();
        gen.Text(gen.NewLine);

        this.ExecuteModuleInit();
        return true;
    }

    public virtual bool ExecuteModuleStruct()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.InternModuleStruct);
        gen.Text(gen.Space);

        gen.ModuleStructName(this.Module.Ref);

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleVar()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleVarName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceCurveLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        gen.TextIndent();
        gen.Text(gen.IndexReturn);
        gen.Text(gen.Space);
        
        gen.Text(gen.CastInt);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitAnd);
        gen.ModuleStructName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundRite);

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceCurveRite);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleEntry()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleEntryName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceCurveLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        gen.TextIndent();
        gen.Text(gen.IndexReturn);
        gen.Text(gen.Space);

        bool b;
        b = (this.Module.Entry == null);
        if (b)
        {
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.ClassInt);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.ClassSInt);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitSub);
            gen.Text(gen.One);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitBraceRoundRite);
        }
        if (!b)
        {
            ClassClass varClass;
            varClass = this.Module.Class.Get(this.Module.Entry) as ClassClass;

            gen.TextInt(varClass.Index);
        }

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceCurveRite);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleCount()
    {
        long count;
        count = this.ModuleTableCount + 1;

        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleCountName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceCurveLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        gen.TextIndent();
        gen.Text(gen.IndexReturn);
        gen.Text(gen.Space);

        gen.TextInt(count);
        
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceCurveRite);
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
        gen.Text(gen.LimitBraceRightLite);
        gen.TextInt(this.Module.Class.Count);
        gen.Text(gen.LimitBraceRightRite);

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

        gen.ModuleInitName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceCurveLite);
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
        gen.ModuleStructName(this.Module.Ref);
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
        gen.Text(gen.LimitBraceCurveLite);
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
        gen.Text(gen.LimitBraceCurveRite);
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
        gen.Text(gen.InternModuleSet);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

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

        gen.TextIndent();
        gen.Text(gen.VarOWord);
        gen.Text(gen.LimitDotPointer);
        gen.Text(gen.CountWord);
        gen.Text(gen.Space);
        gen.Text(gen.LimitAre);
        gen.Text(gen.Space);
        gen.TextInt(this.Module.Class.Count);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        this.ExecuteClassInit();

        gen.TextIndent();
        gen.Text(gen.IndexReturn);
        gen.Text(gen.Space);
        gen.Text(gen.Zero);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceCurveRite);
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

            gen.TextIndent();
            gen.ModuleInitName(moduleRef);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundRite);
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

            gen.TextIndent();
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