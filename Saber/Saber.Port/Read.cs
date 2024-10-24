namespace Saber.Port;

public class Read : ClassBase
{
    public override bool Init()
    {
        base.Init();

        this.CountOperate = new CountReadOperate();
        this.CountOperate.Read = this;
        this.CountOperate.Init();
        this.StringOperate = new StringReadOperate();
        this.StringOperate.Read = this;
        this.StringOperate.Init();
        this.SetOperate = new SetReadOperate();
        this.SetOperate.Read = this;
        this.SetOperate.Init();

        this.Range = new Range();
        this.Range.Init();

        this.Text = new Text();
        this.Text.Init();
        this.Text.Range = new Range();
        this.Text.Range.Init();

        this.IntParse = new IntParse();
        this.IntParse.Init();

        this.SColon = this.S(":");
        this.SDot = this.S(".");
        this.SBraceSquareLite = this.S("[");
        this.SBraceSquareRite = this.S("]");
        this.SSpace = this.S(" ");
        this.SIndent = this.S("    ");
        this.HeadModule = this.S("Module");
        this.HeadImport = this.S("Import");
        this.HeadExport = this.S("Export");
        this.HeadStorage = this.S("Storage");
        this.HeadEntry = this.S("Entry");
        return true;
    }

    public virtual String Source { get; set; }
    public virtual Port Port { get; set; }
    public virtual ReadArg Arg { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual Range Range { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual IntParse IntParse { get; set; }
    protected virtual String SColon { get; set; }
    protected virtual String SDot { get; set; }
    protected virtual String SBraceSquareLite { get; set; }
    protected virtual String SBraceSquareRite { get; set; }
    protected virtual String SSpace { get; set; }
    protected virtual String SIndent { get; set; }
    protected virtual String HeadModule { get; set; }
    protected virtual String HeadImport { get; set; }
    protected virtual String HeadExport { get; set; }
    protected virtual String HeadStorage { get; set; }
    protected virtual String HeadEntry { get; set; }

    public virtual bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        String source;
        source = this.Source;

        this.LineList = this.TextLimit(this.TA(source), this.TA(this.ClassInfra.NewLine));
        
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

        b = this.CheckHead(row, this.HeadImport);
        if (!b)
        {
            return null;
        }

        row = row + 1;
        long ka;
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

        b = this.CheckHead(row, this.HeadExport);
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

        b = this.CheckHead(row, this.HeadStorage);
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

        b = this.CheckHead(row, this.HeadEntry);
        if (!b)
        {
            return null;
        }

        row = row + 1;

        String entry;
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

    protected virtual Array ExecuteImportArray(long row, long lineCount)
    {
        long count;
        count = this.ImportCount(row, lineCount);
        
        Array array;
        array = this.Operate.ExecuteArray(count);
        
        long k;
        k = row;

        long i;
        i = 0;
        while (i < count)
        {
            long kk;
            kk = k + 1;

            long ka;
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

    protected virtual long ImportCount(long row, long lineCount)
    {
        long k;
        k = 0;

        long count;
        count = lineCount;

        long i;
        i = 0;
        while (i < count)
        {
            Text text;
            text = this.LineText(row + i);
            
            if (!this.TextStart(text, this.TA(this.SSpace)))
            {
                k = k + 1;
            }

            i = i + 1;
        }

        long a;
        a = k;
        return a;
    }

    protected virtual Import ExecuteImport(long row, long subsectionLineCount)
    {
        ModuleRef module;
        module = this.ExecuteModuleRef(row);
        if (module == null)
        {
            return null;
        }

        row = row + 1;

        long count;
        count = subsectionLineCount;

        Array array;
        array = this.Operate.ExecuteArray(count);
        
        long i;
        i = 0;
        while (i < count)
        {
            ImportClass ka;
            ka = this.ExecuteImportClass(row + i);
            
            if (ka == null)
            {
                return null;
            }

            array.SetAt(i, ka);

            i = i + 1;
        }

        Import a;
        a = this.Operate.ExecuteImport();
        a.Module = module;
        a.Class = array;
        return a;
    }

    protected virtual ImportClass ExecuteImportClass(long row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text text;
        text = this.LineText(row);

        if (!this.TextStart(text, this.TA(this.SIndent)))
        {
            return null;
        }

        long kaa;
        kaa = this.StringCount(this.SIndent);

        Range range;
        range = text.Range;
        long index;
        index = range.Index;

        long indexA;
        indexA = index + kaa;

        range.Index = indexA;

        long u;
        u = this.TextIndex(text, this.TA(this.SSpace));
        
        range.Index = index;

        if (u == -1)
        {
            return null;
        }

        Range rangeA;
        rangeA = this.Range;

        rangeA.Index = indexA;
        rangeA.Count = u;

        String name;
        name = this.ExecuteString(row, rangeA);

        long k;
        k = u + 1;
        long ka;
        ka = indexA + k;
        rangeA.Index = ka;
        rangeA.Count = text.Range.Count - k - kaa;

        String varClass;
        varClass = this.ExecuteString(row, rangeA);
        
        ImportClass a;
        a = this.Operate.ExecuteImportClass();
        a.Name = name;
        a.Class = varClass;
        return a;
    }

    protected virtual Array ExecuteExportArray(long row, long lineCount)
    {
        long count;
        count = lineCount;
        Array array;
        array = this.Operate.ExecuteArray(count);
        long i;
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

    protected virtual Export ExecuteExport(long row)
    {
        Text text;
        text = this.LineText(row);

        String varClass;
        varClass = this.ExecuteString(row, text.Range);

        Export a;
        a = this.Operate.ExecuteExport();
        a.Class = varClass;
        return a;
    }

    protected virtual Array ExecuteStorageArray(long row, long lineCount)
    {
        long count;
        count = lineCount;
        Array array;
        array = this.Operate.ExecuteArray(count);
        long i;
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

    protected virtual Storage ExecuteStorage(long row)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text text;
        text = this.LineText(row);

        long u;
        u = this.TextIndex(text, this.TA(this.SColon));
        if (u == -1)
        {
            return null;
        }

        long ka;
        ka = text.Range.Index;

        Range range;
        range = this.Range;
        
        range.Index = ka;
        range.Count = u;
        
        String path;
        path = this.ExecuteString(row, range);

        long k;
        k = u + 1;
        range.Index = ka + k;
        range.Count = text.Range.Count - k;

        String sourcePath;
        sourcePath = this.ExecuteString(row, range);

        Storage a;
        a = this.Operate.ExecuteStorage();
        a.Path = path;
        a.SourcePath = sourcePath;
        return a;
    }

    protected virtual long SectionLineCount(long row)
    {
        long lineCount;
        lineCount = this.LineList.Count;

        long o;
        o = -1;

        bool b;
        b = false;

        long count;
        count = lineCount - row;

        long i;
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
            return count;
        }
        return o;
    }

    protected virtual long SubSectionLineCount(long row)
    {
        long lineCount;
        lineCount = this.LineList.Count;

        long o;
        o = -1;

        bool b;
        b = false;
        
        long count;
        count = lineCount - row;

        long i;
        i = 0;
        
        while (!b & i < count)
        {
            Text text;
            text = this.LineText(row + i);

            if (!this.TextStart(text, this.TA(this.SSpace)))
            {
                b = true;
                o = i;
            }

            i = i + 1;
        }

        if (!b)
        {
            return count;
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

        range.Count = 1;

        if (!this.TextSame(line, this.TA(this.SBraceSquareLite)))
        {
            return false;
        }

        range.Index = index + count - 1;

        if (!this.TextSame(line, this.TA(this.SBraceSquareRite)))
        {
            return false;
        }

        range.Index = index + 1;
        range.Count = count - 2;

        if (!this.TextSame(line, this.TA(head)))
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

        long nameCount;
        long version;
        nameCount = 0;
        version = 0;
        
        long n;
        n = this.TextIndex(text, this.TA(this.SColon));
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

            version = this.ExecuteModuleVer(text);

            range.Index = aa;
            range.Count = ab;
            
            if (version == -1)
            {
                return null;
            }
        }

        Range kkk;
        kkk = this.Range;
        kkk.Index = range.Index;
        kkk.Count = nameCount;
        String name;
        name = this.ExecuteString(row, kkk);
        
        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Ver = version;
        return a;
    }

    protected virtual long ExecuteModuleVer(Text text)
    {
        Range range;
        range = text.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;
        
        long a;
        a = this.ExecuteModuleVerAll(text);

        range.Index = index;
        range.Count = count;
        return a;
    }

    protected virtual long ExecuteModuleVerAll(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        IntParse intParse;
        intParse = this.IntParse;

        Range range;
        range = text.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        long u;
        u = this.TextIndex(text, this.TA(this.SDot));
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
        u = this.TextIndex(text, this.TA(this.SDot));
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
        major = intParse.Execute(text, 10, false, null);
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
        minor = intParse.Execute(text, 10, false, null);
        if (minor == -1)
        {
            return -1;
        }

        range.Index = index + kb;
        range.Count = 2;

        long vise;
        vise = intParse.Execute(text, 10, false, null);
        if (vise == -1)
        {
            return -1;
        }

        long a;
        a = 0;
        a = a | vise;
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
}