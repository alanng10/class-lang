class PolateRadial : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        this.InternCenterPos : this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternCenterPos, this.CenterPos.Col, this.CenterPos.Row);

        this.InternFocusPos : this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternFocusPos, this.FocusPos.Col, this.FocusPos.Row);

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.PolateRadial_New();
        extern.PolateRadial_CenterPosSet(this.Intern, this.InternCenterPos);
        extern.PolateRadial_CenterRadiusSet(this.Intern, this.CenterRadius);
        extern.PolateRadial_FocusPosSet(this.Intern, this.InternFocusPos);
        extern.PolateRadial_FocusRadiusSet(this.Intern, this.FocusRadius);
        extern.PolateRadial_Init(this.Intern);
        return true;
    }
}