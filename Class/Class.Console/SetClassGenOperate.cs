namespace Class.Console;

public class SetClassGenOperate : ClassGenOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        this.Format = new Format();
        this.Format.Init();

        FormatArg e;
        e = new FormatArg();
        e.Init();
        e.Kind = 1;
        e.Base = 16;
        e.Case = 0;
        e.AlignLeft = false;
        e.FieldWidth = 15;
        e.MaxWidth = 15;
        e.FillChar = '0';
        this.FormatArg = e;

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
        GenArg arg;
        arg = this.Gen.Arg;
        int index;
        index = arg.Index;

        Format format;
        format = this.Format;

        FormatArg e;
        e = this.FormatArg;

        Text kk;
        kk = this.FormatText;

        e.ValueInt = o;

        format.ExecuteArgCount(e);

        kk.Data = arg.Data;
        kk.Range.Index = index;
        kk.Range.Count = e.Count;

        format.ExecuteArgResult(e, kk);

        e.HasCount = false;
        e.Count = 0;
        e.ValueCount = 0;
        e.ValueInt = 0;
        
        kk.Data = null;
        kk.Range.Index = 0;
        kk.Range.Count = 0;

        index = index + 15;
        arg.Index = index;
        return true;
    }
}