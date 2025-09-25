namespace Saber.Console;

public class BinaryStateCountOperate : BinaryStateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public override long ExecuteString()
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        long index;
        index = arg.StringIndex;

        long a;
        a = index;

        index = index + 1;
        arg.StringIndex = index;
        return a;
    }

    public override bool ExecuteTravelStart()
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        this.State.ExecuteCount(0);

        arg.OperateIndex = 0;
        return true;
    }

    public override bool ExecuteTravelEnd()
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        long count;
        count = arg.OperateIndex;

        long ka;
        ka = arg.StateIndex;
        ka = ka * sizeof(long);

        this.InfraInfra.DataIntSet(arg.OperateCountData, ka, count);

        arg.OperateIndex = 0;
        arg.StateIndex = arg.StateIndex + 1;
        return true;
    }

    public override bool ExecuteOperate()
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        arg.OperateIndex = arg.OperateIndex + 1;
        return true;
    }

    public override bool ExecuteByte(long value)
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }
}