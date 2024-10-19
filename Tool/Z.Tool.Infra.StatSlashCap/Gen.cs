namespace Z.Tool.Infra.StatSlashCap;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("SlashCap");

        this.ValuePostfix = this.S("Cap");

        this.ValueOffset = this.S(" + 1");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListSlashCap.txt");

        return base.Execute();
    }
}