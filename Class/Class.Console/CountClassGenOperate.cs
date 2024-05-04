namespace Class.Console;

public class CountClassGenOperate : ClassGenOperate
{
    public override bool ExecuteString(string o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;
        index = index + o.Length;
        arg.Index = index;
        return true;
    }
}