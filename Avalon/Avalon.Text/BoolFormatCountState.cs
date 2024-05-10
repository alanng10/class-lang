namespace Avalon.Text;

public class BoolFormatCountState : FormatCountState
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual Infra TextInfra { get; set; }

    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        Infra textInfra;
        textInfra = this.TextInfra;
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