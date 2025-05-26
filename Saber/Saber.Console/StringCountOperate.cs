namespace Saber.Console;

public class StringCountOperate : StringOperate
{
    public override bool Execute(String k)
    {
        StringArg arg;
        arg = this.Travel.Arg;

        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }
}