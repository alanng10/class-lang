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
}