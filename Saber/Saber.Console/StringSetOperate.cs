namespace Saber.Console;

public class StringSetOperate : StringOperate
{
    public override bool Execute(String k)
    {
        StringArg arg;
        arg = this.Travel.Arg;

        long index;
        index = arg.Index;

        arg.Array.SetAt(index, k);

        index = index + 1;

        arg.Index = index;
        return true;
    }
}