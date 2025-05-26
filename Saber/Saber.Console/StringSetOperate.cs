namespace Saber.Console;

public class StringSetOperate : StringOperate
{
    public override bool ExecuteString(String value)
    {
        StringArg arg;
        arg = this.Travel.Arg;

        long index;
        index = arg.Index;

        arg.Array.SetAt(index, value);

        index = index + 1;

        arg.Index = index;
        return true;
    }
}