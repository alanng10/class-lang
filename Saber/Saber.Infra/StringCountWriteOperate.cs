namespace Saber.Infra;

public class StringCountWriteOperate : StringWriteOperate
{
    public override bool ExecuteChar(long n)
    {
        StringWriteArg arg;
        arg = this.Write.Arg;
        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }
}