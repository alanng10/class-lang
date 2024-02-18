namespace Avalon.Draw;




public class Pen : Any
{
    public override bool Init()
    {
        base.Init();





        ulong kindU;

        kindU = this.Kind.Intern;



        ulong widthU;

        widthU = (ulong)(this.Width);



        ulong brushU;

        brushU = this.Brush.Intern;



        ulong capU;

        capU = this.Cap.Intern;



        ulong joinU;

        joinU = this.Join.Intern;




        this.Intern = Extern.Pen_New();


        Extern.Pen_SetKind(this.Intern, kindU);

        Extern.Pen_SetWidth(this.Intern, widthU);

        Extern.Pen_SetBrush(this.Intern, brushU);

        Extern.Pen_SetCap(this.Intern, capU);

        Extern.Pen_SetJoin(this.Intern, joinU);


        Extern.Pen_Init(this.Intern);



        return true;
    }





    public virtual bool Final()
    {
        Extern.Pen_Final(this.Intern);


        Extern.Pen_Delete(this.Intern);



        return true;
    }





    public virtual PenKind Kind { get; set; }


    public virtual int Width { get; set; }


    public virtual Brush Brush { get; set; }


    public virtual PenCap Cap { get; set; }


    public virtual PenJoin Join { get; set; }



    internal virtual ulong Intern { get; set; }
}