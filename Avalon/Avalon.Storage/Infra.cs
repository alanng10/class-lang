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
        this.TextEncodeKindList = TextEncodeKindList.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
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
        if (storage.Status == 0)
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

    public virtual bool DataWrite(string filePath, Data data, Range range)
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
        if (storage.Status == 0)
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

        TextSpan span;        
        span = this.TextInfra.SpanCreate(ka);
        Range range;
        range = new Range();
        range.Init();
        range.Count = data.Count;
        int kb;
        kb = encode.Text(span, data, range);

        encode.Final();

        int count;
        count = kb;
        string a;
        a = new string(span.Data, span.Range.Index, count);
        return a;
    }

    public virtual bool TextWrite(string filePath, string text)
    {
        TextEncode encode;
        encode = new TextEncode();
        encode.Kind = this.TextEncodeKindList.Utf8;
        encode.Init();

        TextSpan span;
        span = this.TextInfra.SpanCreateString(text);
        int kk;
        kk = span.Range.Count;
        long ka;
        ka = encode.DataCountMax(kk);

        Data data;
        data = new Data();
        data.Init();
        data.Value = new byte[ka];

        long kb;
        kb = encode.Data(data, 0, span);

        encode.Final();

        long count;
        count = kb;
        Range range;
        range = new Range();
        range.Init();
        range.Count = count;
        bool o;
        o = this.DataWrite(filePath, data, range);
        return o;
    }

    public virtual bool CountSet(string filePath, long value)
    {
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
        if (storage.Status == 0)
        {
            storage.CountSet(value);
            if (storage.Status == 0)
            {
                o = true;
            }
        }
        storage.Close();
        storage.Final();
        return o;
    }
}