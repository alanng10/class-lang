namespace Class.Refer;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    protected virtual int ExecuteByte()
    {
        Data data;
        data = this.Data;
        int index;
        index = this.Index;
        if (!(index < data.Count))
        {
            return -1;
        }

        int a;
        a = this.Data.Get(index);
        return a;
    }
}