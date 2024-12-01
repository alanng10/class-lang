class PolateLinear : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        this.InternStartPos : this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternStartPos, this.StartPos.Col, this.StartPos.Row);

        this.InternEndPos : this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternEndPos, this.EndPos.Col, this.EndPos.Row);

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.PolateLinear_New();
        extern.PolateLinear_StartPosSet(this.Intern, this.InternStartPos);
        extern.PolateLinear_EndPosSet(this.Intern, this.InternEndPos);
        extern.PolateLinear_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.PolateLinear_Final(this.Intern);
        extern.PolateLinear_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternEndPos);

        this.InternInfra.PosDelete(this.InternStartPos);
        return true;
    }

    field prusate Pos StartPos { get { return data; } set { data : value; } }
    field prusate Pos EndPos { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
    field private Int InternEndPos { get { return data; } set { data : value; } }
    field private Int InternStartPos { get { return data; } set { data : value; } }
}