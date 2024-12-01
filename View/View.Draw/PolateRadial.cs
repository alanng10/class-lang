namespace View.Draw;

public class PolateRadial : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;

        this.InternCenterPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternCenterPos, this.CenterPos.Col, this.CenterPos.Row);

        this.InternFocusPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternFocusPos, this.FocusPos.Col, this.FocusPos.Row);

        ulong centerRadiusK;
        centerRadiusK = (ulong)(this.CenterRadius);
        ulong focusRadiusK;
        focusRadiusK = (ulong)(this.FocusRadius);

        this.Intern = Extern.PolateRadial_New();
        Extern.PolateRadial_CenterPosSet(this.Intern, this.InternCenterPos);
        Extern.PolateRadial_CenterRadiusSet(this.Intern, centerRadiusK);
        Extern.PolateRadial_FocusPosSet(this.Intern, this.InternFocusPos);
        Extern.PolateRadial_FocusRadiusSet(this.Intern, focusRadiusK);
        Extern.PolateRadial_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.PolateRadial_Final(this.Intern);
        Extern.PolateRadial_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternFocusPos);

        this.InternInfra.PosDelete(this.InternCenterPos);
        return true;
    }

    public virtual Pos CenterPos { get; set; }
    public virtual long CenterRadius { get; set; }
    public virtual Pos FocusPos { get; set; }
    public virtual long FocusRadius { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternFocusPos { get; set; }
    private ulong InternCenterPos { get; set; }
}