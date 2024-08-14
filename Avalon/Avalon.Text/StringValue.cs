namespace Avalon.Text;

public class StringValue : Any
{
    public static StringValue This { get; } = ShareCreate();

    private static StringValue ShareCreate()
    {
        StringValue share;
        share = new StringValue();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.EncodeKindList = EncodeKindList.This;
        return true;
    }

    protected virtual EncodeKindList EncodeKindList { get; set; }

    public virtual String Execute(string o)
    {
        EncodeKindList kindList;
        kindList = this.EncodeKindList;

        EncodeKind innKind;
        EncodeKind outKind;
        innKind = kindList.Utf16;
        outKind = kindList.Utf32;

        Encode encode;
        encode = new Encode();
        encode.Init();

        Range range;
        range = new Range();
        range.Init();
        range.Count = o.Length * sizeof(char);

        long resultCount;
        resultCount = encode.ExecuteCountString(innKind, outKind, o, range);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        encode.ExecuteResultString(result, 0, innKind, outKind, o, range);

        long count;
        count = resultCount / sizeof(uint);

        String a;
        a = new String();
        a.Data = result;
        a.Count = count;
        a.Init();
        return a;
    }
}