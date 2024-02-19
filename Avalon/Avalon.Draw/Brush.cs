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
            imageU = this.Image.Video.Ident;
        }



        ulong gradientU;

        gradientU = 0;


        if (!(this.Gradient == null))
        {
            gradientU = this.Gradient.Intern;
        }



        this.Intern = Extern.Brush_New();


        Extern.Brush_SetKind(this.Intern, kindU);

        Extern.Brush_SetColor(this.Intern, colorU);

        Extern.Brush_SetImage(this.Intern, imageU);

        Extern.Brush_SetGradient(this.Intern, gradientU);

        
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


    public virtual Image Image { get; set; }


    public virtual Gradient Gradient { get; set; }




    internal virtual ulong Intern { get; set; }




    
}