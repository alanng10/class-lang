namespace Class.Infra;

public class AddWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    public virtual StringValueWrite Write { get; set; }
    protected virtual TextInfra TextInfra { get; set; }

    public override bool ExecuteChar(char oc)
    {
        int index;
        index = this.Write.Index;

        Data data;
        data = this.Write.Data;
        this.TextInfra.CharSet(data, index, oc);
        
        index = index + 1;

        this.Write.Index = index;
        return true;
    }
}