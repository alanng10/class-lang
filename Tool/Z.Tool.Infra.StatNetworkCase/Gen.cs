namespace Z.Tool.Infra.StatNetworkCase;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("NetworkCase");
        this.ScopeName = this.S("QAbstractSocket");
        this.ValuePostfix = this.S("State");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListNetworkCase.txt");

        return base.Execute();
    }
}