namespace Z.Tool.Infra.StatSlashCape;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("SlashCape");
        this.ValuePostfix = this.S("Cap");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListSlashCape.txt");
        return base.Execute();
    }

    protected override ListEntry GetItemEntry(String line)
    {
        Text kk;
        kk = this.TextCreate(line);

        Array k;
        k = this.TextLimit(kk, this.TB(this.S(" ")));

        Text kaa;
        kaa = k.GetAt(0) as Text;

        Text kab;
        kab = k.GetAt(1) as Text;

        String ka;
        ka = this.StringCreate(kaa);

        String kb;
        kb = this.StringCreate(kab);

        ListEntry a;
        a = new ListEntry();
        a.Init();
        a.Index = ka;
        a.Value = kb;
        return a;
    }
}