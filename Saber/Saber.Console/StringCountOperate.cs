namespace Saber.Console;

public class StringCountOperate : StringOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual long StringStart { get; set; }

    public override bool ExecuteString(String value)
    {
        StringArg arg;
        arg = this.Travel.Arg;

        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteClassStart(long index)
    {
        StringArg arg;
        arg = this.Travel.Arg;
        this.StringStart = arg.Index;
        return true;
    }

    public override bool ExecuteClassEnd(long index)
    {
        StringArg arg;
        arg = this.Travel.Arg;

        long stringCount;
        stringCount = arg.Index - this.StringStart;

        Data data;
        data = arg.StringCountData;

        long ka;
        ka = index * sizeof(long);
        this.InfraInfra.DataIntSet(data, ka, stringCount);

        this.StringStart = 0;
        return true;
    }
}