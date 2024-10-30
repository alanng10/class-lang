namespace Avalon.Text;

public class BoolFormatCountState : FormatCountState
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual Infra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public override bool Execute()
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        StringComp stringComp;
        stringComp = this.StringComp;

        FormatArg arg;
        arg = this.Arg as FormatArg;
        
        bool b;
        b = arg.Value.Bool;
        long k;
        k = 0;
        if (!b)
        {
            k = stringComp.Count(textInfra.BoolFalseString);
        }
        if (b)
        {
            k = stringComp.Count(textInfra.BoolTrueString);
        }

        Value a;
        a = (Value)this.Result;
        a.Int = k;
        return true;
    }
}