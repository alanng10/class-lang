namespace Class.Console;

public class CountClassGenOperate : ClassGenOperate
{
    public override bool ExecuteText(string o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;
        index = index + o.Length;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteChar(char o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteIntFormat(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;
        index = index + 15;
        arg.Index = index;
        return true;
    }
}