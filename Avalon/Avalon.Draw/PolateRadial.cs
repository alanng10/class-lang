namespace Avalon.Draw;

public class PolateRadial : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;

        Pos pos;
        pos = this.CenterPos;
        this.InternCenterPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternCenterPos, pos.Col, pos.Row);
        
        pos = this.FocusPos;
        this.InternFocusPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternFocusPos, pos.Col, pos.Row);

        ulong centerRadiusU;
        centerRadiusU = (ulong)(this.CenterRadius);
        ulong focusRadiusU;
        focusRadiusU = (ulong)(this.FocusRadius);

        this.Intern = Extern.PolateRadial_New();
        Extern.PolateRadial_CenterPosSet(this.Intern, this.InternCenterPos);
        Extern.PolateRadial_CenterRadiusSet(this.Intern, centerRadiusU);
        Extern.PolateRadial_FocusPosSet(this.Intern, this.InternFocusPos);
        Extern.PolateRadial_FocusRadiusSet(this.Intern, focusRadiusU);
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

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternFocusPos { get; set; }
    private ulong InternCenterPos { get; set; }
}