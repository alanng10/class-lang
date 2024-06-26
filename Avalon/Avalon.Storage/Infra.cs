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
        this.StorageStatusList = StatusList.This;
        this.TextEncodeKindList = TextEncodeKindList.This;
        this.TextSlash = this.TextInfra.TextCreateStringData("/", null);
        this.TextDot = this.TextInfra.TextCreateStringData(".", null);
        this.TextColon = this.TextInfra.TextCreateStringData(":", null);
        return true;
    }

    public virtual TextText TextSlash { get; set; }
    public virtual TextText TextDot { get; set; }
    public virtual TextText TextColon { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }
    protected virtual TextEncodeKindList TextEncodeKindList { get; set; }

    public virtual Data DataRead(string filePath)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();

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
            DataRange range;
            range = new DataRange();
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
        DataRange range;
        range = new DataRange();
        range.Init();
        range.Count = data.Count;
        return this.DataWriteRange(filePath, data, range);
    }

    public virtual bool DataWriteRange(string filePath, Data data, DataRange range)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();

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
        Data data;
        data = this.DataRead(filePath);
        if (data == null)
        {
            return null;
        }
        TextEncode encode;
        encode = new TextEncode();
        encode.Kind = this.TextEncodeKindList.Utf8;
        encode.Init();

        int ka;
        ka = encode.TextCountMax(data.Count);

        TextText text;
        text = this.TextInfra.TextCreate(ka);
        DataRange range;
        range = new DataRange();
        range.Init();
        range.Count = data.Count;
        int kb;
        kb = encode.Text(text, data, range);

        encode.Final();

        int count;
        count = kb;

        text.Range.Count = count;

        string a;
        a = this.TextInfra.StringCreate(text);
        return a;
    }

    public virtual bool TextWrite(string filePath, string text)
    {
        TextEncode encode;
        encode = new TextEncode();
        encode.Kind = this.TextEncodeKindList.Utf8;
        encode.Init();

        TextText o;
        o = this.TextInfra.TextCreateString(text, null);
        int kk;
        kk = o.Range.Count;
        long ka;
        ka = encode.DataCountMax(kk);

        Data data;
        data = new Data();
        data.Count = ka;
        data.Init();

        long kb;
        kb = encode.Data(data, 0, o);

        encode.Final();

        long count;
        count = kb;
        DataRange range;
        range = new DataRange();
        range.Init();
        range.Count = count;
        bool a;
        a = this.DataWriteRange(filePath, data, range);
        return a;
    }

    public virtual bool CountSet(string filePath, long value)
    {
        StatusList statusList;
        statusList = this.StorageStatusList;

        Storage storage;
        storage = new Storage();
        storage.Init();

        Mode mode;
        mode = new Mode();
        mode.Init();
        mode.Read = true;
        mode.Write = true;
        mode.Existing = true;

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