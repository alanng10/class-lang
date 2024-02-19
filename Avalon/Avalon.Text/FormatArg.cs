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


        if (kind == 1)
        {
            valueU = (ulong)this.ValueInt;
        }


        if (kind == 2)
        {
            this.InternString = this.InternInfra.StringCreate(this.ValueString);

            valueU = this.InternString;
        }


        ulong alignLeftU;
        alignLeftU = (ulong)(this.AlignLeft ? 1 : 0);

        ulong fieldWidthU;
        fieldWidthU = (ulong)this.FieldWidth;

        ulong maxWidthU;
        maxWidthU = (ulong)this.MaxWidth;


        Extern.FormatArg_SetPos(this.Intern, posU);

        Extern.FormatArg_SetKind(this.Intern, kindU);

        Extern.FormatArg_SetValue(this.Intern, valueU);

        Extern.FormatArg_SetAlign(this.Intern, alignLeftU);

        Extern.FormatArg_SetFieldWidth(this.Intern, fieldWidthU);

        Extern.FormatArg_SetMaxWidth(this.Intern, maxWidthU);

        return true;
    }
}