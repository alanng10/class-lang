namespace Avalon.Text;

public class FormatArg : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        this.Intern = Extern.FormatArg_New();
        Extern.FormatArg_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.FormatArg_Final(this.Intern);
        Extern.FormatArg_Delete(this.Intern);
        if (!(this.InternString == 0))
        {
            this.InternInfra.StringDelete(this.InternString);
        }

        return true;
    }

    public virtual int Pos { get; set; }
    public virtual int Kind { get; set; }
    public virtual bool ValueBool { get; set; }
    public virtual long ValueInt { get; set; }
    public virtual string ValueString { get; set; }
    public virtual bool AlignLeft { get; set; }
    public virtual int FieldWidth { get; set; }
    public virtual int MaxWidth { get; set; }
    public virtual int Base { get; set; }
    public virtual int Case { get; set; }
    public virtual int Sign { get; set; }
    public virtual char FillChar { get; set; }
    public virtual bool HasCount { get; set; }
    public virtual int ValueCount { get; set; }
    public virtual int Count { get; set; }

    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternString { get; set; }

    public virtual bool Set()
    {
        if (!(this.InternString == 0))
        {
            this.InternInfra.StringDelete(this.InternString);
            this.InternString = 0;
        }

        int kind;
        kind = this.Kind;
        ulong posU;
        posU = (ulong)this.Pos;
        ulong kindU;
        kindU = (ulong)kind;
        ulong valueU;
        valueU = 0;
        if (kind == 0)
        {
            valueU = (ulong)(this.ValueBool ? 1 : 0);
        }
        if (kind == 1 | kind == 2 | kind == 4)
        {
            valueU = (ulong)this.ValueInt;
        }
        if (kind == 3)
        {
            this.InternString = this.InternInfra.StringCreate(this.ValueString);
            valueU = this.InternString;
        }
        ulong alignLeftU;
        alignLeftU = (ulong)(this.AlignLeft ? 1 : 0);
        ulong fieldWidthU;
        fieldWidthU = (ulong)this.FieldWidth;
        long maxWidthO;
        maxWidthO = this.MaxWidth;
        ulong maxWidthU;
        maxWidthU = (ulong)maxWidthO;
        int varBase;
        varBase = this.Base;
        if (varBase < 2 | 32 < varBase)
        {
            varBase = 10;
        }
        ulong baseU;
        baseU = (ulong)varBase;
        ulong caseU;
        caseU = (ulong)this.Case;
        ulong signU;
        signU = (ulong)this.Sign;
        ulong fillCharU;
        fillCharU = (ulong)this.FillChar;
        ulong hasCountU;
        hasCountU = (ulong)(this.HasCount ? 1 : 0);
        ulong valueCountU;
        valueCountU = (ulong)this.ValueCount;
        ulong countU;
        countU = (ulong)this.Count;
        Extern.FormatArg_PosSet(this.Intern, posU);
        Extern.FormatArg_KindSet(this.Intern, kindU);
        Extern.FormatArg_ValueSet(this.Intern, valueU);
        Extern.FormatArg_AlignLeftSet(this.Intern, alignLeftU);
        Extern.FormatArg_FieldWidthSet(this.Intern, fieldWidthU);
        Extern.FormatArg_MaxWidthSet(this.Intern, maxWidthU);
        Extern.FormatArg_BaseSet(this.Intern, baseU);
        Extern.FormatArg_CaseSet(this.Intern, caseU);
        Extern.FormatArg_SignSet(this.Intern, signU);
        Extern.FormatArg_FillCharSet(this.Intern, fillCharU);
        Extern.FormatArg_HasCountSet(this.Intern, hasCountU);
        Extern.FormatArg_ValueCountSet(this.Intern, valueCountU);
        Extern.FormatArg_CountSet(this.Intern, countU);
        return true;
    }

    public virtual bool GetCount()
    {
        ulong hasCountU;
        ulong valueCountU;
        ulong countU;
        hasCountU = Extern.FormatArg_HasCountGet(this.Intern);
        valueCountU = Extern.FormatArg_ValueCountGet(this.Intern);
        countU = Extern.FormatArg_CountGet(this.Intern);
        this.HasCount = !(hasCountU == 0);
        this.ValueCount = (int)valueCountU;
        this.Count = (int)countU;
        return true;
    }
}