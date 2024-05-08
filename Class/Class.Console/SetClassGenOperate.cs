namespace Class.Console;

public class SetClassGenOperate : ClassGenOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        this.Format = new Format();
        this.Format.Init();

        this.FormatArg = new FormatArg();
        this.FormatArg.Init();

        this.FormatText = new Text();
        this.FormatText.Init();
        this.FormatText.Range = new InfraRange();
        this.FormatText.Range.Init();
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }
    protected virtual Text FormatText { get; set; }

    public override bool ExecuteText(string o)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
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

            textInfra.DataCharSet(data, index + i, c);
            i = i + 1;
        }

        index = index + count;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteChar(char o)
    {
        GenArg arg;
        arg = this.Gen.Arg;

        int index;
        index = arg.Index;

        this.TextInfra.DataCharSet(arg.Data, index, o);

        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteIntFormat(long o)
    {
        Format format;
        format = this.Format;
        FormatArg formatArg;
        formatArg = this.FormatArg;

        



        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;
        index = index + 15;
        arg.Index = index;
        return true;
    }
}