namespace Saber.Console;

public class SetStringValueOperate : StringValueOperate
{
    public override bool Execute(String k)
    {
        long index;
        index = this.Traverse.Index;
        index = index + 1;

        this.Traverse.Array.SetAt(index, k);

        this.Traverse.Index = index;
        return true;
    }
}