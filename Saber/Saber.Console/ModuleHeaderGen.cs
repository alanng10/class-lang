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

    public virtual bool ExecuteStage()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.PragmaOnce();
        gen.Text(gen.NewLine);

        gen.Include(gen.IncludeValueInfra);
        gen.Include(gen.IncludeValueInfraIntern);
        gen.Text(gen.NewLine);

        this.ExecuteExternModuleStruct();
        gen.Text(gen.NewLine);

        this.ExecuteExternModuleInit();
        gen.Text(gen.NewLine);

        this.ExecuteExternModuleVar();
        gen.Text(gen.NewLine);

        this.ExecuteExternModuleEntry();
        gen.Text(gen.NewLine);

        this.ExecuteExternModuleCount();
        gen.Text(gen.NewLine);

        this.ExecuteExternImportModuleStruct();
        gen.Text(gen.NewLine);

        this.ExecuteExternImportModuleInit();
        gen.Text(gen.NewLine);

        this.ExecuteExternClassInit();
        return true;
    }

    public virtual bool ExecuteExternModuleStruct()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);
        gen.Text(gen.Space);

        gen.Text(gen.IndexExtern);
        gen.Text(gen.Space);

        gen.Text(gen.InternModuleStruct);
        gen.Text(gen.Space);

        gen.ModuleStructName(this.Module.Ref);

        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternImportModuleStruct()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef module;
            module = iter.Index as ModuleRef;

            gen.Text(gen.ImportWord);
            gen.Text(gen.ApiWord);
            gen.Text(gen.Space);

            gen.Text(gen.IndexExtern);
            gen.Text(gen.Space);

            gen.Text(gen.InternModuleStruct);
            gen.Text(gen.Space);

            gen.ModuleStructName(module);

            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteExternModuleInit()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);
        gen.Text(gen.Space);

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleInitName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleVar()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);
        gen.Text(gen.Space);

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleVarName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleEntry()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);
        gen.Text(gen.Space);

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleEntryName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleCount()
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.ExportWord);
        gen.Text(gen.ApiWord);
        gen.Text(gen.Space);

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        gen.ModuleCountName(this.Module.Ref);
        gen.Text(gen.LimitBraceRoundLite);
        gen.Text(gen.LimitBraceRoundRite);
        gen.Text(gen.LimitSemicolon);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ExecuteExternImportModuleInit()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef module;
            module = iter.Index as ModuleRef;

            gen.Text(gen.ImportWord);
            gen.Text(gen.ApiWord);
            gen.Text(gen.Space);

            gen.Text(gen.ClassInt);
            gen.Text(gen.Space);

            gen.ModuleInitName(module);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteExternClassInit()
    {
        ClassGen gen;
        gen = this.Gen;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            gen.Text(gen.ClassInt);
            gen.Text(gen.Space);

            gen.ClassInitName(varClass);
            gen.Text(gen.LimitBraceRoundLite);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitSemicolon);
            gen.Text(gen.NewLine);
        }

        iter.Clear();
        return true;
    }
}