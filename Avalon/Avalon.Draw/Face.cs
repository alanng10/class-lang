namespace Avalon.Draw;

public class Face : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;

        this.InternName = this.InternInfra.StringCreate(this.Name.Value);

        ulong sizeU;
        sizeU = (ulong)(this.Size);
        ulong weightU;
        weightU = (ulong)(this.Weight);
        ulong italicU;
        italicU = (ulong)(this.Italic ? 1 : 0);
        ulong underlineU;
        underlineU = (ulong)(this.Underline ? 1 : 0);
        ulong overlineU;
        overlineU = (ulong)(this.Overline ? 1 : 0);
        ulong strikeoutU;
        strikeoutU = (ulong)(this.Strikeout ? 1 : 0);

        this.Intern = Extern.Face_New();
        // Extern.Face_NameSet(this.Intern, this.InternName);
        Extern.Face_SizeSet(this.Intern, sizeU);
        Extern.Face_WeightSet(this.Intern, weightU);
        Extern.Face_ItalicSet(this.Intern, italicU);
        Extern.Face_UnderlineSet(this.Intern, underlineU);
        Extern.Face_OverlineSet(this.Intern, overlineU);
        Extern.Face_StrikeoutSet(this.Intern, strikeoutU);
        Extern.Face_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Face_Final(this.Intern);
        Extern.Face_Delete(this.Intern);

        this.InternInfra.StringDelete(this.InternName);
        return true;
    }

    public virtual String Name { get; set; }
    public virtual long Size { get; set; }
    public virtual long Weight { get; set; }
    public virtual bool Italic { get; set; }
    public virtual bool Underline { get; set; }
    public virtual bool Overline { get; set; }
    public virtual bool Strikeout { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternName { get; set; }
}