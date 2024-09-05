namespace Class.Console;

public class CountClassGenOperate : ClassGenOperate
{
    public override bool ExecuteChar(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteIntText(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;
        index = index + 15;
        arg.Index = index;
        return true;
    }
}