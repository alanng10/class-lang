namespace Saber.Binary;

public class WriteSetOperate : WriteOperate
{
    public override bool ExecuteByte(long value)
    {
        WriteArg arg;
        arg = this.Write.Arg;

        long index;
        index = arg.Index;

        arg.Data.Set(index, value);

        index = index + 1;
        arg.Index = index;
        return true;
    }
}