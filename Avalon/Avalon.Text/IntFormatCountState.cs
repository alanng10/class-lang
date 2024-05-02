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

        long mask;
        mask = this.InfraInfra.IntCapValue - 1;
        value = value & mask;
        
        ulong o;
        o = (ulong)value;

        int count;
        count = this.Format.IntDigitCount(o, arg.Base);
        this.Result = count;
        return true;
    }
}