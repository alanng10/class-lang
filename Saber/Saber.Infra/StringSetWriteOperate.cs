namespace Saber.Infra;

public class StringSetWriteOperate : StringWriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }

    public override bool ExecuteChar(long n)
    {
        StringWriteArg arg;
        arg = this.Write.Arg;
        long index;
        index = arg.Index;

        Data data;
        data = arg.Data;
        this.TextInfra.DataCharSet(data, index, n);
        
        index = index + 1;

        arg.Index = index;
        return true;
    }
}