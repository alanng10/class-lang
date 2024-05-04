namespace Class.Console;

public class SetGenOperate : GenOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }

    public override bool ExecuteString(string o)
    {
        TextInfra textInfra;
        textInfra = TextInfra.This;
        GenArg arg;
        arg = this.Gen.Arg;
        
        int index;
        index = arg.Index;
        Data data;
        data = arg.Data;

        int count;
        count = o.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char c;
            c = o[i];

            textInfra.DataCharSet(data, index, c);
            i = i + 1;
        }

        index = index + count;
        arg.Index = index;
        return true;
    }
}