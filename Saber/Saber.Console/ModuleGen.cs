namespace Saber.Console;

public class ModuleGen : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.ModuleWord = this.S("Module");
        return true;
    }

    public virtual ClassGen Gen { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual String ModuleWord { get; set; }

    public virtual bool ExecuteStage()
    {
        this.ExecuteClassList();

        this.ExecuteModule();
        return true;
    }

    public virtual bool ExecuteModule()
    {
        ClassGen gen;
        gen = this.Gen;


        return true;
    }

    public virtual bool ExecuteClassList()
    {
        ClassGen gen;
        gen = this.Gen;

        long count;
        count = this.Module.Class.Count;

        gen.Text(gen.ClassInt);
        gen.Text(gen.Space);

        this.ClassListName(this.Module);
        gen.Text(gen.LimitBraceSquareLite);
        gen.TextInt(count);
        gen.Text(gen.LimitBraceSquareRite);

        gen.Text(gen.Space);
        gen.Text(gen.LimitAre);
        gen.Text(gen.NewLine);

        gen.Text(gen.LimitBraceLite);
        gen.Text(gen.NewLine);

        gen.IndentCount = gen.IndentCount + 1;

        Iter iter;
        iter = gen.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            gen.TextIndent();
            gen.Text(gen.CastInt);
            gen.Text(gen.LimitBraceRoundLite);
            gen.ClassAnyName(varClass);
            gen.Text(gen.LimitBraceRoundRite);
            gen.Text(gen.LimitComma);
            gen.Text(gen.NewLine);
        }
        iter.Clear();

        gen.IndentCount = gen.IndentCount - 1;

        gen.Text(gen.LimitBraceRite);
        gen.Text(gen.NewLine);
        return true;
    }

    public virtual bool ClassListName(ClassModule module)
    {
        ClassGen gen;
        gen = this.Gen;

        gen.ModuleRef(module.Ref);
        gen.Text(gen.NameCombine);
        gen.Text(gen.ClassWord);
        gen.Text(gen.ListWord);
        return true;
    }

    public virtual bool ModuleName(ClassModule module)
    {
        ClassGen gen;
        gen = this.Gen;

        gen.ModuleRef(module.Ref);
        gen.Text(gen.NameCombine);
        gen.Text(this.ModuleWord);
        return true;
    }
}