namespace Saber.Console;

public class BinaryGenaCountOperate : BinaryGenaOperate
{
    public override bool ExecuteByte(long value)
    {
        BinaryGenaArg arg;
        arg = this.Gena.Arg;

        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }
}