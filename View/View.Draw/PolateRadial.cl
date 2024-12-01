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

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.PolateRadial_Final(this.Intern);
        extern.PolateRadial_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternFocusPos);

        this.InternInfra.PosDelete(this.InternCenterPos);
        return true;
    }

    field prusate Pos CenterPos { get { return data; } set { data : value; } }
    field prusate Int CenterRadius { get { return data; } set { data : value; } }
    field prusate Pos FocusPos { get { return data; } set { data : value; } }
    field prusate Int FocusRadius { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
    field private Int InternFocusPos { get { return data; } set { data : value; } }
    field private Int InternCenterPos { get { return data; } set { data : value; } }
}