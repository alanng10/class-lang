namespace Saber.Console;

public class ImportArgGen : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.LibraryFlag = this.S("-l");
        return true;
    }

    public virtual ClassGen Gen { get; set; }
    public virtual Array ModuleRefString { get; set; }
    public virtual String Result { get; set; }
    public virtual String LibraryFlag { get; set; }

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
        long count;
        count = this.ModuleRefString.Count;

        long i;
        i = 0;
        while (i < count)
        {
            String a;
            a = this.ModuleRefString.GetAt(i) as String;

            this.ModuleImport(a);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ModuleImport(String moduleRefString)
    {
        ClassGen gen;
        gen = this.Gen;

        gen.Text(gen.Space);
        gen.Text(this.LibraryFlag);
        gen.Text(moduleRefString);
        return true;
    }
}