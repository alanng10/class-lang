namespace Saber.Console;

public class StringValueCountOperate : StringValueOperate
{
    public override bool Execute(String k)
    {
        long index;
        index = this.Travel.Index;
        index = index + 1;
        this.Travel.Index = index;
        return true;
    }
}