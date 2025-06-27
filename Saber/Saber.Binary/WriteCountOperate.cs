namespace Saber.Binary;

public class WriteCountOperate : WriteOperate
{
    public override bool ExecuteByte(long value)
    {
        WriteArg arg;
        arg = this.Write.Arg;

        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }
}