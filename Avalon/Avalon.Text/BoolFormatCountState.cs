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
        StringComp stringComp;
        stringComp = this.StringComp;

        WriteArg arg;
        arg = (WriteArg)this.Arg;

        Infra textInfra;
        textInfra = this.TextInfra;
        
        bool b;
        b = arg.Value.Bool;
        long a;
        a = 0;
        if (!b)
        {
            a = stringComp.Count(textInfra.BoolFalseString);
        }
        if (b)
        {
            a = stringComp.Count(textInfra.BoolTrueString);
        }

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}