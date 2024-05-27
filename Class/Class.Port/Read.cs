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

        this.IntParse = new IntParse();
        this.IntParse.Init();

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
        this.Dot = ".";
        this.SquareLeft = "[";
        this.SquareRight = "]";
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
    protected virtual IntParse IntParse { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual string Colon { get; set; }
    protected virtual string Dot { get; set; }
    protected virtual string SquareLeft { get; set; }
    protected virtual string SquareRight { get; set; }
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
        arg.ImportClassArray = listInfra.ArrayCreate(arg.ImportClassIndex);
        arg.ExportArray = listInfra.ArrayCreate(arg.ExportIndex);
        arg.StorageArray = listInfra.ArrayCreate(arg.StorageIndex);
        this.ExecuteCreateString();
        this.ExecuteCreateArray();
        this.ExecuteCreatePort();
        this.ExecuteCreateModuleRef();
        this.ExecuteCreateImport();
        this.ExecuteCreateImportClass();
        this.ExecuteCreateExport();
        this.ExecuteCreateStorage();

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

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
        Text text;
        text = this.Text;
        Range range;
        range = text.Range;
        Data textData;
        textData = arg.StringTextData;
        int ka;
        ka = sizeof(uint);
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
            long na;
            na = nn * ka;
            uint u;
            u = infraInfra.DataMidGet(textData, na);
            row = (int)u;
            
            na = (nn + 1) * ka;
            u = infraInfra.DataMidGet(textData, na);
            index = (int)u;
            
            na = (nn + 2) * ka;
            u = infraInfra.DataMidGet(textData, na);
            countA = (int)u;

            Text line;
            line = this.LineText(row);

            text.Data = line.Data;
            range.Index = index;
            range.Count = countA;

            string a;
            a = textInfra.StringCreate(text);
            text.Data = null;

            array.Set(i, a);
            
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateArray()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ReadArg arg;
        arg = this.Arg;

        Data data;
        data = arg.ArrayCountData;
        Array array;
        array = arg.ArrayArray;
        
        int ka;
        ka = sizeof(uint);
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long nn;
            nn = i;
            nn = nn * ka;
            uint u;
            u = infraInfra.DataMidGet(data, nn);
            int k;
            k = (int)u;
            
            Array a;
            a = listInfra.ArrayCreate(k);
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreatePort()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.PortArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Port a;
            a = new Port();
            a.Init();
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateModuleRef()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.ModuleRefArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = new ModuleRef();
            a.Init();
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateImport()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.ImportArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Import a;
            a = new Import();
            a.Init();
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateImportClass()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.ImportClassArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ImportClass a;
            a = new ImportClass();
            a.Init();
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateExport()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.ExportArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Export a;
            a = new Export();
            a.Init();
            array.Set(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateStorage()
    {
        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.StorageArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Storage a;
            a = new Storage();
            a.Init();
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
        bool b;
        b = this.CheckHead("Module");
        if (!b)
        {
            return null;
        }

        b = this.NextRow();
        if (!b)
        {
            return null;
        }

        Text line;
        line = this.LineText(this.Row);
        
        ModuleRef module;
        module = this.ExecuteModuleRef(line);
        if (module == null)
        {
            return null;
        }

        b = this.NextRow();
        if (!b)
        {
            return null;
        }

        b = this.CheckHead("Import");
        if (!b)
        {
            return null;
        }

        return null;
    }

    protected virtual int SectionLineCount()
    {
        int lineCount;
        lineCount = this.LineList.Count;

        int o;
        o = -1;
        bool b;
        b = false;
        int row;
        row = this.Row;
        int count;
        count = lineCount - row;
        int i;
        i = 0;
        while (!b & i < count)
        {
            Text text;
            text = this.LineText(row + i);
            if (text.Range.Count == 0)
            {
                b = true;
                o = i;
            }

            i = i + 1;
        }
        
        if (b)
        {
            return o;
        }

        return -1;
    }

    protected virtual bool CheckHead(string head)
    {
        Text line;
        line = this.LineText(this.Row);

        Range range;
        range = line.Range;

        int index;
        int count;
        index = range.Index;
        count = range.Count;

        bool a;
        a = this.CheckHeadAll(line, head);

        range.Index = index;
        range.Count = count;

        return a;
    }

    protected virtual bool CheckHeadAll(Text line, string head)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        
        Range range;
        range = line.Range;

        int index;
        int count;
        index = range.Index;
        count = range.Count;

        if (!((head.Length + 2) == count))
        {
            return false;
        }

        Text textA;
        textA = this.Text;
        Compare compare;
        compare = this.TextCompare;

        this.TextGet(this.SquareLeft);

        range.Count = 1;

        if (!textInfra.Equal(line, textA, compare))
        {
            return false;
        }

        this.TextGet(this.SquareRight);

        range.Index = index + count - 1;

        if (!textInfra.Equal(line, textA, compare))
        {
            return false;
        }
        
        this.TextGet(head);

        range.Index = index + 1;
        range.Count = count - 2;

        if (!textInfra.Equal(line, textA, compare))
        {
            return false;
        }

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

            int aa;
            int ab;
            aa = range.Index;
            ab = range.Count;
            int oo;
            oo = n + 1;
            range.Index = aa + oo;
            range.Count = ab - oo;

            version = this.ExecuteModuleVersion(text);

            range.Index = aa;
            range.Count = ab;
            
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
        Range range;
        range = text.Range;

        int index;
        int count;
        index = range.Index;
        count = range.Count;
        
        long a;
        a = this.ExecuteModuleVersionAll(text);

        range.Index = index;
        range.Count = count;
        return a;
    }

    protected virtual long ExecuteModuleVersionAll(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        IntParse intParse;
        intParse = this.IntParse;
        Text textA;
        textA = this.Text;
        Compare compare;
        compare = this.TextCompare;

        Range range;
        range = text.Range;

        int index;
        int count;
        index = range.Index;
        count = range.Count;

        this.TextGet(this.Dot);

        int u;
        u = textInfra.Index(text, textA, compare);
        if (u == -1)
        {
            return -1;
        }

        int kka;
        kka = u;

        int ka;
        ka = kka + 1;
        range.Index = index + ka;
        range.Count = count - ka;
        u = textInfra.Index(text, textA, compare);
        if (!(u == 2))
        {
            return -1;
        }

        int kkb;
        kkb = u;
        int kb;
        kb = ka + kkb + 1;

        int ku;
        ku = kb + 2;
        if (!(ku == count))
        {
            return -1;
        }
        
        range.Index = index;
        range.Count = kka;

        long major;
        major = intParse.Execute(text, 10, false);
        if (major == -1)
        {
            return -1;
        }

        long oo;
        oo = 1;
        oo = oo << 44;
        if (!(major < oo))
        {
            return -1;
        }

        range.Index = index + ka;
        range.Count = kkb;

        long minor;
        minor = intParse.Execute(text, 10, false);
        if (minor == -1)
        {
            return -1;
        }

        range.Index = index + kb;
        range.Count = 2;

        long revision;
        revision = intParse.Execute(text, 10, false);
        if (revision == -1)
        {
            return -1;
        }

        long a;
        a = 0;
        a = a | revision;
        a = a | (minor << 8);
        a = a | (major << 16);
        return a;
    }

    protected virtual Text LineText(int row)
    {
        return (Text)this.LineList.Get(row);
    }

    protected virtual bool NextRow()
    {
        int a;
        a = this.Row;
        a = a + 1;
        this.Row = a;

        if (!this.InfraInfra.CheckIndex(this.LineList.Count, a))
        {
            return false;
        }
        return true;
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