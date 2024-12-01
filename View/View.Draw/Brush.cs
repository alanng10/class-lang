namespace View.Draw;

public class Brush : Any
{
    public override bool Init()
    {
        base.Init();
        BrushInfra infra;
        infra = BrushInfra.This;
        ulong colorK;
        colorK = 0;
        if (!(this.Color == null))
        {
            colorK = infra.InternColor(this.Color);
        }
        ulong imageK;
        imageK = 0;
        if (!(this.Image == null))
        {
            imageK = this.Image.Ident;
        }
        ulong polateK;
        polateK = 0;
        if (!(this.Polate == null))
        {
            polateK = this.Polate.Intern;
        }

        this.Intern = Extern.Brush_New();
        Extern.Brush_KindSet(this.Intern, this.Kind.Intern);
        Extern.Brush_ColorSet(this.Intern, colorK);
        Extern.Brush_ImageSet(this.Intern, imageK);
        Extern.Brush_PolateSet(this.Intern, polateK);
        Extern.Brush_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Brush_Final(this.Intern);
        Extern.Brush_Delete(this.Intern);
        return true;
    }

    public virtual BrushKind Kind { get; set; }
    public virtual Color Color { get; set; }
    public virtual Polate Polate { get; set; }
    public virtual Image Image { get; set; }
    internal virtual ulong Intern { get; set; }
}