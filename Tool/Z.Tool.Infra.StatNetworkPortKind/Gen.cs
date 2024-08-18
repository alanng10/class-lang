namespace Z.Tool.Infra.StatNetworkPortKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("NetworkPortKind");
        this.ScopeName = this.S("QHostAddress");
        this.ValueOffset = this.S(" + 2");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListNetworkPortKind.txt");

        this.TextShareVarA = this.S("Int Stat_Var_NetworkPortKind#ItemName# = #ItemIndex#;\n");

        return base.Execute();
    }

    protected virtual String TextShareVarA { get; set; }

    protected override String GetItemShareVar(String shareVar, Iter iter, long index)
    {
        if (index < 2)
        {
            String itemName;
            itemName = (String)iter.Index;

            long ka;
            ka = index + 1;

            String itemIndex;
            itemIndex = this.S(ka.ToString());

            Text k;
            k = this.TextCreate(this.TextShareVarA);
            k = this.Replace(k, "#ItemName#", itemName);
            k = this.Replace(k, "#ItemIndex#", itemIndex);

            String a;
            a = this.StringCreate(k);
            return a;
        }

        return base.GetItemShareVar(shareVar, iter, index);
    }
}