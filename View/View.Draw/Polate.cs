namespace View.Draw;

public class Polate : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.KindList = PolateKindList.This;

        ulong valueK;
        valueK = 0;
        if (this.Kind == this.KindList.Linear)
        {
            valueK = this.Linear.Intern;
        }
        if (this.Kind == this.KindList.Radial)
        {
            valueK = this.Radial.Intern;
        }

        this.Intern = Extern.Polate_New();
        Extern.Polate_KindSet(this.Intern, this.Kind.Intern);
        Extern.Polate_ValueSet(this.Intern, valueK);
        Extern.Polate_StopSet(this.Intern, this.Stop.Intern);
        Extern.Polate_SpreadSet(this.Intern, this.Spread.Intern);
        Extern.Polate_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Polate_Final(this.Intern);
        Extern.Polate_Delete(this.Intern);
        return true;
    }

    public virtual PolateKind Kind { get; set; }
    public virtual PolateLinear Linear { get; set; }
    public virtual PolateRadial Radial { get; set; }
    public virtual PolateStop Stop { get; set; }
    public virtual PolateSpread Spread { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual PolateKindList KindList { get; set; }
    internal virtual ulong Intern { get; set; }
}