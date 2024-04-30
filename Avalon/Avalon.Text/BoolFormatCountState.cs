namespace Avalon.Text;

public class BoolFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        
        Format format;
        format = this.Format;
        Infra textInfra;
        textInfra = format.TextInfra;
        bool b;
        b = arg.ValueBool;
        int a;
        a = 0;
        if (!b)
        {
            a = textInfra.BoolFalseString.Length;
        }
        if (b)
        {
            a = textInfra.BoolTrueString.Length;
        }
        this.Result = a;
        return true;
    }
}