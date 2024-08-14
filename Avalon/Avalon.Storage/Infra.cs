namespace Avalon.Storage;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        StringComp stringComp;
        stringComp = StringComp.This;
        this.StringComp = stringComp;
        this.StorageStatusList = StatusList.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.TextSlash = this.TextInfra.TextCreateStringData(stringComp.CreateChar('/', 1), null);
        this.TextDot = this.TextInfra.TextCreateStringData(stringComp.CreateChar('.', 1), null);
        this.TextColon = this.TextInfra.TextCreateStringData(stringComp.CreateChar(':', 1), null);
        return true;
    }

    public virtual TextText TextSlash { get; set; }
    public virtual TextText TextDot { get; set; }
    public virtual TextText TextColon { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }
    protected virtual TextCodeKindList TextCodeKindList { get; set; }

    public virtual Data DataRead(string filePath)
    {
        return this.DataReadAny(filePath, false);
    }

    public virtual Data DataReadAny(string filePath, bool anyNode)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();
        storage.AnyNode = anyNode;

        Mode mode;
        mode = new Mode();
        mode.Init();
        mode.Read = true;

        storage.Path = filePath;
        storage.Mode = mode;
        storage.Open();

        Data o;
        o = null;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            StreamStream stream;
            stream = storage.Stream;

            long count;
            count = stream.Count;
            Data data;
            data = new Data();
            data.Count = count;
            data.Init();
            Range range;
            range = new Range();
            range.Init();
            range.Index = 0;
            range.Count = count;

            stream.Read(data, range);
            if (stream.Status == 0)
            {
                o = data;
            }
        }
        storage.Close();
        storage.Final();
        return o;
    }

    public virtual bool DataWrite(string filePath, Data data)
    {
        return this.DataWriteAny(filePath, data, false);
    }

    public virtual bool DataWriteAny(string filePath, Data data, bool anyNode)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();
        storage.AnyNode = anyNode;

        Mode mode;
        mode = new Mode();
        mode.Init();
        mode.Write = true;

        storage.Path = filePath;
        storage.Mode = mode;
        storage.Open();

        bool o;
        o = false;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            StreamStream stream;
            stream = storage.Stream;

            long count;
            count = data.Count;

            Range range;
            range = new Range();
            range.Init();
            range.Index = 0;
            range.Count = count;

            stream.Write(data, range);
            if (stream.Status == 0)
            {
                o = true;
            }
        }
        storage.Close();
        storage.Final();
        return o;
    }

    public virtual string TextRead(string filePath)
    {
        return this.TextReadAny(filePath, false);
    }

    public virtual string TextReadAny(string filePath, bool anyNode)
    {
        TextEncodeKindList kindList;
        kindList = this.TextEncodeKindList;

        Data data;
        data = this.DataReadAny(filePath, anyNode);
        if (data == null)
        {
            return null;
        }

        TextEncode encode;
        encode = new TextEncode();
        encode.Init();

        RangeInt dataRange;
        dataRange = new RangeInt();
        dataRange.Init();
        dataRange.Count = data.Count;

        long resultCount;
        resultCount = encode.ExecuteCount(kindList.Utf8, kindList.Utf16, data, dataRange);

        long charCount;
        charCount = resultCount / sizeof(char);

        long kk;
        kk = int.MaxValue;

        if (kk < charCount)
        {
            return null;
        }

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        encode.ExecuteResult(result, 0, kindList.Utf8, kindList.Utf16, data, dataRange);

        StringCreate stringCreate;
        stringCreate = new StringCreate();
        stringCreate.Init();

        string k;
        k = stringCreate.Data(result, null);

        string a;
        a = k;
        return a;
    }

    public virtual bool TextWrite(string filePath, string text)
    {
        return this.TextWriteAny(filePath, text, false);
    }

    public virtual bool TextWriteAny(string filePath, string text, bool anyNode)
    {
        TextEncodeKindList kindList;
        kindList = this.TextEncodeKindList;

        TextEncode encode;
        encode = new TextEncode();
        encode.Init();

        Data data;
        data = this.TextInfra.StringDataCreateString(text);

        RangeInt dataRange;
        dataRange = new RangeInt();
        dataRange.Init();
        dataRange.Count = data.Count;

        long resultCount;
        resultCount = encode.ExecuteCount(kindList.Utf16, kindList.Utf8, data, dataRange);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        encode.ExecuteResult(result, 0, kindList.Utf16, kindList.Utf8, data, dataRange);

        bool a;
        a = this.DataWriteAny(filePath, result, anyNode);
        return a;
    }

    public virtual bool CountSet(string filePath, long value)
    {
        return this.CountSetAny(filePath, value, false);
    }

    public virtual bool CountSetAny(string filePath, long value, bool anyNode)
    {
        StatusList statusList;
        statusList = this.StorageStatusList;

        Storage storage;
        storage = new Storage();
        storage.Init();
        storage.AnyNode = anyNode;

        Mode mode;
        mode = new Mode();
        mode.Init();
        mode.Read = true;
        mode.Write = true;
        mode.Exist = true;

        storage.Path = filePath;
        storage.Mode = mode;
        storage.Open();

        bool o;
        o = false;
        if (storage.Status == statusList.NoError)
        {
            storage.CountSet(value);
            if (storage.Status == statusList.NoError)
            {
                o = true;
            }
        }
        storage.Close();
        storage.Final();
        return o;
    }

    public virtual int EntryPathNameCombine(TextText entryPath, Compare compare)
    {
        int a;
        a = this.TextInfra.LastIndex(entryPath, this.TextSlash, compare);
        return a;
    }

    public virtual int EntryNameExtensionDot(TextText entryName, Compare compare)
    {
        int a;
        a = this.TextInfra.LastIndex(entryName, this.TextDot, compare);
        return a;
    }

    public virtual bool IsRelativePath(TextText entryPath, Compare compare)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        int k;
        k = textInfra.Index(entryPath, this.TextSlash, compare);
        if (k == -1)
        {
            return true;
        }

        if (k == 0)
        {
            return false;
        }

        Range range;
        range = entryPath.Range;

        int indexA;
        int countA;
        indexA = range.Index;
        countA = range.Count;

        TextText colon;
        colon = this.TextColon;

        int colonCount;
        colonCount = colon.Range.Count;

        range.Index = indexA + k - colonCount;
        range.Count = colonCount;

        bool b;
        b = textInfra.Equal(entryPath, colon, compare);
        
        range.Index = indexA;
        range.Count = countA;

        bool a;
        a = !b;
        return a;
    }
}