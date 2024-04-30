namespace Avalon.Text;

public class SIntFormatResultState : FormatResultState
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
        Text result;
        result = this.ArgResult;
        Format format;
        format = this.Format;

        return true;
    }
}