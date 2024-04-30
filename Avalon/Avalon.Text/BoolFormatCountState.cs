namespace Avalon.Text;

public class BoolFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        
        Format format;
        format = this.Format;
        bool b;
        b = arg.ValueBool;
        int a;
        a = 0;
        if (!b)
        {
            a = format.BoolFalseString.Length;
        }
        if (b)
        {
            a = format.BoolTrueString.Length;
        }
        this.Result = a;
        return true;
    }
}