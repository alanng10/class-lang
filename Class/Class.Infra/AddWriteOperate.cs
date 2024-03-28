namespace Class.Infra;

public class AddWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual StringValueWrite Write { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public override bool ExecuteChar(char oc)
    {
        int index;
        index = this.Write.Index;

        Data data;
        data = this.Write.Data;
        this.InfraInfra.CharSet(data, 0, index, oc);
        
        index = index + 1;

        this.Write.Index = index;
        return true;
    }
}