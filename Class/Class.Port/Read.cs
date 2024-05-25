namespace Class.Port;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = new CountReadOperate();
        this.CountOperate.Read = this;
        this.CountOperate.Init();
        this.StringOperate = new StringReadOperate();
        this.StringOperate.Read = this;
        this.StringOperate.Init();

        this.Text = new Text();
        this.Text.Init();
        this.Text.Range = new Range();
        this.Text.Range.Init();

        this.StringData = new StringData();
        this.StringData.Init();

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = charCompare;
        this.TextCompare.Init();

        this.Colon = ":";
        return true;
    }

    public virtual string Source { get; set; }
    public virtual Port Port { get; set; }
    public virtual ReadArg Arg { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual string Colon { get; set; }
    protected virtual int Row { get; set; }

    public virtual bool Execute()
    {
        this.LineList = this.ClassInfra.TextCreate(this.Source);
        return true;
    }

    protected virtual ModuleRef ExecuteModuleRef(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Range range;
        range = text.Range;
        Text textA;
        textA = this.Text;
        Range rangeA;
        rangeA = textA.Range;

        int nameCount;
        long version;
        nameCount = 0;
        version = 0;
        
        this.TextGet(this.Colon);
        
        int n;
        n = textInfra.Index(text, textA, this.TextCompare);
        bool b;
        b = (n == -1);
        if (b)
        {
            nameCount = range.Count;
            version = -1;
        }
        if (!b)
        {
            nameCount = n - range.Index;

            textA.Data = text.Data;
            int aa;
            int ab;
            aa = range.Index;
            ab = range.Count;
            int end;
            end = aa + ab;
            int oo;
            oo = n + 1;
            rangeA.Index = oo;
            rangeA.Count = end - oo;

            version = this.ExecuteModuleVersion(textA);
            if (version == -1)
            {
                return null;
            }
        }

        rangeA.Index = range.Index;
        rangeA.Count = nameCount;
        string name;
        name = this.ExecuteString(rangeA);
        
        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Version = version;
        return a;
    }

    protected virtual long ExecuteModuleVersion(Text text)
    {
        return 0;
    }

    protected virtual string ExecuteString(Range range)
    {
        string a;
        a = this.Operate.ExecuteString(this.Row, range);
        return a;
    }

    protected virtual bool TextGet(string o)
    {
        this.StringData.Value = o;
        this.Text.Data = this.StringData;
        this.Text.Range.Index = 0;
        this.Text.Range.Count = o.Length;
        return true;
    }
}