namespace Avalon.Text;

class BoolFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        
        int a;
        a = "false".Length;
        if (arg.ValueBool)
        {
            a = "true".Length;
        }
        this.Result = a;
        return true;
    }
}