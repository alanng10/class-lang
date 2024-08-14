namespace Avalon.Text;

public class TextWriteCountState : WriteCountState
{
    public override bool Execute()
    {
        WriteArg arg;
        arg = (WriteArg)this.Arg;

        Text text;
        text = (Text)arg.Value.Any;

        long a;
        a = text.Range.Count;

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}