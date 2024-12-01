namespace View.Draw;

public class PolateLinear : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;

        this.InternStartPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternStartPos, this.StartPos.Col, this.StartPos.Row);

        this.InternEndPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternEndPos, this.EndPos.Col, this.EndPos.Row);

        this.Intern = Extern.PolateLinear_New();
        Extern.PolateLinear_StartPosSet(this.Intern, this.InternStartPos);
        Extern.PolateLinear_EndPosSet(this.Intern, this.InternEndPos);
        Extern.PolateLinear_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.PolateLinear_Final(this.Intern);
        Extern.PolateLinear_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternEndPos);

        this.InternInfra.PosDelete(this.InternStartPos);
        return true;
    }

    public virtual Pos StartPos { get; set; }
    public virtual Pos EndPos { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternEndPos { get; set; }
    private ulong InternStartPos { get; set; }
}