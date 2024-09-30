namespace Z.Tool.Infra.StatComp;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("Comp");
        this.ScopeName = this.S("QPainter");
        this.ValuePrefix = this.S("CompositionMode_");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListComp.txt");

        return base.Execute();
    }

    protected override ListEntry GetItemEntry(String line)
    {
        Text ka;
        ka = this.Replace(this.TA(line), "Dest", this.S("Destination"));

        String k;
        k = this.StringCreate(ka);

        ListEntry a;
        a = new ListEntry();
        a.Init();
        a.Index = line;
        a.Value = k;
        return a;
    }
}