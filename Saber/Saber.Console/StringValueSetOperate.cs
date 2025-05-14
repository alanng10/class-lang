namespace Saber.Console;

public class StringValueSetOperate : StringValueOperate
{
    public override bool Execute(String k)
    {
        long index;
        index = this.Travel.Index;

        this.Travel.Array.SetAt(index, k);

        index = index + 1;

        this.Travel.Index = index;
        return true;
    }
}