namespace View.Draw;

public class Font : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;

        this.InternName = this.InternInfra.StringCreate(this.Name);

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

        this.Intern = Extern.Font_New();
        Extern.Font_NameSet(this.Intern, this.InternName);
        Extern.Font_SizeSet(this.Intern, sizeU);
        Extern.Font_WeightSet(this.Intern, weightU);
        Extern.Font_ItalicSet(this.Intern, italicU);
        Extern.Font_UnderlineSet(this.Intern, underlineU);
        Extern.Font_OverlineSet(this.Intern, overlineU);
        Extern.Font_StrikeoutSet(this.Intern, strikeoutU);
        Extern.Font_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Font_Final(this.Intern);
        Extern.Font_Delete(this.Intern);

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
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternName { get; set; }
}