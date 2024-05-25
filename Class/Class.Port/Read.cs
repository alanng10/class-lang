namespace Class.Port;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = new CountReadOperate();
        this.CountOperate.Read = this;
        this.CountOperate.Init();
        this.StringOperate = new StringReadOperate();
        this.StringOperate.Read = this;
        this.StringOperate.Init();
        this.SetOperate = new SetReadOperate();
        this.SetOperate.Read = this;
        this.SetOperate.Init();

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
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual string Colon { get; set; }
    protected virtual int Row { get; set; }

    public virtual bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        this.LineList = this.ClassInfra.TextCreate(this.Source);
        
        ReadArg arg;
        arg = new ReadArg();
        arg.Init();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        long aa;
        aa = arg.StringIndex;
        aa = aa * sizeof(uint) * 3;
        arg.StringTextData = this.CreateData(aa);
        aa = arg.ArrayIndex;
        aa = aa * sizeof(uint);
        arg.ArrayCountData = this.CreateData(aa);

        this.Operate = this.StringOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        arg.StringArray = listInfra.ArrayCreate(arg.StringIndex);
        arg.ArrayArray = listInfra.ArrayCreate(arg.ArrayIndex);
        arg.PortArray = listInfra.ArrayCreate(arg.PortIndex);
        arg.ModuleRefArray = listInfra.ArrayCreate(arg.ModuleRefIndex);
        arg.ImportArray = listInfra.ArrayCreate(arg.ImportIndex);
        arg.ExportArray = listInfra.ArrayCreate(arg.ExportIndex);
        arg.StorageArray = listInfra.ArrayCreate(arg.StorageIndex);

        

        this.Arg = null;
        return true;
    }

    protected virtual bool ResetStageIndex()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.StringIndex = 0;
        arg.ArrayIndex = 0;
        arg.PortIndex = 0;
        arg.ModuleRefIndex = 0;
        arg.ImportIndex = 0;
        arg.ImportClassIndex = 0;
        arg.ExportIndex = 0;
        arg.StorageIndex = 0;
        return true;
    }

    protected virtual bool ExecuteCreateString()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        ReadArg arg;
        arg = this.Arg;
        Array lineList;
        lineList = this.LineList;
        Text text;
        text = this.Text;
        Range range;
        range = text.Range;
        Data textData;
        textData = arg.StringTextData;
        Array array;
        array = arg.StringArray;
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long nn;
            nn = i;
            nn = nn * 3;
            int row;
            int index;
            int countA;
            uint u;
            u = infraInfra.DataMidGet(textData, nn * sizeof(uint));
            row = (int)u;
            nn = nn + 1;
            u = infraInfra.DataMidGet(textData, nn * sizeof(uint));
            index = (int)u;
            nn = nn + 1;
            u = infraInfra.DataMidGet(textData, nn * sizeof(uint));
            countA = (int)u;

            Text line;
            line = (Text)lineList.Get(row);

            text.Data = line.Data;
            range.Index = index;
            range.Count = countA;

            string a;
            a = textInfra.StringCreate(text);

            array.Set(i, a);
            
            i = i + 1;
        }
        return true;
    }

    protected virtual Data CreateData(long count)
    {
        Data a;
        a = new Data();
        a.Count = count;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteStage()
    {
        this.Port = this.ExecutePort();
        return true;
    }

    protected virtual Port ExecutePort()
    {
        return null;
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