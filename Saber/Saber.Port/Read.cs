namespace Saber.Port;

public class Read : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = this.CreateCountOperate();
        this.StringOperate = this.CreateStringOperate();
        this.SetOperate = this.CreateSetOperate();

        this.SColon = this.S(":");
        this.SDot = this.S(".");
        this.SBraceSquareLite = this.S("[");
        this.SBraceSquareRite = this.S("]");
        return true;
    }

    protected virtual ReadCountOperate CreateCountOperate()
    {
        ReadCountOperate a;
        a = new ReadCountOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    protected virtual ReadStringOperate CreateStringOperate()
    {
        ReadStringOperate a;
        a = new ReadStringOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    protected virtual ReadSetOperate CreateSetOperate()
    {
        ReadSetOperate a;
        a = new ReadSetOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    public virtual Array Source { get; set; }
    public virtual Port Result { get; set; }
    public virtual ReadArg Arg { get; set; }
    public virtual ReadOperate Operate { get; set; }
    public virtual ReadCountOperate CountOperate { get; set; }
    public virtual ReadStringOperate StringOperate { get; set; }
    public virtual ReadSetOperate SetOperate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual String SColon { get; set; }
    protected virtual String SDot { get; set; }
    protected virtual String SBraceSquareLite { get; set; }
    protected virtual String SBraceSquareRite { get; set; }

    public virtual bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        this.Arg = new ReadArg();
        this.Arg.Init();

        ReadArg arg;
        arg = this.Arg;

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long ka;
        ka = arg.StringIndex;
        ka = ka * sizeof(ulong) * 3;
        arg.StringRangeData = new Data();
        arg.StringRangeData.Count = ka;
        arg.StringRangeData.Init();

        ka = arg.ArrayIndex;
        ka = ka * sizeof(ulong);
        arg.ArrayCountData = new Data();
        arg.ArrayCountData.Count = ka;
        arg.ArrayCountData.Init();

        this.Operate = this.StringOperate;

        this.ResetStage();
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

        this.ResetStage();
        this.ExecuteStage();

        this.Arg = null;
        this.Operate = null;
        return true;
    }

    public virtual bool ResetStage()
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
        Array array;
        array = this.Arg.StringArray;

        Data data;
        data = this.Arg.StringRangeData;

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
            nn = nn * 3;
            long row;
            long index;
            long countA;
            long na;
            na = nn * ka;
            row = this.InfraInfra.DataIntGet(data, na);

            na = (nn + 1) * ka;
            index = this.InfraInfra.DataIntGet(data, na);

            na = (nn + 2) * ka;
            countA = this.InfraInfra.DataIntGet(data, na);

            Text line;
            line = this.LineText(row);

            this.TextA.Data = line.Data;
            this.TextA.Range.Index = index;
            this.TextA.Range.Count = countA;

            String a;
            a = this.StringCreate(this.TextA);

            this.TextA.Range.Count = 0;
            this.TextA.Range.Index = 0;
            this.TextA.Data = null;

            array.SetAt(i, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateArray()
    {
        Array array;
        array = this.Arg.ArrayArray;

        Data data;
        data = this.Arg.ArrayCountData;

        long ka;
        ka = sizeof(ulong);
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long nn;
            nn = i * ka;

            long k;
            k = this.InfraInfra.DataIntGet(data, nn);

            Array a;
            a = this.ListInfra.ArrayCreate(k);

            array.SetAt(i, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreatePort()
    {
        Array array;
        array = this.Arg.PortArray;

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
        Array array;
        array = this.Arg.ModuleRefArray;

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
        Array array;
        array = this.Arg.ImportArray;

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
        Array array;
        array = this.Arg.ImportClassArray;

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
        Array array;
        array = this.Arg.ExportArray;

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
        Array array;
        array = this.Arg.StorageArray;

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

    public virtual bool ExecuteStage()
    {
        this.Result = this.ExecutePort();

        this.ClearData();
        return true;
    }

    protected virtual Port ExecutePort()
    {
        long row;
        row = 0;

        bool b;
        b = this.ValidHead(row, this.ClassInfra.TextModule);
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

        b = this.ValidHead(row, this.ClassInfra.TextImport);
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
        if (!this.ValidRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.ValidHead(row, this.ClassInfra.TextExport);
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
        if (!this.ValidRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.ValidHead(row, this.ClassInfra.TextStorage);
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
        if (!this.ValidRow(row))
        {
            return null;
        }

        row = this.NextRow(row);
        if (row == -1)
        {
            return null;
        }

        b = this.ValidHead(row, this.ClassInfra.TextEntry);
        if (!b)
        {
            return null;
        }

        row = row + 1;

        String entry;
        entry = null;
        if (this.ValidRow(row))
        {
            entry = this.ExecuteEntry(row);

            row = row + 1;
        }

        if (!(row == this.Source.Count))
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

            k = kk + ka;

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

    protected virtual Import ExecuteImport(long row, long lineCount)
    {
        ModuleRef module;
        module = this.ExecuteModuleRef(row);
        if (module == null)
        {
            return null;
        }

        row = row + 1;

        long count;
        count = lineCount;

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
        long count;
        index = range.Index;
        count = range.Count;

        long indexA;
        long countA;
        indexA = index + kaa;
        countA = count - kaa;

        range.Index = indexA;
        range.Count = countA;

        long kk;
        kk = this.TextIndex(text, this.TA(this.SSpace));

        range.Index = index;
        range.Count = count;

        if (kk == -1)
        {
            return null;
        }

        Range rangeA;
        rangeA = this.TRangeA;

        rangeA.Index = indexA;
        rangeA.Count = kk;

        String name;
        name = this.ExecuteString(row, rangeA);

        long k;
        k = kk + 1;

        rangeA.Index = indexA + k;
        rangeA.Count = countA - k;

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
        Text text;
        text = this.LineText(row);

        long kk;
        kk = this.TextIndex(text, this.TA(this.SColon));
        if (kk == -1)
        {
            return null;
        }

        long index;
        long count;
        index = text.Range.Index;
        count = text.Range.Count;

        Range range;
        range = this.TRangeA;

        range.Index = index;
        range.Count = kk;

        String dest;
        dest = this.ExecuteString(row, range);

        long k;
        k = kk + 1;

        range.Index = index + k;
        range.Count = count - k;

        String source;
        source = this.ExecuteString(row, range);

        Storage a;
        a = this.Operate.ExecuteStorage();
        a.Dest = dest;
        a.Source = source;
        return a;
    }

    protected virtual String ExecuteEntry(long row)
    {
        Text text;
        text = this.LineText(row);

        String a;
        a = this.ExecuteString(row, text.Range);
        return a;
    }

    protected virtual long SectionLineCount(long row)
    {
        long lineCount;
        lineCount = this.Source.Count;

        long k;
        k = -1;

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
                k = i;
            }

            i = i + 1;
        }

        if (!b)
        {
            return count;
        }

        long a;
        a = k;
        return a;
    }

    protected virtual long SubSectionLineCount(long row)
    {
        long lineCount;
        lineCount = this.Source.Count;

        long k;
        k = -1;

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
                k = i;
            }

            i = i + 1;
        }

        if (!b)
        {
            return count;
        }

        long a;
        a = k;
        return a;
    }

    protected virtual bool ValidHead(long row, String head)
    {
        Text text;
        text = this.LineText(row);

        Range range;
        range = text.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        bool a;
        a = this.ValidHeadAll(text, head);

        range.Index = index;
        range.Count = count;

        return a;
    }

    private bool ValidHeadAll(Text text, String head)
    {
        Range range;
        range = text.Range;

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

        if (!this.TextSame(text, this.TA(this.SBraceSquareLite)))
        {
            return false;
        }

        range.Index = index + count - 1;

        if (!this.TextSame(text, this.TA(this.SBraceSquareRite)))
        {
            return false;
        }

        range.Index = index + 1;
        range.Count = count - 2;

        if (!this.TextSame(text, this.TA(head)))
        {
            return false;
        }

        return true;
    }

    protected virtual ModuleRef ExecuteModuleRef(long row)
    {
        Text text;
        text = this.LineText(row);

        Range range;
        range = text.Range;

        long nameCount;
        long ver;
        nameCount = 0;
        ver = 0;

        long kk;
        kk = this.TextIndex(text, this.TA(this.SColon));

        bool b;
        b = (kk == -1);
        if (b)
        {
            nameCount = range.Count;
            ver = -1;
        }
        if (!b)
        {
            nameCount = kk;

            long ka;
            long kb;
            ka = range.Index;
            kb = range.Count;

            long kd;
            kd = kk + 1;

            range.Index = ka + kd;
            range.Count = kb - kd;

            ver = this.ExecuteModuleVer(text);

            range.Index = ka;
            range.Count = kb;

            if (ver == -1)
            {
                return null;
            }
        }

        Range rangeA;
        rangeA = this.TRangeA;
        rangeA.Index = range.Index;
        rangeA.Count = nameCount;

        String name;
        name = this.ExecuteString(row, rangeA);

        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Ver = ver;
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

    private long ExecuteModuleVerAll(Text text)
    {
        Range range;
        range = text.Range;

        long index;
        long count;
        index = range.Index;
        count = range.Count;

        String dot;
        dot = this.SDot;

        long kka;
        kka = this.TextIndex(text, this.TA(dot));
        if (kka == -1)
        {
            return -1;
        }

        long ka;
        ka = kka + 1;

        range.Index = index + ka;
        range.Count = count - ka;

        long kaa;
        kaa = 2;

        long kkb;
        kkb = this.TextIndex(text, this.TA(dot));
        if (!(kkb == kaa))
        {
            return -1;
        }

        long kb;
        kb = ka + kkb + 1;

        long kkc;
        kkc = kb + kaa;
        if (!(kkc == count))
        {
            return -1;
        }

        range.Index = index;
        range.Count = kka;

        long major;
        major = this.IntText(text, 10);
        if (major == -1)
        {
            return -1;
        }

        long kc;
        kc = 1;
        kc = kc << 44;
        if (!(major < kc))
        {
            return -1;
        }

        range.Index = index + ka;
        range.Count = kkb;

        long minor;
        minor = this.IntText(text, 10);
        if (minor == -1)
        {
            return -1;
        }

        range.Index = index + kb;
        range.Count = kaa;

        long melor;
        melor = this.IntText(text, 10);
        if (melor == -1)
        {
            return -1;
        }

        long k;
        k = 0;
        k = k | melor;
        k = k | (minor << 8);
        k = k | (major << 16);

        long a;
        a = k;
        return a;
    }

    protected virtual Text LineText(long row)
    {
        return this.Source.GetAt(row) as Text;
    }

    protected virtual bool ValidRow(long row)
    {
        return this.InfraInfra.ValidIndex(this.Source.Count, row);
    }

    protected virtual long NextRow(long row)
    {
        long k;
        k = row + 1;

        if (!this.ValidRow(k))
        {
            return -1;
        }
        return k;
    }

    protected virtual String ExecuteString(long row, Range range)
    {
        String a;
        a = this.Operate.ExecuteString(row, range);
        return a;
    }
}