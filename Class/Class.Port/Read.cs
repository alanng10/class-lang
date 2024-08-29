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
        this.StringComp = StringComp.This;
        this.TextStringValue = TextStringValue.This;

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

        LessInt charLess;
        charLess = new LessInt();
        charLess.Init();
        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();
        this.TextLess = new TextLess();
        this.TextLess.CharLess = charLess;
        this.TextLess.LiteCharForm = charForm;
        this.TextLess.RiteCharForm = charForm;
        this.TextLess.Init();

        this.TextNewLine = this.TextInfra.TextCreateStringData(this.ClassInfra.NewLine, null);

        this.Colon = this.S(":");
        this.Dot = this.S(".");
        this.SquareLeft = this.S("[");
        this.SquareRight = this.S("]");
        this.Space = this.S(" ");
        this.Indent = this.S("    ");
        this.HeadModule = this.S("Module");
        return true;
    }

    public virtual String Source { get; set; }
    public virtual Port Port { get; set; }
    public virtual ReadArg Arg { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual IntParse IntParse { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual TextLess TextLess { get; set; }
    protected virtual Text TextNewLine { get; set; }
    protected virtual String Colon { get; set; }
    protected virtual String Dot { get; set; }
    protected virtual String SquareLeft { get; set; }
    protected virtual String SquareRight { get; set; }
    protected virtual String Space { get; set; }
    protected virtual String Indent { get; set; }
    protected virtual String HeadModule { get; set; }

    public virtual bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        String source;
        source = this.Source;

        Text aaa;
        aaa = this.TextInfra.TextCreateStringData(source, null);

        this.LineList = this.TextInfra.Limit(aaa, this.TextNewLine, this.TextLess);
        
        ReadArg arg;
        arg = new ReadArg();
        arg.Init();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        long aa;
        aa = arg.StringIndex;
        aa = aa * sizeof(ulong) * 3;
        arg.StringTextData = this.CreateData(aa);
        aa = arg.ArrayIndex;
        aa = aa * sizeof(ulong);
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
        this.LineList = null;
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
        long ka;
        ka = sizeof(ulong);
        Array array;
        array = arg.StringArray;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long nn;
            nn = i;
            nn = nn * 3;
            long row;
            long index;
            long countA;
            long na;
            na = nn * ka;
            ulong u;
            u = infraInfra.DataIntGet(textData, na);
            row = (long)u;
            
            na = (nn + 1) * ka;
            u = infraInfra.DataIntGet(textData, na);
            index = (long)u;
            
            na = (nn + 2) * ka;
            u = infraInfra.DataIntGet(textData, na);
            countA = (long)u;

            Text line;
            line = this.LineText(row);

            text.Data = line.Data;
            range.Index = index;
            range.Count = countA;

            String a;
            a = textInfra.StringCreate(text);
            text.Data = null;

            array.SetAt(i, a);
            
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
        
        long ka;
        ka = sizeof(ulong);
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long nn;
            nn = i;
            nn = nn * ka;
            ulong u;
            u = infraInfra.DataIntGet(data, nn);
            long k;
            k = (long)u;

            Array a;
            a = listInfra.ArrayCreate(k);
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Port a;
            a = new Port();
            a.Init();
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = new ModuleRef();
            a.Init();
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Import a;
            a = new Import();
            a.Init();
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ImportClass a;
            a = new ImportClass();
            a.Init();
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Export a;
            a = new Export();
            a.Init();
            array.SetAt(i, a);
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

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Storage a;
            a = new Storage();
            a.Init();
            array.SetAt(i, a);
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
        this.Port = this.ExecutePort(0);
        return true;
    }

    protected virtual Port ExecutePort(long row)
    {
        bool b;
        b = this.CheckHead(row, this.HeadModule);
        if (!b)
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }
        
        ModuleRef module;
        module = this.ExecuteModuleRef(row);
        if (module == null)
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }
        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.CheckHead(row, "Import");
        if (!b)
        {
            return null;
        }

        row = row + 1;
        int ka;
        ka = this.SectionLineCount(row);

        Array import;
        import = this.ExecuteImportArray(row, ka);
        if (import == null)
        {
            return null;
        }

        row = row + ka;
        if (!this.CheckRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.CheckHead(row, "Export");
        if (!b)
        {
            return null;
        }

        row = row + 1;
        ka = this.SectionLineCount(row);

        Array export;
        export = this.ExecuteExportArray(row, ka);
        if (export == null)
        {
            return null;
        }

        row = row + ka;
        if (!this.CheckRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.CheckHead(row, "Storage");
        if (!b)
        {
            return null;
        }

        row = row + 1;
        ka = this.SectionLineCount(row);

        Array storage;
        storage = this.ExecuteStorageArray(row, ka);
        if (storage == null)
        {
            return null;
        }

        row = row + ka;
        if (!this.CheckRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.CheckHead(row, "Entry");
        if (!b)
        {
            return null;
        }

        row = row + 1;

        string entry;
        entry = null;
        if (this.CheckRow(row))
        {
            Text aa;
            aa = this.LineText(row);
            
            entry = this.ExecuteString(row, aa.Range);

            row = row + 1;
        }

        if (!(row == this.LineList.Count))
        {
            return null;
        }

        Port a;
        a = this.Operate.ExecutePort();
        a.Module = module;
        a.Import = import;
        a.Export = export;
        a.Storage = storage;
        a.Entry = entry;
        return a;
    }

    protected virtual Array ExecuteImportArray(int row, int lineCount)
    {
        int count;
        count = this.ImportCount(row, lineCount);
        Array array;
        array = this.Operate.ExecuteArray(count);
        int k;
        k = row;
        int i;
        i = 0;
        while (i < count)
        {
            int kk;
            kk = k + 1;

            int ka;
            ka = this.SubSectionLineCount(kk);

            Import a;
            a = this.ExecuteImport(k, ka);
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            k = k + 1 + ka;

            i = i + 1;
        }
        return array;
    }

    protected virtual int ImportCount(int row, int lineCount)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        this.TextGet(this.Space);

        Text textA;
        textA = this.Text;
        Range rangeA;
        rangeA = textA.Range;
        Less less;
        less = this.TextLess;

        int ka;
        ka = rangeA.Count;

        int k;
        k = 0;

        int count;
        count = lineCount;
        int i;
        i = 0;
        while (i < count)
        {
            Text text;
            text = this.LineText(row + i);
            Range range;
            range = text.Range;
            int kk;
            kk = range.Count;

            bool b;
            b = false;
            if (kk < ka)
            {
                b = true;
            }
            if (!b)
            {
                range.Count = ka;
                if (!textInfra.Same(text, textA, less))
                {
                    b = true;
                }
                range.Count = kk;
            }

            if (b)
            {
                k = k + 1;
            }

            i = i + 1;
        }

        return k;
    }

    protected virtual Import ExecuteImport(int row, int subsectionLineCount)
    {
        ModuleRef module;
        module = this.ExecuteModuleRef(row);
        if (module == null)
        {
            return null;
        }

        row = row + 1;

        int count;
        count = subsectionLineCount;

        Array array;
        array = this.Operate.ExecuteArray(count);
        int i;
        i = 0;
        while (i < count)
        {
            ImportClass aa;
            aa = this.ExecuteImportClass(row + i);
            if (aa == null)
            {
                return null;
            }
            array.SetAt(i, aa);

            i = i + 1;
        }

        Import a;
        a = this.Operate.ExecuteImport();
        a.Module = module;
        a.Class = array;
        return a;
    }

    protected virtual ImportClass ExecuteImportClass(int row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text text;
        text = this.LineText(row);

        this.TextGet(this.Space);

        Range range;
        range = text.Range;
        int index;
        index = range.Index;
        int indexA;
        indexA = index + 4;

        range.Index = indexA;

        Text textA;
        textA = this.Text;
        Less less;
        less = this.TextLess;

        int u;
        u = textInfra.Index(text, textA, less);
        
        range.Index = index;

        if (u == -1)
        {
            return null;
        }

        Range rangeA;
        rangeA = textA.Range;

        rangeA.Index = indexA;
        rangeA.Count = u;

        string name;
        name = this.ExecuteString(row, rangeA);

        int k;
        k = u + 1;
        int ka;
        ka = indexA + k;
        rangeA.Index = ka;
        rangeA.Count = text.Range.Count - ka;

        string varClass;
        varClass = this.ExecuteString(row, rangeA);
        
        ImportClass a;
        a = this.Operate.ExecuteImportClass();
        a.Name = name;
        a.Class = varClass;
        return a;
    }

    protected virtual Array ExecuteExportArray(int row, int lineCount)
    {
        int count;
        count = lineCount;
        Array array;
        array = this.Operate.ExecuteArray(count);
        int i;
        i = 0;
        while (i < count)
        {
            Export a;
            a = this.ExecuteExport(row + i);
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Export ExecuteExport(int row)
    {
        Text text;
        text = this.LineText(row);

        string varClass;
        varClass = this.ExecuteString(row, text.Range);

        Export a;
        a = this.Operate.ExecuteExport();
        a.Class = varClass;
        return a;
    }

    protected virtual Array ExecuteStorageArray(int row, int lineCount)
    {
        int count;
        count = lineCount;
        Array array;
        array = this.Operate.ExecuteArray(count);
        int i;
        i = 0;
        while (i < count)
        {
            Storage a;
            a = this.ExecuteStorage(row + i);
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);
            i = i + 1;
        }

        return array;
    }

    protected virtual Storage ExecuteStorage(int row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text text;
        text = this.LineText(row);

        Text textA;
        textA = this.Text;
        Less less;
        less = this.TextLess;

        this.TextGet(this.Colon);

        int u;
        u = textInfra.Index(text, textA, less);
        if (u == -1)
        {
            return null;
        }

        Range range;
        range = textA.Range;
        
        range.Index = 0;
        range.Count = u;
        
        string path;
        path = this.ExecuteString(row, range);

        int k;
        k = u + 1;
        range.Index = k;
        range.Count = text.Range.Count - k;

        string sourcePath;
        sourcePath = this.ExecuteString(row, range);

        Storage a;
        a = this.Operate.ExecuteStorage();
        a.Path = path;
        a.SourcePath = sourcePath;
        return a;
    }

    protected virtual int SectionLineCount(int row)
    {
        int lineCount;
        lineCount = this.LineList.Count;

        int o;
        o = -1;
        bool b;
        b = false;
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
        
        if (!b)
        {
            return i;
        }
        return o;
    }

    protected virtual int SubSectionLineCount(int row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        int lineCount;
        lineCount = this.LineList.Count;

        this.TextGet(this.Space);

        Text textA;
        textA = this.Text;
        Less less;
        less = this.TextLess;

        int ka;
        ka = textA.Range.Count;

        int o;
        o = -1;
        bool b;
        b = false;
        int count;
        count = lineCount - row;
        int i;
        i = 0;
        while (!b & i < count)
        {
            Text text;
            text = this.LineText(row + i);
            Range range;
            range = text.Range;
            int kk;
            kk = range.Count;

            if (kk < ka)
            {
                b = true;
                o = i;
            }
            
            if (!b)
            {
                range.Count = ka;
                if (!textInfra.Same(text, textA, less))
                {
                    b = true;
                    o = i;
                }
                range.Count = kk;
            }

            i = i + 1;
        }

        if (!b)
        {
            return i;
        }
        return o;
    }

    protected virtual bool CheckHead(long row, String head)
    {
        Text line;
        line = this.LineText(row);

        Range range;
        range = line.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        bool a;
        a = this.CheckHeadAll(line, head);

        range.Index = index;
        range.Count = count;

        return a;
    }

    protected virtual bool CheckHeadAll(Text line, String head)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        
        Range range;
        range = line.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        long kk;
        kk = this.StringComp.Count(head);

        if (!((kk + 2) == count))
        {
            return false;
        }

        Text textA;
        textA = this.Text;
        Less less;
        less = this.TextLess;

        this.TextGet(this.SquareLeft);

        range.Count = 1;

        if (!textInfra.Same(line, textA, less))
        {
            return false;
        }

        this.TextGet(this.SquareRight);

        range.Index = index + count - 1;

        if (!textInfra.Same(line, textA, less))
        {
            return false;
        }
        
        this.TextGet(head);

        range.Index = index + 1;
        range.Count = count - 2;

        if (!textInfra.Same(line, textA, less))
        {
            return false;
        }

        return true;
    }

    protected virtual ModuleRef ExecuteModuleRef(long row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text text;
        text = this.LineText(row);
        Range range;
        range = text.Range;
        Text textA;
        textA = this.Text;
        Range rangeA;
        rangeA = textA.Range;

        long nameCount;
        long version;
        nameCount = 0;
        version = 0;
        
        this.TextGet(this.Colon);
        
        long n;
        n = textInfra.Index(text, textA, this.TextLess);
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

            long aa;
            long ab;
            aa = range.Index;
            ab = range.Count;
            long oo;
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
        String name;
        name = this.ExecuteString(row, rangeA);
        
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

        long index;
        long count;
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
        Less less;
        less = this.TextLess;

        Range range;
        range = text.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        this.TextGet(this.Dot);

        long u;
        u = textInfra.Index(text, textA, less);
        if (u == -1)
        {
            return -1;
        }

        long kka;
        kka = u;

        long ka;
        ka = kka + 1;
        range.Index = index + ka;
        range.Count = count - ka;
        u = textInfra.Index(text, textA, less);
        if (!(u == 2))
        {
            return -1;
        }

        long kkb;
        kkb = u;
        long kb;
        kb = ka + kkb + 1;

        long ku;
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

    protected virtual Text LineText(long row)
    {
        return (Text)this.LineList.GetAt(row);
    }

    protected virtual bool CheckRow(long row)
    {
        return this.InfraInfra.ValidIndex(this.LineList.Count, row);
    }

    protected virtual long NextRow(long row)
    {
        long a;
        a = row;
        a = a + 1;
 
        if (!this.CheckRow(a))
        {
            return -1;
        }
        return a;
    }

    protected virtual String ExecuteString(long row, Range range)
    {
        String a;
        a = this.Operate.ExecuteString(row, range);
        return a;
    }

    protected virtual bool TextGet(String o)
    {
        this.StringData.ValueString = o;
        this.Text.Data = this.StringData;
        this.Text.Range.Index = 0;
        this.Text.Range.Count = this.StringComp.Count(o);
        return true;
    }

    private String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}