namespace Avalon.Text;

public class IntFormatCountState : FormatCountState
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        long value;
        value = arg.ValueInt;
        value = this.InfraInfra.Int60(value);

        int count;
        count = this.Format.IntDigitCount(value, arg.Base);
        this.Result = count;
        return true;
    }
}