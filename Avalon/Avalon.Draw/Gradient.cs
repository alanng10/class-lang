namespace Avalon.Draw;

public class Gradient : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.KindList = GradientKindList.This;

        ulong kindU;
        kindU = this.Kind.Intern;
        ulong valueU;
        valueU = 0;
        if (this.Kind == this.KindList.Linear)
        {
            valueU = this.Linear.Intern;
        }
        if (this.Kind == this.KindList.Radial)
        {
            valueU = this.Radial.Intern;
        }
        ulong stopU;
        stopU = this.Stop.Intern;
        ulong spreadU;
        spreadU = this.Spread.Intern;

        this.Intern = Extern.Gradient_New();
        Extern.Gradient_SetKind(this.Intern, kindU);
        Extern.Gradient_SetValue(this.Intern, valueU);
        Extern.Gradient_SetStop(this.Intern, stopU);
        Extern.Gradient_SetSpread(this.Intern, spreadU);
        Extern.Gradient_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Gradient_Final(this.Intern);
        Extern.Gradient_Delete(this.Intern);
        return true;
    }

    public virtual GradientKind Kind { get; set; }
    public virtual GradientLinear Linear { get; set; }
    public virtual GradientRadial Radial { get; set; }
    public virtual GradientStop Stop { get; set; }
    public virtual GradientSpread Spread { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual GradientKindList KindList { get; set; }
    internal virtual ulong Intern { get; set; }
}