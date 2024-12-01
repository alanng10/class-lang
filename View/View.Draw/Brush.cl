class Brush : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var BrushInfra infra;
        infra : share BrushInfra;

        var Int colorK;
        colorK : 0;
        inf (~(this.Color = null))
        {
            colorK : infra.InternColor(this.Color);
        }
        var Int imageK;
        imageK : 0;
        inf (~(this.Image = null))
        {
            imageK : this.Image.Intern;
        }
        var Int polateK;
        polateK : 0;
        inf (~(this.Polate = null))
        {
            polateK : this.Polate.Intern;
        }
        
        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Brush_New();
        extern.Brush_KindSet(this.Intern, this.Kind.Intern);
        extern.Brush_ColorSet(this.Intern, colorK);
        extern.Brush_ImageSet(this.Intern, ImageK);
        extern.Brush_PolateSet(this.Intern, polateK);
        extern.Brush_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Brush_Final(this.Intern);
        extern.Brush_Delete(this.Intern);
        return true;        
    }

    field prusate BrushKind Kind { get { return data; } set { data : value; } }
    field prusate Color Color { get { return data; } set { data : value; } }
    field prusate Polate Polate { get { return data; } set { data : value; } }
    field prusate Image Image { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
}