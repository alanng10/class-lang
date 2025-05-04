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
        this.StringComp = StringComp.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.StorageStatusList = StatusList.This;

        this.SSlash = this.TextInfra.S("/");
        this.SDot = this.TextInfra.S(".");
        this.SColon = this.TextInfra.S(":");
        this.TextSlash = this.TextInfra.TextCreateStringData(this.SSlash, null);
        this.TextDot = this.TextInfra.TextCreateStringData(this.SDot, null);
        this.TextColon = this.TextInfra.TextCreateStringData(this.SColon, null);
        return true;
    }

    public virtual TextText TextSlash { get; set; }
    public virtual TextText TextDot { get; set; }
    public virtual TextText TextColon { get; set; }
    public virtual String SSlash { get; set; }
    public virtual String SDot { get; set; }
    public virtual String SColon { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual TextCodeKindList TextCodeKindList { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }

    public virtual bool ValidMode(Mode mode)
    {
        if (!(mode.Read | mode.Write))
        {
            return false;
        }
        if (mode.New & mode.Exist)
        {
            return false;
        }
        return true;
    }

    public virtual Data DataRead(String filePath)
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

        Data a;
        a = null;
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
            if (storage.Status == this.StorageStatusList.NoError)
            {
                a = data;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    public virtual bool DataWrite(String filePath, Data data)
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

        bool a;
        a = false;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            StreamStream stream;
            stream = storage.Stream;

            Range range;
            range = new Range();
            range.Init();
            range.Index = 0;
            range.Count = data.Count;

            stream.Write(data, range);
            if (storage.Status == this.StorageStatusList.NoError)
            {
                a = true;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    public virtual String TextRead(String filePath)
    {
        TextCodeKindList kindList;
        kindList = this.TextCodeKindList;

        Data data;
        data = this.DataRead(filePath);
        if (data == null)
        {
            return null;
        }

        TextCodeKind innKind;
        TextCodeKind outKind;
        innKind = kindList.Utf8;
        outKind = kindList.Utf32;

        Range dataRange;
        dataRange = new Range();
        dataRange.Init();
        dataRange.Count = data.Count;

        Data result;
        result = this.TextInfra.Code(innKind, outKind, data, dataRange);

        String k;
        k = this.StringComp.CreateData(result, null);

        String a;
        a = k;
        return a;
    }

    public virtual bool TextWrite(String filePath, String text)
    {
        TextCodeKindList kindList;
        kindList = this.TextCodeKindList;

        TextCodeKind innKind;
        TextCodeKind outKind;
        innKind = kindList.Utf32;
        outKind = kindList.Utf8;

        Data data;
        data = this.TextInfra.StringDataCreateString(text);

        Range dataRange;
        dataRange = new Range();
        dataRange.Init();
        dataRange.Count = data.Count;

        Data result;
        result = this.TextInfra.Code(innKind, outKind, data, dataRange);

        bool a;
        a = this.DataWrite(filePath, result);
        return a;
    }

    public virtual bool CountSet(String filePath, long value)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();

        Mode mode;
        mode = new Mode();
        mode.Init();
        mode.Read = true;
        mode.Write = true;
        mode.Exist = true;

        storage.Path = filePath;
        storage.Mode = mode;
        storage.Open();

        bool a;
        a = false;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            storage.CountSet(value);
            if (storage.Status == this.StorageStatusList.NoError)
            {
                a = true;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    public virtual long EntryPathNameCombine(TextText entryPath, Less less)
    {
        long a;
        a = this.TextInfra.LastIndex(entryPath, this.TextSlash, less);
        return a;
    }

    public virtual long EntryNameExtendDot(TextText entryName, Less less)
    {
        long a;
        a = this.TextInfra.LastIndex(entryName, this.TextDot, less);
        return a;
    }

    public virtual bool PathRelate(TextText entryPath, Less less)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        long k;
        k = textInfra.Index(entryPath, this.TextSlash, less);
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

        long indexA;
        long countA;
        indexA = range.Index;
        countA = range.Count;

        TextText colon;
        colon = this.TextColon;

        long colonCount;
        colonCount = colon.Range.Count;

        range.Index = indexA + k - colonCount;
        range.Count = colonCount;

        bool b;
        b = textInfra.Same(entryPath, colon, less);
        
        range.Index = indexA;
        range.Count = countA;

        bool a;
        a = !b;
        return a;
    }
}