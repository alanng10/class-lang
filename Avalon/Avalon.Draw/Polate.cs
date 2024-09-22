namespace Avalon.Draw;

public class Polate : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        // this.KindList = GradientKindList.This;

        ulong kindU;
        kindU = this.Kind.Intern;
        ulong valueU;
        valueU = 0;
        // if (this.Kind == this.KindList.Linear)
        // {
        //     valueU = this.Linear.Intern;
        // }
        // if (this.Kind == this.KindList.Radial)
        // {
        //     valueU = this.Radial.Intern;
        // }
        ulong stopU;
        stopU = this.Stop.Intern;
        ulong spreadU;
        spreadU = this.Spread.Intern;

        this.Intern = Extern.Polate_New();
        Extern.Polate_KindSet(this.Intern, kindU);
        Extern.Polate_ValueSet(this.Intern, valueU);
        Extern.Polate_StopSet(this.Intern, stopU);
        Extern.Polate_SpreadSet(this.Intern, spreadU);
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
    public virtual GradientSpread Spread { get; set; }

    private InternIntern InternIntern { get; set; }
    // protected virtual GradientKindList KindList { get; set; }
    internal virtual ulong Intern { get; set; }
}