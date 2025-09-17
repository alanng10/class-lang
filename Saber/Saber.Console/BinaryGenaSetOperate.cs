namespace Saber.Console;

public class BinaryGenaSetOperate : BinaryGenaOperate
{
    public override bool ExecuteByte(long value)
    {
        BinaryGenaArg arg;
        arg = this.Gena.Arg;

        long index;
        index = arg.Index;

        arg.Data.Set(index, value);

        index = index + 1;
        arg.Index = index;
        return true;
    }
}