namespace Saber.Console;

public class StringValueTraverse : Traverse
{
    public virtual long Index { get; set; }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        return true;
    }
}