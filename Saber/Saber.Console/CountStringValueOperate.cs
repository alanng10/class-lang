namespace Saber.Console;

public class CountStringValueOperate : StringValueOperate
{
    public override bool Execute(String k)
    {
        long index;
        index = this.Traverse.Index;
        index = index + 1;
        this.Traverse.Index = index;
        return false;
    }
}