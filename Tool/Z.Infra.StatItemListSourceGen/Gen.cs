namespace Z.Infra.StatItemListSourceGen;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.AddMethodFileName = this.S("ToolData/System/AddMaideStatItem.txt");
        this.InitMethodFileName = this.S("ToolData/System/InitMaideStatItem.txt");
        return true;
    }

    public override long Execute()
    {
        this.OutputFilePath = this.GetOutputFilePath();
        return base.Execute();
    }

    protected virtual String StatItemClassName { get; set; }

    protected virtual String GetStatItemListFileName()
    {
        return this.AddClear().AddS("ToolData/Infra/ItemList").Add(this.StatItemClassName).AddS(".txt").AddResult();
    }

    protected virtual String GetOutputFilePath()
    {
        return this.AddClear().AddS("../../System/").Add(this.Module).AddS("/").Add(this.ClassName).AddS(".cl").AddResult();
    }

    protected override TableEntry GetItemEntry(String line)
    {
        Text name;
        name = null;
        Text value;
        value = null;

        Text k;
        k = this.TextCreate(line);

        Text ka;
        ka = this.TextCreate(this.S(" "));

        long n;
        n = this.TextIndex(k, ka);

        bool b;
        b = (n < 0);

        if (b)
        {
            name = k;
            value = k;
        }

        if (!b)
        {
            name = this.TextCreateDataRange(k.Data, 0, n);

            long index;
            index = n + 1;
            long end;
            end = k.Range.Count;
            long count;
            count = end - index;

            value = this.TextCreateDataRange(k.Data, n + 1, count);
        }

        TableEntry a;
        a = new TableEntry();
        a.Init();
        a.Index = this.StringCreate(name);
        a.Value = this.StringCreate(value);
        return a;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem")
            .AddS("(")
            .AddS("extern.Stat_").Add(this.StatItemClassName).Add(index).AddS("(").AddS("stat").AddS(")")
            .AddS(")");
        return true;
    }
}