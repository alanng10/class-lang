namespace Z.Tool.Infra.StatSlashLine;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("SlashLine");
        
        this.ValuePostfix = this.S("Line");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListSlashLine.txt");

        return base.Execute();
    }
}