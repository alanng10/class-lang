namespace Saber.Console;

public class BinaryStateCountOperate : BinaryStateOperate
{
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