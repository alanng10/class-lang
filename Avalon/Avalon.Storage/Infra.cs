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
        this.TextCode = TextCode.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.TextStringValue = TextStringValue.This;
        this.StorageStatusList = StatusList.This;

        this.SSlash = this.S("/");
        this.SDot = this.S(".");
        this.SColon = this.S(":");
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
    protected virtual TextCode TextCode { get; set; }
    protected virtual TextCodeKindList TextCodeKindList { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }

    public virtual Data DataRead(String filePath)
    {
        return this.DataReadAny(filePath, false);
    }

    public virtual Data DataReadAny(String filePath, bool anyNode)
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

    public virtual bool DataWrite(String filePath, Data data)
    {
        return this.DataWriteAny(filePath, data, false);
    }

    public virtual bool DataWriteAny(String filePath, Data data, bool anyNode)
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

    public virtual bool CountSet(String filePath, long value)
    {
        return this.CountSetAny(filePath, value, false);
    }

    public virtual bool CountSetAny(String filePath, long value, bool anyNode)
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

    public virtual long EntryPathNameCombine(TextText entryPath, Less less)
    {
        long a;
        a = this.TextInfra.LastIndex(entryPath, this.TextSlash, less);
        return a;
    }

    public virtual long EntryNameExtensionDot(TextText entryName, Less less)
    {
        long a;
        a = this.TextInfra.LastIndex(entryName, this.TextDot, less);
        return a;
    }

    public virtual bool IsRelativePath(TextText entryPath, Less less)
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

    private String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}