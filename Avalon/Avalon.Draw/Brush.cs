namespace Avalon.Draw;

public class Brush : Any
{
    public override bool Init()
    {
        base.Init();
        BrushInfra infra;
        infra = BrushInfra.This;

        ulong imageU;
        imageU = 0;
        if (!(this.Video == null))
        {
            imageU = this.Video.Ident;
        }

        this.Intern = Extern.Brush_New();
        Extern.Brush_ImageSet(this.Intern, imageU);
        Extern.Brush_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Brush_Final(this.Intern);
        Extern.Brush_Delete(this.Intern);
        return true;
    }

    public virtual VideoVideo Video { get; set; }
    public virtual Pos FillPos { get; set; }
    internal virtual ulong Intern { get; set; }    
}