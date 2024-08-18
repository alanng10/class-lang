namespace Z.Tool.Infra.StatNetworkStatus;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("NetworkStatus");
        this.ScopeName = this.S("QAbstractSocket");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListNetworkStatus.txt");

        return base.Execute();
    }

    protected override String GetItemShareVar(String shareVar, Iter iter, long index)
    {
        if (index == 0)
        {
            String ka;
            ka = this.S("Int Stat_Var_NetworkStatus#ItemName# = QAbstractSocket::UnknownSocketError + 1;\n");

            String itemName;
            itemName = (String)iter.Index;

            Text k;
            k = this.TextCreate(ka);
            k = this.Replace(k, "#ItemName#", itemName);

            String a;
            a = this.StringCreate(k);
            return a;
        }

        return base.GetItemShareVar(shareVar, iter, index);
    }
}