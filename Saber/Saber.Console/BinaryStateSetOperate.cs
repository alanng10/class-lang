namespace Saber.Console;

public class BinaryStateSetOperate : BinaryStateOperate
{
    public override bool ExecuteByte(long value)
    {
        BinaryStateArg arg;
        arg = this.State.Arg;

        long index;
        index = arg.Index;

        arg.Data.Set(index, value);

        index = index + 1;
        arg.Index = index;
        return true;
    }
}