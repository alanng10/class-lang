namespace Avalon.Draw;

public class Brush : Any
{
    public override bool Init()
    {
        base.Init();
        BrushInfra infra;
        infra = BrushInfra.This;
        ulong kindU;
        kindU = this.Kind.Intern;
        ulong colorU;
        colorU = 0;
        if (!(this.Color == null))
        {
            colorU = infra.InternColor(this.Color);
        }
        ulong imageU;
        imageU = 0;
        if (!(this.Image == null))
        {
            imageU = this.Image.Ident;
        }
        ulong gradientU;
        gradientU = 0;
        if (!(this.Gradient == null))
        {
            gradientU = this.Gradient.Intern;
        }

        ulong lineU;
        ulong wedU;
        ulong capU;
        ulong joinU;
        lineU = 0;
        wedU = 0;
        capU = 0;
        joinU = 0;
        
        if (!(this.Line == null))
        {
            lineU = this.Line.Intern;
            wedU = (ulong)(this.Wed);
            capU = this.Cap.Intern;
            joinU = this.Join.Intern;
        }

        this.Intern = Extern.Brush_New();
        Extern.Brush_KindSet(this.Intern, kindU);
        Extern.Brush_ColorSet(this.Intern, colorU);
        Extern.Brush_ImageSet(this.Intern, imageU);
        Extern.Brush_GradientSet(this.Intern, gradientU);
        Extern.Brush_LineSet(this.Intern, lineU);
        Extern.Brush_WidthSet(this.Intern, wedU);
        Extern.Brush_CapSet(this.Intern, capU);
        Extern.Brush_JoinSet(this.Intern, joinU);
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
    public virtual Gradient Gradient { get; set; }
    public virtual Image Image { get; set; }
    public virtual BrushLine Line { get; set; }
    public virtual long Wed { get; set; }
    public virtual BrushCap Cap { get; set; }
    public virtual BrushJoin Join { get; set; }
    internal virtual ulong Intern { get; set; }    
}