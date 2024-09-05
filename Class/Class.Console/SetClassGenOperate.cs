namespace Class.Console;

public class SetClassGenOperate : ClassGenOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        this.Format = new Format();
        this.Format.Init();
        this.Format.CharForm = charForm;

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
        this.FormatArgInt = e;

        this.FormatText = new Text();
        this.FormatText.Init();
        this.FormatText.Range = new InfraRange();
        this.FormatText.Range.Init();
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArgInt { get; set; }
    protected virtual Text FormatText { get; set; }

    public override bool ExecuteChar(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;

        long index;
        index = arg.Index;

        this.TextInfra.DataCharSet(arg.Data, index, o);

        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteIntText(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;

        Format format;
        format = this.Format;

        FormatArg e;
        e = this.FormatArgInt;

        Text kk;
        kk = this.FormatText;

        e.Value.Int = o;

        format.ExecuteArgCount(e);

        kk.Data = arg.Data;
        kk.Range.Index = index;
        kk.Range.Count = e.Count;

        format.ExecuteArgResult(e, kk);

        e.Count = 0;
        e.ValueCount = 0;
        e.Value.Int = 0;
        
        kk.Data = null;
        kk.Range.Index = 0;
        kk.Range.Count = 0;

        index = index + 15;
        arg.Index = index;
        return true;
    }
}