namespace Z.Tool.Infra.StatSlashJoin;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("SlashJoin");

        this.ValuePostfix = this.S("Join");

        this.ValueOffset = this.S(" + 1");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListSlashJoin.txt");

        return base.Execute();
    }
}