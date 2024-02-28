namespace Avalon.Text;


public class FormatArgList : Any
{
    public override bool Init()
    {
        base.Init();
        ulong countU;
        countU = (ulong)this.Count;

        this.Intern = Extern.Array_New();

        Extern.Array_SetCount(this.Intern, countU);
        Extern.Array_Init(this.Intern);

        return true;
    }

    public virtual bool Final()
    {
        Extern.Array_Final(this.Intern);
        Extern.Array_Delete(this.Intern);

        return true;
    }

    public virtual int Count { get; set; }

    internal virtual ulong Intern { get; set; }

    public virtual bool SetItem(int index, FormatArg value)
    {
        ulong indexU;
        indexU = (ulong)index;
        ulong valueU;
        valueU = value.Intern;
        Extern.Array_SetItem(this.Intern, indexU, valueU);
        return true;
    }
}