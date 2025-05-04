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
        this.InternIntern = Intern.This;
        this.CodeKindList = CodeKindList.This;
        return true;
    }

    protected virtual CodeKindList CodeKindList { get; set; }
    private Intern InternIntern { get; set; }

    public virtual String Execute(string value)
    {
        CodeKindList codeKindList;
        codeKindList = this.CodeKindList;

        CodeKind outKind;
        outKind = codeKindList.Utf32;

        byte[] k;
        k = outKind.Intern.GetBytes(value);

        long count;
        count = k.LongLength / sizeof(uint);

        String a;
        a = this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, k);
        this.InternIntern.StringCountSet(a, count);
        return a;
    }

    public virtual string ExecuteIntern(String value)
    {
        CodeKindList codeKindList;
        codeKindList = this.CodeKindList;

        CodeKind innKind;
        innKind = codeKindList.Utf32;

        byte[] ka;
        ka = this.InternIntern.StringValueGet(value) as byte[];

        string k;
        k = innKind.Intern.GetString(ka);

        string a;
        a = k;
        return a;
    }
}