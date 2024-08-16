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
        this.Code = Code.This;
        this.CodeKindList = CodeKindList.This;
        return true;
    }

    protected virtual Code Code { get; set; }
    protected virtual CodeKindList CodeKindList { get; set; }

    public virtual String Execute(string o)
    {
        Code code;
        code = this.Code;
        CodeKindList codeKindList;
        codeKindList = this.CodeKindList;

        CodeKind innKind;
        CodeKind outKind;
        innKind = codeKindList.Utf16;
        outKind = codeKindList.Utf32;

        Range range;
        range = new Range();
        range.Init();
        range.Count = o.Length * sizeof(char);

        long resultCount;
        resultCount = code.ExecuteCountString(innKind, outKind, o, range);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        code.ExecuteResultString(result, 0, innKind, outKind, o, range);

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