namespace Mirai.Draw;

public class Slash : Any
{
    public override bool Init()
    {
        base.Init();

        ulong brushU;
        ulong lineU;
        ulong wedU;
        ulong capU;
        ulong joinU;
        brushU = this.Brush.Intern;
        lineU = this.Line.Intern;
        wedU = (ulong)(this.Wed);
        capU = this.Cap.Intern;
        joinU = this.Join.Intern;

        this.Intern = Extern.Slash_New();
        Extern.Slash_BrushSet(this.Intern, brushU);
        Extern.Slash_LineSet(this.Intern, lineU);
        Extern.Slash_WidthSet(this.Intern, wedU);
        Extern.Slash_CapSet(this.Intern, capU);
        Extern.Slash_JoinSet(this.Intern, joinU);
        Extern.Slash_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Slash_Final(this.Intern);
        Extern.Slash_Delete(this.Intern);
        return true;
    }

    public virtual Brush Brush { get; set; }
    public virtual SlashLine Line { get; set; }
    public virtual long Wed { get; set; }
    public virtual SlashCap Cap { get; set; }
    public virtual SlashJoin Join { get; set; }
    internal virtual ulong Intern { get; set; }
}