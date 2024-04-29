namespace Avalon.Text;

public class Encode : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;

        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);
        this.InternString = Extern.String_New();
        Extern.String_Init(this.InternString);

        ulong ua;
        ua = this.Kind.Intern;
        bool ba;
        ba = this.WriteBom;
        ulong ub;
        ub = (ulong)(ba ? 1 : 0);

        this.Intern = Extern.TextEncode_New();
        Extern.TextEncode_KindSet(this.Intern, ua);
        Extern.TextEncode_WriteBomSet(this.Intern, ub);
        Extern.TextEncode_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.TextEncode_Final(this.Intern);
        Extern.TextEncode_Delete(this.Intern);

        Extern.String_Final(this.InternString);
        Extern.String_Delete(this.InternString);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);
        return true;
    }

    public virtual EncodeKind Kind { get { return __D_Kind; } set { __D_Kind = value; } }
    protected EncodeKind __D_Kind;
    public virtual bool WriteBom { get { return __D_WriteBom; } set { __D_WriteBom = value; } }
    protected bool __D_WriteBom;

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected InfraInfra __D_InfraInfra;
    protected virtual Infra TextInfra { get { return __D_TextInfra; } set { __D_TextInfra = value; } }
    protected Infra __D_TextInfra;
    private ulong Intern { get; set; }
    private ulong InternString { get; set; }
    private ulong InternData { get; set; }

    public virtual int TextCountMax(long dataCount)
    {
        ulong ua;
        ua = (ulong)dataCount;
        ulong u;
        u = Extern.TextEncode_StringCountMax(this.Intern, ua);
        int a;
        a = (int)u;
        return a;
    }

    public virtual int Text(Text text, Data data, DataRange range)
    {
        if (!this.InfraInfra.CheckLongRange(data.Count, range.Index, range.Count))
        {
            return -1;
        }

        long dataCount;
        dataCount = range.Count;
        ulong ua;
        ua = (ulong)dataCount;
        ulong dataU;
        dataU = this.InternData;
        Extern.Data_CountSet(dataU, ua);

        int a;
        a = this.InternIntern.TextEncodeString(this.Intern, text.Data.Value, text.Range.Index, dataU, data.Value, range.Index);
        return a;
    }

    public virtual long DataCountMax(int textCount)
    {
        ulong ua;
        ua = (ulong)textCount;
        ulong u;
        u = Extern.TextEncode_DataCountMax(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Data(Data data, long index, Text text)
    {
        if (!this.TextInfra.CheckRange(text))
        {
            return -1;
        }

        int textCount;
        textCount = text.Range.Count;
        ulong ua;
        ua = (ulong)textCount;
        ulong textU;
        textU = this.InternString;
        Extern.String_CountSet(textU, ua);

        long a;
        a = this.InternIntern.TextEncodeData(this.Intern, data.Value, index, textU, text.Data.Value, text.Range.Index);
        return a;
    }
}